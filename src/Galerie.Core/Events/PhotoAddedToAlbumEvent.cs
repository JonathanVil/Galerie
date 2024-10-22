namespace Galerie.Core.Events;

public class PhotoAddedToAlbumEvent(Photo photo, Album album) : EventBase
{
    public Photo Photo { get; } = photo;
    public Album Album { get; } = album;
}