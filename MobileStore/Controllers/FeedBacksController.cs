using Microsoft.AspNetCore.Mvc;
using MobileStore.Extensions;
using MobileStore.Models;
using MobileStore.Services.Abstractions;
using MobileStore.ViewModels;

namespace MobileStore.Controllers;

public class FeedBacksController : Controller
{
    private readonly IPhoneService _phoneService;
    private readonly  IFeedBackService _feedBackService;

    public FeedBacksController(IPhoneService phoneService, IFeedBackService feedBackService)
    {
        _phoneService = phoneService;
        _feedBackService = feedBackService;
    }

    [HttpGet]
    public IActionResult CreateReview(int id)
    {
        var phone = _phoneService.GetById(id);
        if (id == 0 || phone == null) return NotFound();
        
        FeedBackViewModel feedBackViewModel = new FeedBackViewModel()
        {
            PhoneId = phone.Id
        };
        return View(feedBackViewModel);
    }
    
    [HttpPost]
    public IActionResult CreateReview(FeedBackViewModel feedBackViewModel)
    {
        if (ModelState.IsValid)
        {
            FeedBack feedBack = FeedBackExtension.MapToFeedBackModel(feedBackViewModel);
            _feedBackService.Add(feedBack);
            return RedirectToAction("About", "Phones", new {id = feedBack.PhoneId});
        }
       
        return RedirectToAction("CreateReview", new {id = feedBackViewModel.PhoneId});
    }
}