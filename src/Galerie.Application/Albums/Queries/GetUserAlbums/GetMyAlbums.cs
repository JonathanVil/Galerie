using Ardalis.GuardClauses;
using AutoMapper.QueryableExtensions;
using Galerie.Application.Albums.Queries.GetAlbum;
using Galerie.Application.Common.Interfaces;
using Galerie.Application.Common.Security;
using Microsoft.EntityFrameworkCore;

namespace Galerie.Application.Albums.Queries.GetUserAlbums;

[Authorize]
public record GetMyAlbumsQuery : IRequest<IReadOnlyCollection<AlbumDto>>;

public class GetMyAlbumsQueryValidator : AbstractValidator<GetMyAlbumsQuery>
{
    public GetMyAlbumsQueryValidator()
    {
    }
}

public class GetMyAlbumsQueryHandler : IRequestHandler<GetMyAlbumsQuery, IReadOnlyCollection<AlbumDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly Guid _userId;

    public GetMyAlbumsQueryHandler(IApplicationDbContext context, IMapper mapper, IUser user)
    {
        _context = context;
        _mapper = mapper;
        _userId = Guard.Against.Null(user.Id);
    }

    public async Task<IReadOnlyCollection<AlbumDto>> Handle(GetMyAlbumsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Albums
            .AsNoTracking()
            .Where(a => a.UserId == _userId)
            .ProjectTo<AlbumDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}