namespace Galerie.Application.Photos.Commands;

public record DeletePhotoCommand(Guid Id) : IRequest;

public class DeletePhotoCommandValidator : AbstractValidator<DeletePhotoCommand>
{
    public DeletePhotoCommandValidator()
    {
        RuleFor(v => v.Id)
            .NotEmpty();
    }
}

public class DeletePhotoCommandHandler : IRequestHandler<DeletePhotoCommand>
{

    public async Task Handle(DeletePhotoCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}