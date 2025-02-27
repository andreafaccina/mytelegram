﻿namespace MyTelegram.Domain.Events.Chat;

public class ChatDeletedEvent : RequestAggregateEvent2<ChatAggregate, ChatId>, IHasCorrelationId
{
    public ChatDeletedEvent(RequestInfo requestInfo,
        long chatId,
        string title,
        Guid correlationId) : base(requestInfo)
    {
        ChatId = chatId;
        Title = title;
        CorrelationId = correlationId;
    }

    public long ChatId { get; }
    public string Title { get; }
    public Guid CorrelationId { get; }
}
