using AutoMapper;
using Galerie.Core.Entities;

namespace Galerie.Application.Albums.Queries.GetAlbum;

public record PhotoDto(string Title, string? Description, string Url)
{
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Photo, PhotoDto>();
        }
    }
}