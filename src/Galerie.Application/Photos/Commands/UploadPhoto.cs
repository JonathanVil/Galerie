namespace Galerie.Application.Photos.Commands;

public record UploadPhotoCommand(Stream File, string Title) : IRequest<Guid>;

public class UploadPhotoCommandValidator : AbstractValidator<UploadPhotoCommand>
{
    public UploadPhotoCommandValidator()
    {
        RuleFor(v => v.File)
            .NotNull()
            .WithMessage("File is required.");

        RuleFor(v => v.Title)
            .MaximumLength(200)
            .NotEmpty();
    }
}

public class UploadPhotoCommandHandler : IRequestHandler<UploadPhotoCommand, Guid>
{
    public async Task<Guid> Handle(UploadPhotoCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}