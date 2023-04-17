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
        CreateFeedBackViewModel createFeedBackViewModel = new CreateFeedBackViewModel()
        {
            ShortPhoneViewModel = new ShortPhoneViewModel()
            {
                Id = phone.Id,
                Title = phone.Title
            }
        };

        return View(createFeedBackViewModel);
    }
    
    [HttpPost]
    public IActionResult CreateReview(CreateFeedBackViewModel createFeedBackViewModel)
    {
        if (ModelState.IsValid)
        {
            FeedBack feedBack = FeedBackExtension.MapToFeedBackModel(createFeedBackViewModel.FeedBackViewModel);
            _feedBackService.Add(feedBack);
            return RedirectToAction("About", "Phones", new {id = feedBack.PhoneId});
        }
       
        return RedirectToAction("CreateReview", new {id = createFeedBackViewModel.FeedBackViewModel.PhoneId});
    }
}