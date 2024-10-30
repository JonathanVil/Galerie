using Galerie.Application.Albums.Queries.GetAlbum;
using Galerie.Application.Common.Security;
using Galerie.Core.Constants;

namespace Galerie.Application.Albums.Queries.GetUserAlbums;

[Authorize(Roles = Roles.Administrator)]
public record GetUserAlbumsQuery : IRequest<IEnumerable<AlbumDto>>;

public class GetUserAlbumsQueryValidator : AbstractValidator<GetUserAlbumsQuery>
{
    public GetUserAlbumsQueryValidator()
    {
    }
}

public class GetUserAlbumsQueryHandler : IRequestHandler<GetUserAlbumsQuery, IEnumerable<AlbumDto>>
{

    public Task<IEnumerable<AlbumDto>> Handle(GetUserAlbumsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}