using Microsoft.AspNetCore.Mvc;
using MobileStore.Extensions;
using MobileStore.Models;
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
            Brand brand = BrandExtension.MapToBrandModel(createBrandViewModel);
            _brandService.Add(brand);
            return RedirectToAction("Create");
        }
        createBrandViewModel = GetBrands();
        return View(createBrandViewModel);
    }
    
    [HttpGet]
    public IActionResult Delete(int id)
    {
        Brand? brand = _brandService.GetById(id);
        if (brand == null)
            return NotFound();
        
        _brandService.Delete(brand.Id);
        return RedirectToAction("Create");
    }
    
    [HttpGet]
    public IActionResult Edit(int id)
    {
        Brand? brand = _brandService.GetById(id);
        if (brand == null)
            return NotFound();

        CreateBrandViewModel createBrandViewModel = BrandExtension.MapToCreateBrandViewModel(brand);
        return View(createBrandViewModel);
    }
    
    [HttpPost]
    public IActionResult Edit(CreateBrandViewModel createBrandViewModel)
    {
        if (ModelState.IsValid)
        {
            Brand brand = BrandExtension.MapToBrandModel(createBrandViewModel);
            _brandService.Edit(brand);
            return RedirectToAction("Create");
        }

        return View("Edit", createBrandViewModel);
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