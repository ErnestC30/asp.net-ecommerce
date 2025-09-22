namespace backend.Interfaces;

public interface IProductImageService
{
    public string GetImagePath(string filename);
    public Task<string> UploadImage(IFormFile file);
}