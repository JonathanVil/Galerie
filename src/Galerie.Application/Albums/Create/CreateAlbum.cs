namespace Galerie.Application.Albums.Create;

public record CreateAlbumCommand(string Title) : IRequest<Guid>;

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
    public Task<Guid> Handle(CreateAlbumCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}