using Microsoft.AspNetCore.Mvc;
using MobileStore.Services.Abstractions;
using MobileStore.ViewModels;

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
    
    [HttpGet]
    public IActionResult Create()
    {
        CreateBrandViewModel createBrandViewModel = GetBrands();
        
        return View(createBrandViewModel);
    }

    [HttpPost]
    public IActionResult Create(CreateBrandViewModel createBrandViewModel)
    {
        if (ModelState.IsValid)
        {
            _brandService.Add(createBrandViewModel);
            return RedirectToAction("Create");
        }
        createBrandViewModel = GetBrands();
        return View(createBrandViewModel);
    }
    
    private CreateBrandViewModel GetBrands()
    {
        List<ShortBrandViewModel> brands = _brandService.GetAll();
        List<BrandViewModel> brandViewModels = brands.Select(brand => new BrandViewModel { Id = brand.Id, Name = brand.Name }).ToList();
        CreateBrandViewModel createBrandViewModel = new CreateBrandViewModel()
        {
            Brands = brandViewModels
        };
        
        return createBrandViewModel;
    }
}