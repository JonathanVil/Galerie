using Ardalis.GuardClauses;
using Galerie.Application.Common.Interfaces;
using Galerie.Application.Common.Security;
using Galerie.Core.Entities;

namespace Galerie.Application.Albums.Commands;

[Authorize]
public class CreateAlbumCommand : IRequest<Guid>
{
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
}

public class CreateAlbumCommandValidator : AbstractValidator<CreateAlbumCommand>
{
    public CreateAlbumCommandValidator()
    {
        RuleFor(v => v.Title)
            .MaximumLength(200)
            .NotEmpty();
    }
}

public class CreateAlbumCommandHandler : IRequestHandler<CreateAlbumCommand, Guid>
{
    private readonly IApplicationDbContext _context;
    private readonly Guid _userId;

    public CreateAlbumCommandHandler(IApplicationDbContext context, IUser user)
    {
        _context = context;
        _userId = Guard.Against.Null(user.Id);
    }

    public async Task<Guid> Handle(CreateAlbumCommand request, CancellationToken cancellationToken)
    {
        var entity = new Album(_userId, request.Title)
        {
            Description = request.Description
        };

        _context.Albums.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}