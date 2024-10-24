using Ardalis.GuardClauses;

namespace Galerie.Core.Entities;

public class Photo(Guid userId, string title, string url) : EntityBase
{
    /// <summary>
    /// The user who uploaded the photo
    /// </summary>
    public Guid UserId { get; set; } = Guard.Against.Default(userId, nameof(userId));
    
    public string Title { get; set; } = Guard.Against.NullOrEmpty(title, nameof(title));
    public string? Description { get; set; }
    public string Url { get; set; } = Guard.Against.NullOrEmpty(url, nameof(url));
    
    public IList<Album> Albums { get; set; } = new List<Album>();
}