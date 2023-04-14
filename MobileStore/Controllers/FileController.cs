using Microsoft.AspNetCore.Mvc;
using MobileStore.DataObjects;
using MobileStore.Services.Abstractions;

namespace MobileStore.Controllers;

public class FileController : Controller
{
    private readonly IFileService _fileService;
    private readonly IPhoneService _phoneService;

    public FileController(IFileService fileService, IPhoneService phoneService)
    {
        _fileService = fileService;
        _phoneService = phoneService;
    }

    [HttpGet]
    public IActionResult GetFile(int id)
    {
        var phone = _phoneService.GetById(id);
        if (phone is null) return NotFound();
        var filename = $"{phone.Brand.Name}_{phone.Title}.txt";
        FileDataObject fileData = _fileService.Download(filename);
        
        return File(fileData.FileStream, fileData.FileType, filename);
    }
}