using Galerie.Core.Events;
using Microsoft.Extensions.Logging;

namespace Galerie.Application.Photos.EventHandlers;

public class PhotoUploadedEventHandler(ILogger<PhotoUploadedEventHandler> logger) : INotificationHandler<PhotoUploadedEvent>
{
    public Task Handle(PhotoUploadedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Galerie Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}