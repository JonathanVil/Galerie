using AutoMapper.QueryableExtensions;
using Galerie.Application.Albums.Queries.GetAlbum;
using Galerie.Application.Common.Interfaces;
using Galerie.Application.Common.Security;
using Microsoft.EntityFrameworkCore;

namespace Galerie.Application.Albums.Queries.GetUserAlbums;

[Authorize]
public record GetMyAlbumsQuery(Guid UserId) : IRequest<IReadOnlyCollection<AlbumDto>>;

public class GetMyAlbumsQueryValidator : AbstractValidator<GetMyAlbumsQuery>
{
    public GetMyAlbumsQueryValidator()
    {
        RuleFor(v => v.UserId)
            .NotEmpty();
    }
}

public class GetMyAlbumsQueryHandler : IRequestHandler<GetMyAlbumsQuery, IReadOnlyCollection<AlbumDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetMyAlbumsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IReadOnlyCollection<AlbumDto>> Handle(GetMyAlbumsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Albums
            .AsNoTracking()
            .Where(a => a.UserId == request.UserId)
            .ProjectTo<AlbumDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}