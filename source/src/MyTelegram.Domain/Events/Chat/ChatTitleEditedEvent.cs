﻿namespace MyTelegram.Domain.Events.Chat;

public class ChatTitleEditedEvent : RequestAggregateEvent2<ChatAggregate, ChatId>, IHasCorrelationId
{
    public ChatTitleEditedEvent(RequestInfo requestInfo,
        long chatId,
        string title,
        string messageActionData,
        long randomId,
        Guid correlationId) : base(requestInfo)
    {
        ChatId = chatId;
        Title = title;
        MessageActionData = messageActionData;
        RandomId = randomId;
        CorrelationId = correlationId;
    }

    public long ChatId { get; }
    public string MessageActionData { get; }
    public long RandomId { get; }
    public string Title { get; }
    public Guid CorrelationId { get; }
}
