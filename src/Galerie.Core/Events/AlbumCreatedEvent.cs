namespace Galerie.Core.Events;

public class AlbumCreatedEvent(Album album) : EventBase
{
    public Album Album { get; } = album;
}