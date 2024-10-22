namespace Galerie.Application.Albums.Commands;

public record AddPhotoToAlbumCommand(Guid AlbumId, string Title, string Description, string ImageBase64) : IRequest;

public class AddPhotoToAlbumCommandValidator : AbstractValidator<AddPhotoToAlbumCommand>
{
    public AddPhotoToAlbumCommandValidator()
    {
        RuleFor(v => v.AlbumId)
            .NotEmpty();
        RuleFor(v => v.Title)
            .MaximumLength(200)
            .NotEmpty();
        RuleFor(v => v.Description)
            .MaximumLength(1000);
        RuleFor(v => v.ImageBase64)
            .NotEmpty();
    }
}

public class AddPhotoToAlbumCommandHandler : IRequestHandler<AddPhotoToAlbumCommand>
{
    public Task Handle(AddPhotoToAlbumCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}