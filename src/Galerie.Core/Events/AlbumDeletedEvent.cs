namespace Galerie.Core.Events;

public class AlbumDeletedEvent(Album album) : EventBase
{
    public Album Album { get; } = album;
}