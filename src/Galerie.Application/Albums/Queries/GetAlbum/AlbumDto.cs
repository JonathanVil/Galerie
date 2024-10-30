using Galerie.Core.Entities;

namespace Galerie.Application.Albums.Queries.GetAlbum;

public record AlbumDto
{
    public IReadOnlyCollection<PhotoDto> Photos { get; init; } = Array.Empty<PhotoDto>();
    public Guid Id { get; init; }
    public string Title { get; init; } = string.Empty;
    public string? Description { get; init; }
    public string? CoverUrl { get; init; }
    public int NumberOfPhotos { get; init; }
    public DateTimeOffset Created { get; init; }
    public DateTimeOffset LastModified { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Album, AlbumDto>()
                .ForMember(a => a.NumberOfPhotos, opt => opt.MapFrom(s => s.Photos.Count))
                .ForMember(a => a.CoverUrl, opt => opt.MapFrom(s => s.CoverPhoto != null ? s.CoverPhoto.Url : null));
        }
    }
}