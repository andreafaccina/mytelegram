﻿namespace MyTelegram.Domain.Sagas;

public class MessageSaga :
    MyInMemoryAggregateSaga<MessageSaga, MessageSagaId, MessageSagaLocator>,
    ISagaIsStartedBy<MessageAggregate, MessageId, SendMessageStartedEvent>,
    ISagaHandles<UserAggregate, UserId, CheckUserStateCompletedEvent>,
    ISagaHandles<ChatAggregate, ChatId, CheckChatStateCompletedEvent>,
    ISagaHandles<ChannelAggregate, ChannelId, CheckChannelStateCompletedEvent>,
    ISagaHandles<MessageAggregate, MessageId, OutboxMessageCreatedEvent>,
    ISagaHandles<MessageAggregate, MessageId, InboxMessageCreatedEvent>,
    ISagaHandles<MessageAggregate, MessageId, ReplyToMessageStartedEvent>,
    ISagaHandles<MessageAggregate, MessageId, ReplyToMessageEvent>
{
    private readonly IIdGenerator _idGenerator;
    private readonly MessageSagaState _state = new();

    public MessageSaga(MessageSagaId id,
        IEventStore eventStore,
        IIdGenerator idGenerator) : base(id, eventStore)
    {
        _idGenerator = idGenerator;
        Register(_state);
    }

    public Task HandleAsync(IDomainEvent<ChannelAggregate, ChannelId, CheckChannelStateCompletedEvent> domainEvent,
        ISagaContext sagaContext,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(_state.MessageItem);
        var views = _state.MessageItem.Views;
        if (domainEvent.AggregateEvent.Views > 0)
        {
            views = domainEvent.AggregateEvent.Views.Value;
        }

        Emit(new SendChannelMessageStartedEvent(domainEvent.AggregateEvent.Post,
            views,
            domainEvent.AggregateEvent.BotUidList,
            domainEvent.AggregateEvent.LinkedChannelId,
            domainEvent.AggregateEvent.CorrelationId));
        var outboxMessageItem = _state.MessageItem;
        outboxMessageItem.Post = domainEvent.AggregateEvent.Post;
        outboxMessageItem.Views = views;

        return CreateOutboxMessageAsync(_state.RequestInfo.ReqMsgId,
            outboxMessageItem,
            _state.ClearDraft,
            _state.GroupItemCount,
            _state.CorrelationId);
    }

    public Task HandleAsync(IDomainEvent<ChatAggregate, ChatId, CheckChatStateCompletedEvent> domainEvent,
        ISagaContext sagaContext,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(_state.MessageItem);
        Emit(new SendChatMessageStartedEvent(domainEvent.AggregateEvent.Title,
            domainEvent.AggregateEvent.MemberUidList));
        return CreateOutboxMessageAsync(_state.RequestInfo.ReqMsgId,
            _state.MessageItem,
            _state.ClearDraft,
            _state.GroupItemCount,
            _state.CorrelationId);
    }

    public async Task HandleAsync(IDomainEvent<MessageAggregate, MessageId, InboxMessageCreatedEvent> domainEvent,
        ISagaContext sagaContext,
        CancellationToken cancellationToken)
    {
        var item = domainEvent.AggregateEvent.InboxMessageItem;
        var receiveInboxMessageCommand = new ReceiveInboxMessageCommand(
            DialogId.Create(item.OwnerPeer.PeerId,
                item.ToPeer),
            item.MessageId,
            item.OwnerPeer.PeerId,
            item.ToPeer,
            domainEvent.AggregateEvent.CorrelationId
        );
        Publish(receiveInboxMessageCommand);

        var command = new AddInboxMessageIdToOutboxMessageCommand(
            MessageId.Create(item.SenderPeer.PeerId,
                domainEvent.AggregateEvent.SenderMessageId),
            item.OwnerPeer.PeerId,
            item.MessageId,
            domainEvent.AggregateEvent.CorrelationId);
        Publish(command);
        await HandleReceiveInboxMessageCompletedAsync(item);
    }

    public async Task HandleAsync(IDomainEvent<MessageAggregate, MessageId, OutboxMessageCreatedEvent> domainEvent,
        ISagaContext sagaContext,
        CancellationToken cancellationToken)
    {
        SetTopMessageId(domainEvent.AggregateEvent);
        // Create reply message if ReplyToMsgId has value,then create inbox message 
        if (domainEvent.AggregateEvent.OutboxMessageItem.ReplyToMsgId.HasValue)
        {
            StartReplyToMessage(domainEvent.AggregateEvent.OutboxMessageItem.OwnerPeer.PeerId,
                domainEvent.AggregateEvent.OutboxMessageItem.SenderPeer,
                domainEvent.AggregateEvent.OutboxMessageItem.ReplyToMsgId.Value,
                domainEvent.AggregateEvent.CorrelationId);
        }
        else
        {
            await HandleSendOutboxMessageCompletedAsync();
            await CreateInboxMessageAsync();
        }
    }

    public async Task HandleAsync(IDomainEvent<MessageAggregate, MessageId, ReplyToMessageEvent> domainEvent,
        ISagaContext sagaContext,
        CancellationToken cancellationToken)
    {
        HandleReplyToMessage(domainEvent.AggregateEvent);
        await HandleSendOutboxMessageCompletedAsync();
        await CreateInboxMessageAsync();
    }

    public async Task HandleAsync(IDomainEvent<MessageAggregate, MessageId, ReplyToMessageStartedEvent> domainEvent,
        ISagaContext sagaContext,
        CancellationToken cancellationToken)
    {
        if (domainEvent.AggregateEvent.SavedFromPeerId.HasValue)
        {
            Emit(new ReplyToChannelMessageStartedEvent(domainEvent.AggregateEvent.ReplyToMsgId,
                domainEvent.AggregateEvent.SavedFromPeerId.Value,
                domainEvent.AggregateEvent.SavedFromMsgId!.Value,
                domainEvent.AggregateEvent.RecentRepliers));
        }

        // Reply outbox message,the reply message sender is current message sender
        if (domainEvent.AggregateEvent.IsOut)
        {
            // Reply outbox message:
            // outbox message's replyToMessageId is from client
            // inbox message's replyToMessageId is from inbox item in ReplyToMessageStartedEvent
            await HandleSendOutboxMessageCompletedAsync();
            Emit(new ReplyToMessageCompletedEvent(domainEvent.AggregateEvent.InboxItems));
            await CreateInboxMessageAsync();
        }
        else
        {
            // Reply inbox message:
            // 1.find sender' messageId
            // 2.send ReplyToMessageCommand 
            // 3.handle ReplyToMessageEvent
            Emit(new ReplyToMessageCompletedEvent(new List<InboxItem>
                { new(domainEvent.AggregateEvent.SenderPeer.PeerId, domainEvent.AggregateEvent.SenderMessageId) }));
            ReplyToMessage(_state.RequestInfo.ReqMsgId,
                domainEvent.AggregateEvent.SenderPeer.PeerId,
                domainEvent.AggregateEvent.SenderMessageId,
                domainEvent.AggregateEvent.CorrelationId);
        }
    }

    public Task HandleAsync(IDomainEvent<UserAggregate, UserId, CheckUserStateCompletedEvent> domainEvent,
        ISagaContext sagaContext,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(_state.MessageItem);
        return CreateOutboxMessageAsync(_state.RequestInfo.ReqMsgId,
            _state.MessageItem,
            _state.ClearDraft,
            _state.GroupItemCount,
            _state.CorrelationId);
    }

    public Task HandleAsync(IDomainEvent<MessageAggregate, MessageId, SendMessageStartedEvent> domainEvent,
        ISagaContext sagaContext,
        CancellationToken cancellationToken)
    {
        Emit(new MessageSagaStartedEvent(domainEvent.AggregateEvent.RequestInfo,
            domainEvent.AggregateEvent.OutMessageItem,
            domainEvent.AggregateEvent.ClearDraft,
            domainEvent.AggregateEvent.GroupItemCount,
            domainEvent.AggregateEvent.ForwardFromLinkedChannel,
            domainEvent.AggregateEvent.CorrelationId));

        var item = domainEvent.AggregateEvent.OutMessageItem;
        switch (domainEvent.AggregateEvent.OutMessageItem.ToPeer.PeerType)
        {
            case PeerType.Self:
            case PeerType.User:
            {
                var command = new CheckUserStateCommand(UserId.Create(item.ToPeer.PeerId),
                    domainEvent.AggregateEvent.RequestInfo.ReqMsgId,
                    domainEvent.AggregateEvent.CorrelationId);
                Publish(command);
            }
                break;
            case PeerType.Chat:
            {
                var command = new CheckChatStateCommand(ChatId.Create(item.ToPeer.PeerId),
                    domainEvent.AggregateEvent.CorrelationId);
                Publish(command);
            }
                break;
            case PeerType.Channel:
            {
                var command = new CheckChannelStateCommand(ChannelId.Create(item.ToPeer.PeerId),
                    item.SenderPeer.PeerId,
                    item.MessageId,
                    item.Date,
                    item.MessageSubType,
                    domainEvent.AggregateEvent.CorrelationId);
                Publish(command);
            }
                break;
        }

        return Task.CompletedTask;
    }

    private async Task CreateInboxMessageAsync()
    {
        ArgumentNullException.ThrowIfNull(_state.MessageItem);

        switch (_state.MessageItem.ToPeer.PeerType)
        {
            case PeerType.User:
                await CreateInboxMessageForUserPeerAsync(_state.MessageItem.ToPeer.PeerId);
                break;
            case PeerType.Chat:
                ArgumentNullException.ThrowIfNull(_state.ChatMemberUidList);
                // TODO:Send message to removed member(DeleteChatUserHandler)
                foreach (var memberUid in _state.ChatMemberUidList)
                {
                    if (memberUid == _state.MessageItem.SenderPeer.PeerId)
                    {
                        continue;
                    }

                    await CreateInboxMessageForUserPeerAsync(memberUid);
                }

                break;
        }
    }

    private async Task CreateInboxMessageForUserPeerAsync(long inboxOwnerPeerId)
    {
        var outMessageItem = _state.MessageItem!;
        var toPeer = outMessageItem.ToPeer.PeerType == PeerType.Chat ? outMessageItem.ToPeer : outMessageItem.OwnerPeer;

        // Channel only create outbox message,
        // the idType can only be IdType.MessageId for inbox message
        var inboxMessageId = await _idGenerator.NextIdAsync(IdType.MessageId, inboxOwnerPeerId);
        var aggregateId = MessageId.Create(inboxOwnerPeerId, inboxMessageId);
        var inboxMessageItem = new MessageItem(
            new Peer(PeerType.User, inboxOwnerPeerId),
            toPeer,
            outMessageItem.SenderPeer,
            inboxMessageId,
            outMessageItem.Message,
            outMessageItem.Date,
            outMessageItem.RandomId,
            false,
            outMessageItem.SendMessageType,
            outMessageItem.MessageType,
            outMessageItem.MessageSubType,
            _state.GetReplyToMsgId(inboxOwnerPeerId),
            outMessageItem.MessageActionData,
            outMessageItem.MessageActionType,
            outMessageItem.Entities,
            outMessageItem.Media,
            outMessageItem.GroupId,
            outMessageItem.Post,
            outMessageItem.FwdHeader,
            outMessageItem.Views,
            outMessageItem.PollId
        );

        var command = new CreateInboxMessageCommand(aggregateId,
            inboxMessageItem,
            outMessageItem.MessageId,
            _state.CorrelationId);
        Publish(command);
    }

    private async Task CreateOutboxMessageAsync(long reqMsgId,
        MessageItem messageItem,
        bool clearDraft,
        int groupItemCount,
        Guid correlationId)
    {
        var idType = messageItem.ToPeer.PeerType == PeerType.Channel ? IdType.ChannelMessageId : IdType.MessageId;
        var ownerPeerId = messageItem.OwnerPeer.PeerId;
        var outMessageId = await _idGenerator.NextIdAsync(idType, ownerPeerId);
        // TODO:Create new MessageItem instance
        messageItem.MessageId = outMessageId;
        var aggregateId = MessageId.Create(messageItem.OwnerPeer.PeerId, messageItem.MessageId);
        var linkedChannelId = _state.LinkedChannelId;
        if (linkedChannelId == null && _state.ForwardFromLinkedChannel)
        {
            linkedChannelId = _state.MessageItem!.ToPeer.PeerId;
        }

        var command = new CreateOutboxMessageCommand(aggregateId,
            reqMsgId,
            messageItem,
            clearDraft,
            groupItemCount,
            linkedChannelId,
            correlationId);
        Publish(command);
        Emit(new OutboxMessageIdGeneratedEvent(outMessageId));
    }

    private void ForwardBroadcastMessageToLinkedChannel(long linkedChannelId,
        int messageId)
    {
        var aggregateId = MessageId.Create(_state.MessageItem!.OwnerPeer.PeerId, messageId);
        var fromPeer = _state.MessageItem!.ToPeer;
        var toPeer = new Peer(PeerType.Channel, linkedChannelId);
        var randomBytes = new byte[8];
        Random.Shared.NextBytes(randomBytes);
        var command = new StartForwardMessageCommand(aggregateId,
            _state.RequestInfo,
            fromPeer,
            toPeer,
            new List<int> { messageId },
            new List<long> { BitConverter.ToInt64(randomBytes) },
            true,
            Guid.NewGuid()
        );
        Publish(command);
    }

    private async Task HandleReceiveInboxMessageCompletedAsync(MessageItem inboxMessageItem)
    {
        var pts = await _idGenerator.NextIdAsync(IdType.Pts, inboxMessageItem.OwnerPeer.PeerId);
        Emit(new ReceiveInboxMessageCompletedEvent(inboxMessageItem, pts, _state.ChatTitle));

        if (_state.IsSendMessageCompleted())
        {
            await CompleteAsync();
        }
    }

    private void HandleReplyDiscussionMessage()
    {
        if (_state.ReplyToMessageSavedFromPeerId != 0)
        {
            var savedFromPeerId = _state.ReplyToMessageSavedFromPeerId;
            Emit(new ReplyToChannelMessageCompletedEvent(_state.ReplyToMsgId,
                _state.MessageItem!.ToPeer.PeerId,
                _state.Pts,
                _state.MessageItem.MessageId,
                savedFromPeerId,
                _state.ReplyToMessageSavedFromMsgId,
                _state.RecentRepliers!));
        }
    }

    private void HandleReplyToMessage(ReplyToMessageEvent aggregateEvent)
    {
        if (aggregateEvent.InboxItems != null)
        {
            Emit(new ReplyToMessageCompletedEvent(aggregateEvent.InboxItems));
        }
    }

    private async Task HandleSendOutboxMessageCompletedAsync()
    {
        var pts = await _idGenerator.NextIdAsync(IdType.Pts, _state.MessageItem!.OwnerPeer.PeerId)
            ;
        var linkedChannelId = _state.LinkedChannelId;
        if (linkedChannelId == null && _state.ForwardFromLinkedChannel)
        {
            linkedChannelId = _state.MessageItem.ToPeer.PeerId;
        }

        Emit(new SendOutboxMessageCompletedEvent(_state.RequestInfo,
            _state.MessageItem,
            pts,
            _state.GroupItemCount,
            linkedChannelId));

        if (_state.MessageItem.ToPeer.PeerType == PeerType.Channel)
        {
            SetChannelPts(_state.MessageItem.ToPeer.PeerId, pts, _state.MessageItem.MessageId);

            if (_state.LinkedChannelId.HasValue && _state.MessageItem.SendMessageType != SendMessageType.MessageService)
            {
                ForwardBroadcastMessageToLinkedChannel(_state.LinkedChannelId.Value, _state.MessageItem.MessageId);
            }

            HandleReplyDiscussionMessage();
            await CompleteAsync();
        }
    }

    private void ReplyToMessage(long reqMsgId,
        long ownerPeerId,
        int messageId,
        Guid correlationId)
    {
        var aggregateId = MessageId.Create(ownerPeerId, messageId);
        var command = new ReplyToMessageCommand(aggregateId, reqMsgId, messageId, correlationId);
        Publish(command);
    }

    private void SetChannelPts(long channelId,
        int pts,
        int messageId)
    {
        var command = new SetChannelPtsCommand(ChannelId.Create(channelId),
            _state.MessageItem!.SenderPeer.PeerId,
            pts,
            messageId,
            _state.MessageItem.Date);
        Publish(command);
    }

    private void SetTopMessageId(OutboxMessageCreatedEvent aggregateEvent)
    {
        var item = aggregateEvent.OutboxMessageItem;
        var command = new SetOutboxTopMessageCommand(DialogId.Create(item.SenderPeer.PeerId,
                item.ToPeer),
            item.MessageId,
            item.SenderPeer.PeerId,
            item.ToPeer,
            aggregateEvent.ClearDraft,
            aggregateEvent.CorrelationId
        );
        Publish(command);
    }

    private void StartReplyToMessage(long ownerPeerId,
        Peer replierPeer,
        int replyToMsgId,
        Guid correlationId)
    {
        var command =
            new StartReplyToMessageCommand(MessageId.Create(ownerPeerId, replyToMsgId),
                replierPeer,
                replyToMsgId,
                correlationId);
        Publish(command);
    }
}
