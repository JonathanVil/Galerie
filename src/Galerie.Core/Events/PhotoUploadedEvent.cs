namespace Galerie.Core.Events;

public class PhotoUploadedEvent(Photo photo) : EventBase
{
    public Photo Photo { get; } = photo;
}