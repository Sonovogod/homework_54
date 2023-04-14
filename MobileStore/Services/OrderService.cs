using Microsoft.EntityFrameworkCore;
using MobileStore.Extensions;
using MobileStore.Models;
using MobileStore.Services.Abstractions;
using MobileStore.ViewModels;

namespace MobileStore.Services;

public class OrderService : IOrderService
{
    private readonly MobileContext _mobileContext;

    public OrderService(MobileContext mobileContext)
    {
        _mobileContext = mobileContext;
    }

    public List<Order> GetAll()
        => _mobileContext.Orders
            .Include(x => x.Phone)
            .ToList();

    public void Create(OrderViewModel? model)
    {
        if (model is null)
            return;
        _mobileContext.Orders.Add(model.MapToOrder(new Order()));
        _mobileContext.SaveChanges();
    }

    public void Delete(int id)
    {
        var order = _mobileContext.Orders.FirstOrDefault(x => x.Id == id);
        if (order is null)
            return;
        _mobileContext.Orders.Remove(order);
        _mobileContext.SaveChanges();
    }

    public OrderViewModel GetById(int id)
    {
        var order = _mobileContext
            .Orders
            .Include(x => x.Phone)
            .FirstOrDefault(x => x.Id == id);
        if (order is null)
            throw new Exception("Заказ не найден");
        OrderViewModel viewModel = new OrderViewModel
        {
            ShortPhone = new ShortPhoneViewModel
            {
                Id = order.Phone.Id,
                Title = order.Phone.Title
            },
            Id = order.Id,
            Address = order.Address,
            Username = order.Username,
            ContactPhone = order.ContactPhone
        };
        return viewModel;
    }

    public void Edit(OrderViewModel? edited)
    {
        if (edited is null)
            return;
        Order? order = _mobileContext.Orders.FirstOrDefault(x => x.Id == edited.Id);
        if (order is null)
            return;
        _mobileContext.Orders.Update(edited.MapToOrder(order));
        _mobileContext.SaveChanges();
    }
}