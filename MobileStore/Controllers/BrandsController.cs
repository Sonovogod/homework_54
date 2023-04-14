using Microsoft.AspNetCore.Mvc;
using MobileStore.Services.Abstractions;

namespace MobileStore.Controllers;

public class BrandsController : Controller
{
    private readonly IBrandService _brandService;

    public BrandsController(IBrandService brandService)
    {
        _brandService = brandService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return View(_brandService.GetAll());
    }
}