using backend.Interfaces;

namespace backend.Services;

public class LocalProductImageService : IProductImageService
{

    private readonly IConfiguration _config;
    private readonly string _projectRoot;

    public LocalProductImageService(IWebHostEnvironment env, IConfiguration config)
    {
        _config = config;
        _projectRoot = env.ContentRootPath;
    }

    public string GetImagePath(string filename)
    {
        string contentPath = _config["ContentRootPath"] ?? "/Pics";
        string path = GetFullImagePath(contentPath, filename);
        return path;
    }

    public async Task<string> UploadImage(IFormFile file)
    {
        string uploadPath = _config["ContentRootPath"] ?? "/Pics";
        uploadPath = uploadPath.TrimStart('/').TrimStart('\\');
        string fullPath = Path.Combine(_projectRoot, uploadPath);
        string filePath = Path.Combine(fullPath , Path.GetFileName(file.FileName));
        using (var stream = System.IO.File.Create(filePath))
        {
            // This overwrites file with matching name if it exists
            await file.CopyToAsync(stream);
        }
        return filePath;
    }

    private string GetFullImagePath(string contentRootPath, string filename)
    {
        if (string.IsNullOrWhiteSpace(filename))
        {
            throw new ArgumentException("Filename cannot be null or empty.", nameof(filename));
        }
        return $"{contentRootPath.TrimEnd('/')}/{filename}";
    }
}