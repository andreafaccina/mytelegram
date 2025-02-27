﻿namespace MyTelegram.Domain.Commands.Messaging;

public class EditOutboxMessageCommand : RequestCommand2<MessageAggregate, MessageId, IExecutionResult>
{
    public EditOutboxMessageCommand(MessageId aggregateId,
        RequestInfo requestInfo,
        int messageId,
        string newMessage,
        byte[]? entities,
        int editDate,
        byte[]? media,
        Guid correlationId) : base(aggregateId, requestInfo)
    {
        MessageId = messageId;
        NewMessage = newMessage;
        Entities = entities;
        EditDate = editDate;
        Media = media;
        CorrelationId = correlationId;
    }

    public int MessageId { get; }
    public string NewMessage { get; }
    public byte[]? Entities { get; }
    public int EditDate { get; }
    public byte[]? Media { get; }
    public Guid CorrelationId { get; }
}
