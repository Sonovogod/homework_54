using MobileStore.DataObjects;
using MobileStore.Services.Abstractions;

namespace MobileStore.Services;

public class FileService : IFileService
{
    private readonly IHostEnvironment _hostEnvironment;
    public FileService(IHostEnvironment hostEnvironment)
    {
        _hostEnvironment = hostEnvironment;
    }

    public FileDataObject Download(string filename)
    {
        var contentRootPAth = _hostEnvironment.ContentRootPath;
        var filePath = @$"{contentRootPAth}/PhoneFiles/{filename}";
        if (!File.Exists(filePath))
            throw new Exception("Файл не найден");
        var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        return new FileDataObject
        {
            Path = filePath,
            FileType = "text/plain",
            FileStream = fileStream
        };
    }

    public void Upload(string fileName)
    {
        var path = Path.Combine(_hostEnvironment.ContentRootPath, $"PhoneFiles/{fileName}");
        string directoryPath = Path.Combine(_hostEnvironment.ContentRootPath, "PhoneFiles");
        if (!Directory.Exists(directoryPath))
            Directory.CreateDirectory(directoryPath);
        var stream = File.Create(path);
        stream.Close();
        File.WriteAllText(path, "Content");
    }

    public void Remove(string filename)
    {
        var contentRootPAth = _hostEnvironment.ContentRootPath;
        var filePath = @$"{contentRootPAth}/PhoneFiles/{filename}";
        if (!File.Exists(filePath))
            throw new Exception("Файл не найден");
        File.Delete(filePath);
    }
}