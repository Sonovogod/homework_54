using Microsoft.AspNetCore.Mvc;
using MobileStore.Models;
using MobileStore.Services.Abstractions;
using MobileStore.ViewModels;

namespace MobileStore.Controllers;

public class PhonesController : Controller
{
    private readonly IPhoneService _phoneService;
    private readonly IFileService _fileService;
    private readonly IBrandService _brandService;
    
    public PhonesController(
        IPhoneService phoneService, 
        IFileService fileService, 
        IBrandService brandService)
    {
        _phoneService = phoneService;
        _fileService = fileService;
        _brandService = brandService;
    }

    [HttpGet]
    public IActionResult Phones()
    {
        var phones = _phoneService.GetAll();
        PhonesPageViewModel model = new PhonesPageViewModel
        {
            Phones = phones,
            SearchOptions = new PhoneSearchViewModel()
        };
        return View(model);
    }

    [HttpGet]
    public IActionResult Create()
    {
        CreatePhonePageViewModel model = new CreatePhonePageViewModel
        {
            Brands = _brandService.GetAll()
        };
        return View(model);
    }

    [HttpPost]
    public IActionResult Create(CreatePhonePageViewModel? model)
    {
        if (ModelState.IsValid)
        {
            _fileService.Upload($"{model.Phone.BrandName}_{model.Phone.Title}.txt");
            _phoneService.Create(model.Phone);
            return RedirectToAction("Phones");
        }

        model.Brands = _brandService.GetAll();
        return View("Create", model);
    }

    [HttpGet]
    public IActionResult About(int id)
    {
        Phone? phone = _phoneService.GetById(id);
        if (phone is null)
            return NotFound();
        PhoneViewModel viewModel = new PhoneViewModel
        {
            Id = phone.Id,
            BrandId = phone.Brand.Id,
            BrandName = phone.Brand.Name
        };
        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        try
        {
            _phoneService.DeleteById(id);
            return RedirectToAction("Phones");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpGet]
    public IActionResult ConfirmDelete(int id)
    {
        return View(id);
    }

    [HttpGet]
    public IActionResult SearchPhones(PhonesPageViewModel viewModel)
    {
        var phones = string.IsNullOrEmpty(viewModel.SearchOptions.Filter)
            ?_phoneService.GetAll()
            : _phoneService.SearchByFilter(viewModel.SearchOptions);
        PhonesPageViewModel model = new PhonesPageViewModel
        {
            Phones = phones,
            SearchOptions = new PhoneSearchViewModel()
        };
        return View("Phones", model);
    }
}