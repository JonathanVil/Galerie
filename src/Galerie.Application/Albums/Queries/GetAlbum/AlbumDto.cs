
using Galerie.Core.Entities;

namespace Galerie.Application.Albums.Queries.GetAlbum;

public record AlbumDto(Guid Id, string Title, string? Description, string? CoverUrl, int NumberOfPhotos)
{
    public IReadOnlyCollection<PhotoDto> Photos { get; init; } = Array.Empty<PhotoDto>();

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Album, AlbumDto>()
                .ForMember(a => a.NumberOfPhotos, opt => opt.MapFrom(s => s.Photos.Count))
                .ForMember(a => a.CoverUrl, opt => opt.MapFrom((s, _) => s.CoverPhoto?.Url));
        }
    }
}