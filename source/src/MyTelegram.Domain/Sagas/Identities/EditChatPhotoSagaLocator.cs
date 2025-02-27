﻿namespace MyTelegram.Domain.Sagas.Identities;

public class EditChatPhotoSagaLocator : ISagaLocator
{
    public Task<ISagaId> LocateSagaAsync(IDomainEvent domainEvent,
        CancellationToken cancellationToken)
    {
        if (domainEvent.GetAggregateEvent() is not IHasCorrelationId id)
        {
            throw new NotSupportedException(
                $"Domain event:{domainEvent.GetAggregateEvent().GetType().FullName} should impl IHasCorrelationId ");
        }

        return Task.FromResult<ISagaId>(new EditChatPhotoSagaId($"editchatphotosaga-{id.CorrelationId}"));
    }
}
