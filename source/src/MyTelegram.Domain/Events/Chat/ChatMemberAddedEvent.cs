﻿namespace MyTelegram.Domain.Events.Chat;

public class ChatMemberAddedEvent : RequestAggregateEvent2<ChatAggregate, ChatId>, IHasCorrelationId
{
    public ChatMemberAddedEvent(RequestInfo requestInfo,
        long chatId,
        ChatMember chatMember,
        string messageActionData,
        long randomId,
        Guid correlationId) : base(requestInfo)
    {
        ChatId = chatId;
        ChatMember = chatMember;
        MessageActionData = messageActionData;
        RandomId = randomId;
        CorrelationId = correlationId;
    }

    public long ChatId { get; }
    public ChatMember ChatMember { get; }
    public string MessageActionData { get; }
    public long RandomId { get; }
    public Guid CorrelationId { get; }
}
