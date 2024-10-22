using Galerie.Core.Events;
using Microsoft.Extensions.Logging;

namespace Galerie.Application.Albums.EventHandlers;

public class PhotoAddedToAlbumEventHandler(ILogger<PhotoAddedToAlbumEventHandler> logger) : INotificationHandler<PhotoAddedToAlbumEvent>
{
    public Task Handle(PhotoAddedToAlbumEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Galerie Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}