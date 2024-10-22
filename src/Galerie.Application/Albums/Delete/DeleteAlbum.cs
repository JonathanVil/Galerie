namespace Galerie.Application.Albums.Delete;

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
    public Task Handle(DeleteAlbumCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}