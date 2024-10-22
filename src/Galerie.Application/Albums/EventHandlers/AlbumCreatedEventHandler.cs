using Galerie.Core.Events;
using Microsoft.Extensions.Logging;

namespace Galerie.Application.Albums.EventHandlers;

public class AlbumCreatedEventHandler(ILogger<AlbumCreatedEventHandler> logger) : INotificationHandler<AlbumCreatedEvent>
{
    public Task Handle(AlbumCreatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Galerie Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}