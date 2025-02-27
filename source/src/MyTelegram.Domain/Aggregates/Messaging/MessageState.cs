﻿namespace MyTelegram.Domain.Aggregates.Messaging;

public class MessageState : AggregateState<MessageAggregate, MessageId, MessageState>,
    IApply<SendMessageStartedEvent>,
    IApply<OutboxMessageCreatedEvent>,
    IApply<InboxMessageCreatedEvent>,
    IApply<InboxMessageIdAddedToOutboxMessageEvent>,
    IApply<MessageDeletedEvent>,
    IApply<OutboxMessageEditedEvent>,
    IApply<InboxMessageEditedEvent>,
    IApply<MessageForwardedEvent>,
    IApply<InboxMessageHasReadEvent>,
    IApply<ReplyToMessageEvent>,
    IApply<ReplyToMessageStartedEvent>,
    IApply<MessageViewsIncrementedEvent>,
    IApply<DeleteMessagesStartedEvent>,
    IApply<UpdatePinnedMessageStartedEvent>,
    IApply<InboxMessagePinnedUpdatedEvent>,
    IApply<OutboxMessagePinnedUpdatedEvent>,
    IApply<OtherPartyMessageDeletedEvent>,
    IApply<ForwardMessageStartedEvent>,
    IApply<SelfMessageDeletedEvent>,
    IApply<OutboxMessageDeletedEvent>,
    IApply<InboxMessageDeletedEvent>

{
    public MessageItem MessageItem { get; private set; } = null!;
    public List<InboxItem> InboxItems { get; private set; } = new();
    public int SenderMessageId { get; private set; }

    public bool Pinned { get; private set; }
    public bool PmOneSide { get; private set; }
    public int EditDate { get; private set; }
    public bool Edited { get; private set; }
    public int Pts { get; private set; }

    public IReadOnlyCollection<Peer> RecentRepliers { get; private set; } =
        new List<Peer>(MyTelegramServerDomainConsts.MaxRecentRepliersCount);

    public void Apply(DeleteMessagesStartedEvent aggregateEvent)
    {
        //throw new NotImplementedException();
    }

    public void Apply(ForwardMessageStartedEvent aggregateEvent)
    {
        //throw new NotImplementedException();
    }

    public void Apply(InboxMessageCreatedEvent aggregateEvent)
    {
        MessageItem = aggregateEvent.InboxMessageItem;
        SenderMessageId = aggregateEvent.SenderMessageId;
    }

    public void Apply(InboxMessageDeletedEvent aggregateEvent)
    {
    }

    public void Apply(InboxMessageEditedEvent aggregateEvent)
    {
        EditDate = aggregateEvent.EditDate;
        Edited = true;
    }

    public void Apply(InboxMessageHasReadEvent aggregateEvent)
    {
        //throw new NotImplementedException();
    }

    public void Apply(InboxMessageIdAddedToOutboxMessageEvent aggregateEvent)
    {
        InboxItems.Add(aggregateEvent.InboxItem);
    }

    public void Apply(InboxMessagePinnedUpdatedEvent aggregateEvent)
    {
        Pinned = aggregateEvent.Pinned;
        //PmOneSide = false;
    }

    public void Apply(MessageDeletedEvent aggregateEvent)
    {
        //throw new NotImplementedException();
    }

    public void Apply(MessageForwardedEvent aggregateEvent)
    {
        //throw new NotImplementedException();
    }

    public void Apply(MessageViewsIncrementedEvent aggregateEvent)
    {
        MessageItem.Views++;
    }

    public void Apply(OtherPartyMessageDeletedEvent aggregateEvent)
    {
        //throw new NotImplementedException();
    }
    //public void LoadSnapshot(MessageSnapshot snapshot)
    //{
    //    MessageItem = snapshot.MessageItem;
    //    InboxItems = snapshot.InboxItems;
    //    SenderMessageId = snapshot.SenderMessageId;
    //    Pinned = snapshot.Pinned;
    //    Pts = snapshot.Pts;
    //    PmOneSide = snapshot.PmOneSide;
    //}

    //public MessageItem InMessageItem { get; private set; }
    public void Apply(OutboxMessageCreatedEvent aggregateEvent)
    {
        MessageItem = aggregateEvent.OutboxMessageItem;
        SenderMessageId = aggregateEvent.OutboxMessageItem.MessageId;
    }

    public void Apply(OutboxMessageDeletedEvent aggregateEvent)
    {
    }

    public void Apply(OutboxMessageEditedEvent aggregateEvent)
    {
        EditDate = aggregateEvent.EditDate;
        Edited = true;
    }

    public void Apply(OutboxMessagePinnedUpdatedEvent aggregateEvent)
    {
        Pinned = aggregateEvent.Pinned;
        //PmOneSide = false;
    }

    public void Apply(ReplyToMessageEvent aggregateEvent)
    {
        //throw new NotImplementedException();
    }

    public void Apply(ReplyToMessageStartedEvent aggregateEvent)
    {
        RecentRepliers = aggregateEvent.RecentRepliers;
        //throw new NotImplementedException();
    }

    public void Apply(SelfMessageDeletedEvent aggregateEvent)
    {
    }

    public void Apply(SendMessageStartedEvent aggregateEvent)
    {
        MessageItem = aggregateEvent.OutMessageItem;
        SenderMessageId = aggregateEvent.OutMessageItem.MessageId;
        //throw new NotImplementedException();
    }

    public void Apply(UpdatePinnedMessageStartedEvent aggregateEvent)
    {
        Pinned = aggregateEvent.Pinned;
        PmOneSide = aggregateEvent.PmOneSide;
    }

    public void LoadSnapshot(MessageSnapshot snapshot)
    {
        MessageItem = snapshot.MessageItem;
        InboxItems = snapshot.InboxItems;
        SenderMessageId = snapshot.SenderMessageId;
        Pinned = snapshot.Pinned;
        EditDate = snapshot.EditDate;
        Edited = snapshot.Edited;
        Pts = snapshot.Pts;
        RecentRepliers = snapshot.RecentRepliers;
    }
}
