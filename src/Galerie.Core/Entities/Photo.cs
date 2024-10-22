﻿using Ardalis.GuardClauses;
using Galerie.Core.Common;

namespace Galerie.Core.Entities;

public class Photo(string title, string fileName) : EntityBase
{
    public string Title { get; set; } = Guard.Against.NullOrEmpty(title, nameof(title));
    public string? Description { get; set; }
    public string FileName { get; set; } = Guard.Against.NullOrEmpty(fileName, nameof(fileName));
    
    public IList<Album> Albums { get; set; } = new List<Album>();
}