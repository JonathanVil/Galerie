using Galerie.Core.Events;
using Microsoft.Extensions.Logging;

namespace Galerie.Application.Albums.EventHandlers;

public class AlbumDeletedEventHandler(ILogger<AlbumDeletedEventHandler> logger) : INotificationHandler<AlbumDeletedEvent> 
{
    public Task Handle(AlbumDeletedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Galerie Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}