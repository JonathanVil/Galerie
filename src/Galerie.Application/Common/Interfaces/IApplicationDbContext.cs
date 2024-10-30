using Galerie.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Galerie.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Album> Albums { get; }
    
    DbSet<Photo> Photos { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
