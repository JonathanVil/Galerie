using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using Galerie.Application.Common.Interfaces;
using Galerie.Application.Common.Security;
using Galerie.Core.Entities;

namespace Galerie.Application.Photos.Commands;

[Authorize]
public record UploadPhotoCommand(Stream File, string FileName, string Title) : IRequest<Guid>;

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
     
        // TODO: Add validation for file type
    }
}

public class UploadPhotoCommandHandler : IRequestHandler<UploadPhotoCommand, Guid>
{
    private readonly IApplicationDbContext _context;
    private readonly IFileProvider _fileProvider;
    private readonly Guid _userId;

    public UploadPhotoCommandHandler(IApplicationDbContext context, IUser user, IFileProvider fileProvider)
    {
        _context = context;
        _fileProvider = fileProvider;
        _userId = Guard.Against.Null(user.Id);
    }
    
    public async Task<Guid> Handle(UploadPhotoCommand request, CancellationToken cancellationToken)
    {
        var fileExtension = Path.GetExtension(request.FileName);
        var fileName = Guid.NewGuid() + fileExtension;
        var folderName = _userId.ToString();
        var filePath = await _fileProvider.SaveFileAsync(request.File, fileName, folderName);

        var photo = new Photo(_userId, request.Title, filePath.ToString());
        _context.Photos.Add(photo);

        await _context.SaveChangesAsync(cancellationToken);

        return photo.Id;
    }
}