using Microsoft.AspNetCore.Mvc;
using MobileStore.Extensions;
using MobileStore.Models;
using MobileStore.Services.Abstractions;
using MobileStore.ViewModels;

namespace MobileStore.Controllers;

public class OrdersController : Controller
{
    private readonly IPhoneService _phoneService;
    private readonly IOrderService _orderService;

    
    public OrdersController(
        IPhoneService phoneService, 
        IOrderService orderService)
    {
        _phoneService = phoneService;
        _orderService = orderService;
    }
    
    public IActionResult Orders()
    {
        List<Order> orders = _orderService.GetAll();
        
        return View(orders);
    }
    
    [HttpGet]
    public IActionResult Create(int phoneId)
    {
        Phone? phone = _phoneService.GetById(phoneId);
        if (phone is null)
            return NotFound();
        ShortPhoneViewModel shortPhoneViewModel = new ShortPhoneViewModel
        {
            Id = phone.Id,
            Title = phone.Title
        };
        var order = new OrderViewModel { ShortPhone = shortPhoneViewModel };
        
        return View(order);
    }

    [HttpPost]
    public IActionResult Create(OrderViewModel? orderViewModel)
    {
        if (ModelState.IsValid)
        {
            Order order = OrderExtension.MapToOrder(orderViewModel, new Order());
            _orderService.Create(order);
            return RedirectToAction("Orders");
        }
        Phone? phone = _phoneService.GetById(orderViewModel.ShortPhone.Id);
        orderViewModel.ShortPhone = new ShortPhoneViewModel
        {
            Id = phone.Id,
            Title = phone.Title
        };
        return View(orderViewModel);
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        _orderService.Delete(id);
        
        return RedirectToAction("Orders");
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        try
        {
            var order = _orderService.GetById(id);
            return View(order);
        }
        catch (Exception e)
        {
            return RedirectToAction("Orders", new {error = e.Message});
        }
    }

    [HttpPost]
    public IActionResult Edit(OrderViewModel? order)
    {
        if (order is null)
        {
            ViewBag.Error = "Нет данных";
            return RedirectToAction("Orders");
        }
        _orderService.Edit(order);
        
        return RedirectToAction("Orders");
    }
     
     
}