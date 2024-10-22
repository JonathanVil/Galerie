namespace Galerie.Application.Albums.Queries.GetAlbum;

public record GetAlbumCommand(Guid AlbumId) : IRequest<AlbumDto>;

public class GetAlbumCommandValidator : AbstractValidator<GetAlbumCommand>
{
    public GetAlbumCommandValidator()
    {
        RuleFor(v => v.AlbumId)
            .NotEmpty();
    }
}

public class GetAlbumCommandHandler : IRequestHandler<GetAlbumCommand, AlbumDto>
{
    public async Task<AlbumDto> Handle(GetAlbumCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}