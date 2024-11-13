using Ardalis.GuardClauses;
using AutoMapper.QueryableExtensions;
using Galerie.Application.Albums.Queries.GetAlbum;
using Galerie.Application.Common.Interfaces;
using Galerie.Application.Common.Security;
using Microsoft.EntityFrameworkCore;

namespace Galerie.Application.Photos.Queries.GetUserPhotos;

[Authorize]
public record GetMyPhotosQuery : IRequest<IReadOnlyCollection<PhotoDto>>;

public class GetMyPhotosQueryValidator : AbstractValidator<GetMyPhotosQuery>
{
    public GetMyPhotosQueryValidator()
    {
    }
}

public class GetMyPhotosQueryHandler : IRequestHandler<GetMyPhotosQuery, IReadOnlyCollection<PhotoDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly Guid _userId;

    public GetMyPhotosQueryHandler(IApplicationDbContext context, IMapper mapper, IUser user)
    {
        _context = context;
        _mapper = mapper;
        _userId = Guard.Against.Null(user.Id);
    }

    public async Task<IReadOnlyCollection<PhotoDto>> Handle(GetMyPhotosQuery request, CancellationToken cancellationToken)
    {
        return await _context.Photos
            .AsNoTracking()
            .Where(p => p.UserId == _userId)
            .ProjectTo<PhotoDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}