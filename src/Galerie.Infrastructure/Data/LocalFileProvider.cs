using Galerie.Application.Common.Interfaces;
using Microsoft.Extensions.Options;

namespace Galerie.Infrastructure.Data;

using System;
using System.IO;
using System.Threading.Tasks;

public class LocalFileProvider : IFileProvider
{
    private readonly string _rootPath;
    private readonly long _maxFileSize;

    public LocalFileProvider(IOptions<LocalFileOptions> options)
    {
        _rootPath = options.Value.RootPath ?? throw new ArgumentNullException(nameof(options.Value.RootPath));
        _maxFileSize = options.Value.MaxFileSize;
    }

    public string GetBasePath()
    {
        return _rootPath;
    }

    public async Task<string> SaveFileAsync(Stream fileStream, string fileName, string folderName)
    {
        try
        {
            // Ensure the folder exists
            var folderPath = Path.Combine(_rootPath, folderName);
            Directory.CreateDirectory(folderPath);

            // Define the full file path
            var filePath = Path.Combine(folderPath, fileName);

            // Save the file to the local file system
            await using var outputFileStream = new FileStream(filePath, FileMode.Create);
            await fileStream.CopyToAsync(outputFileStream);

            // Return the file path (without first folder of the root path)
            return filePath.Substring(_rootPath.IndexOf(Path.DirectorySeparatorChar) + 1);
        }
        catch (Exception ex)
        {
            // Handle exceptions as needed
            throw new InvalidOperationException("Error saving the file", ex);
        }
    }

    public Task<bool> DeleteFileAsync(string fileName, string folderName)
    {
        try
        {
            // Define the file path
            var filePath = Path.Combine(_rootPath, folderName, fileName);

            // Delete the file from the local file system if it exists
            if (!File.Exists(filePath)) return Task.FromResult(false);
            File.Delete(filePath);
            return Task.FromResult(true);

        }
        catch (Exception ex)
        {
            // Handle exceptions as needed
            throw new InvalidOperationException("Error deleting the file", ex);
        }
    }
}

public class LocalFileOptions
{
    public string RootPath { get; set; }
    public long MaxFileSize { get; set; } = 10 * 1024 * 1024; // 10 MB
}