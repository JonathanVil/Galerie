using Ardalis.GuardClauses;

namespace Galerie.Core.Entities;

public class Album(Guid userId, string title) : EntityBase
{
    /// <summary>
    /// The user who owns the album
    /// </summary>
    public Guid UserId { get; set; } = Guard.Against.Default(userId, nameof(userId));
    
    public string Title { get; set; } = Guard.Against.NullOrEmpty(title, nameof(title));
    public string? Description { get; set; }
    public Photo? CoverPhoto { get; set; }
    public IList<Photo> Photos { get; set; } = new List<Photo>();
}