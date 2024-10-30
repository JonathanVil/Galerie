namespace Galerie.Application.Albums.Queries.GetAlbum;

public record GetAlbumQuery(Guid AlbumId) : IRequest<AlbumDto>;

public class GetAlbumQueryValidator : AbstractValidator<GetAlbumQuery>
{
    public GetAlbumQueryValidator()
    {
        RuleFor(v => v.AlbumId)
            .NotEmpty();
    }
}

public class GetAlbumQueryHandler : IRequestHandler<GetAlbumQuery, AlbumDto>
{
    public async Task<AlbumDto> Handle(GetAlbumQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}