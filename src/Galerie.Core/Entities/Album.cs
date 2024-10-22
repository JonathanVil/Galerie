using Ardalis.GuardClauses;
using Galerie.Core.Common;

namespace Galerie.Core.Entities;

public class Album(string title) : EntityBase
{
    public string Title { get; set; } = Guard.Against.NullOrEmpty(title, nameof(title));
    public string? Description { get; set; }
    public Photo? CoverPhoto { get; set; }
    public IList<Photo> Photos { get; set; } = new List<Photo>();
}