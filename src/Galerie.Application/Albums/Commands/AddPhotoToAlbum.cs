using Ardalis.GuardClauses;
using Galerie.Application.Common.Exceptions;
using Galerie.Application.Common.Interfaces;
using Galerie.Application.Common.Security;

namespace Galerie.Application.Albums.Commands;

[Authorize]
public record AddPhotoToAlbumCommand(Guid AlbumId, Guid PhotoId) : IRequest;

public class AddPhotoToAlbumCommandValidator : AbstractValidator<AddPhotoToAlbumCommand>
{
    public AddPhotoToAlbumCommandValidator()
    {
        RuleFor(v => v.AlbumId)
            .NotEmpty();
        RuleFor(v => v.PhotoId)
            .NotEmpty();
    }
}

public class AddPhotoToAlbumCommandHandler : IRequestHandler<AddPhotoToAlbumCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly Guid _userId;

    public AddPhotoToAlbumCommandHandler(IApplicationDbContext context, IUser user)
    {
        _context = context;
        _userId = Guard.Against.NullOrEmpty(user.Id);
    }
    
    public async Task Handle(AddPhotoToAlbumCommand request, CancellationToken cancellationToken)
    {
        var album = await _context.Albums.FindAsync(request.AlbumId, cancellationToken);
        Guard.Against.Null(album, nameof(album));
        if (album.UserId != _userId)
        {
            throw new ForbiddenAccessException();
        }
        
        var photo = await _context.Photos.FindAsync(request.PhotoId, cancellationToken);
        Guard.Against.Null(photo, nameof(photo));
        if (photo.UserId != _userId)
        {
            throw new ForbiddenAccessException();
        }
        
        album.Photos.Add(photo);

        await _context.SaveChangesAsync(cancellationToken);
    }
}