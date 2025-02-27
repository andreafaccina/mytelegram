﻿namespace MyTelegram.Domain.Sagas.States;

public class MessageSagaState : AggregateState<MessageSaga, MessageSagaId, MessageSagaState>,
    IApply<MessageSagaStartedEvent>,
    IApply<SendChatMessageStartedEvent>,
    IApply<ReplyToMessageCompletedEvent>,
    IApply<SendChannelMessageStartedEvent>,
    IApply<SendOutboxMessageCompletedEvent>,
    IApply<ReceiveInboxMessageCompletedEvent>,
    IApply<OutboxMessageIdGeneratedEvent>,
    IApply<ReplyToChannelMessageStartedEvent>,
    IApply<ReplyToChannelMessageCompletedEvent>
{
    public RequestInfo RequestInfo { get; private set; } = null!;
    public bool ClearDraft { get; private set; }
    public int GroupItemCount { get; private set; }
    public Guid CorrelationId { get; private set; }
    public MessageItem? MessageItem { get; private set; }
    public string? ChatTitle { get; private set; }
    public IReadOnlyList<long>? ChatMemberUidList { get; private set; }
    public Dictionary<long, int> InboxItems { get; } = new();
    public int SenderMessageId { get; private set; }
    public IReadOnlyList<long>? BotUidList { get; private set; }

    public long? LinkedChannelId { get; private set; }

    //public bool Post { get; private set; }
    //public int? Views { get; private set; }
    public bool ForwardFromLinkedChannel { get; private set; }

    public int InboxCount { get; private set; }
    public int Pts { get; private set; }
    public long ReplyToMessageSavedFromPeerId { get; private set; }
    public int ReplyToMessageSavedFromMsgId { get; private set; }
    public int ReplyToMsgId { get; private set; }
    public IReadOnlyCollection<Peer>? RecentRepliers { get; private set; }

    public void Apply(MessageSagaStartedEvent aggregateEvent)
    {
        RequestInfo = aggregateEvent.RequestInfo;
        MessageItem = aggregateEvent.MessageItem;
        ClearDraft = aggregateEvent.ClearDraft;
        GroupItemCount = aggregateEvent.GroupItemCount;
        CorrelationId = aggregateEvent.CorrelationId;
        SenderMessageId = aggregateEvent.MessageItem.MessageId;
        ForwardFromLinkedChannel = aggregateEvent.ForwardFromLinkedChannel;
    }

    public void Apply(OutboxMessageIdGeneratedEvent aggregateEvent)
    {
        MessageItem!.MessageId = aggregateEvent.OutboxMessageId;
    }

    public void Apply(ReceiveInboxMessageCompletedEvent aggregateEvent)
    {
        InboxCount++;
    }

    public void Apply(ReplyToChannelMessageCompletedEvent aggregateEvent)
    {
    }

    public void Apply(ReplyToChannelMessageStartedEvent aggregateEvent)
    {
        ReplyToMessageSavedFromPeerId = aggregateEvent.SavedFromPeerId;
        ReplyToMessageSavedFromMsgId = aggregateEvent.SavedFromMsgId;
        ReplyToMsgId = aggregateEvent.ReplyToMsgId;
        RecentRepliers = aggregateEvent.RecentRepliers;
    }

    public void Apply(ReplyToMessageCompletedEvent aggregateEvent)
    {
        foreach (var inboxItem in aggregateEvent.InboxItems)
        {
            InboxItems.TryAdd(inboxItem.InboxOwnerPeerId, inboxItem.InboxMessageId);
        }
    }

    public void Apply(SendChannelMessageStartedEvent aggregateEvent)
    {
        BotUidList = aggregateEvent.BotUidList;
        LinkedChannelId = aggregateEvent.LinkedChannelId;
        MessageItem!.Post = aggregateEvent.Post;
        MessageItem.Views = aggregateEvent.Views;
    }

    public void Apply(SendChatMessageStartedEvent aggregateEvent)
    {
        ChatTitle = aggregateEvent.Title;
        ChatMemberUidList = aggregateEvent.ChatMemberUidList;
    }

    public void Apply(SendOutboxMessageCompletedEvent aggregateEvent)
    {
        Pts = aggregateEvent.Pts;
        //throw new NotImplementedException();
    }

    public int? GetReplyToMsgId(long inboxOwnerPeerId)
    {
        if (InboxItems.TryGetValue(inboxOwnerPeerId, out var messageId))
        {
            return messageId;
        }

        return null;
    }

    public bool IsSendMessageCompleted()
    {
        if (MessageItem != null)
        {
            switch (MessageItem.ToPeer.PeerType)
            {
                case PeerType.User:
                    return InboxCount == 1;
                case PeerType.Chat:
                    return InboxCount == ChatMemberUidList!.Count;
            }
        }

        return false;
    }
}
