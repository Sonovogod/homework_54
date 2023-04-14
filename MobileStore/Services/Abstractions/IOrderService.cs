using MobileStore.Models;
using MobileStore.ViewModels;

namespace MobileStore.Services.Abstractions;

public interface IOrderService
{
    List<Order> GetAll();
    void Create(OrderViewModel? model);
    void Delete(int id);
    OrderViewModel GetById(int id);
    void Edit(OrderViewModel edited);
}