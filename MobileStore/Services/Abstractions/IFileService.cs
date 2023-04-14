using MobileStore.DataObjects;

namespace MobileStore.Services.Abstractions;

public interface IFileService
{
    FileDataObject Download(string fileName);
    void Upload(string fileName);
    void Remove(string filename);
}