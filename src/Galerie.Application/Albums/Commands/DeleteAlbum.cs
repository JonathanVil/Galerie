using Ardalis.GuardClauses;
using Galerie.Application.Common.Exceptions;
using Galerie.Application.Common.Interfaces;

namespace Galerie.Application.Albums.Commands;

public record DeleteAlbumCommand(Guid Id) : IRequest;

public class DeleteAlbumCommandValidator : AbstractValidator<DeleteAlbumCommand>
{
    public DeleteAlbumCommandValidator()
    {
        RuleFor(v => v.Id)
            .NotEmpty();
    }
}

public class DeleteAlbumCommandHandler : IRequestHandler<DeleteAlbumCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly Guid _userId;

    public DeleteAlbumCommandHandler(IApplicationDbContext context, IUser user)
    {
        _context = context;
        _userId = Guard.Against.Null(user.Id);
    }
    
    public async Task Handle(DeleteAlbumCommand request, CancellationToken cancellationToken)
    {
        var album = await _context.Albums.FindAsync(request.Id, cancellationToken);

        if (album == null)
        {
            throw new NotFoundException(nameof(request.Id), request.Id.ToString());
        }

        if (album.UserId != _userId)
        {
            throw new ForbiddenAccessException();
        }

        _context.Albums.Remove(album);

        await _context.SaveChangesAsync(cancellationToken);
    }
}