﻿namespace MyTelegram.Domain.Sagas.Events;

public class
    DeleteParticipantHistorySagaStartedEvent : AggregateEvent<DeleteParticipantHistorySaga,
        DeleteParticipantHistorySagaId>
{
    public RequestInfo RequestInfo { get; }
    public long OwnerPeerId { get; }
    public List<int> MessageIds { get; }

    public DeleteParticipantHistorySagaStartedEvent(RequestInfo requestInfo, long ownerPeerId, List<int> messageIds)
    {
        RequestInfo = requestInfo;
        OwnerPeerId = ownerPeerId;
        MessageIds = messageIds;
    }
}