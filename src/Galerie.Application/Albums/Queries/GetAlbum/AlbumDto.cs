using AutoMapper;
using Galerie.Core.Entities;

namespace Galerie.Application.Albums.Queries.GetAlbum;

public record AlbumDto(Guid Id, string Title, string? Description, string CoverUrl, int NumberOfPhotos)
{
    IReadOnlyCollection<PhotoDto> Photos { get; init; } = Array.Empty<PhotoDto>();
    
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Album, AlbumDto>();
        }
    }
}