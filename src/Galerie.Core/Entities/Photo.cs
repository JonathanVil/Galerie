using Ardalis.GuardClauses;

namespace Galerie.Core.Entities;

public class Photo(string title, string url) : EntityBase
{
    public string Title { get; set; } = Guard.Against.NullOrEmpty(title, nameof(title));
    public string? Description { get; set; }
    public string Url { get; set; } = Guard.Against.NullOrEmpty(url, nameof(url));
    
    public IList<Album> Albums { get; set; } = new List<Album>();
}