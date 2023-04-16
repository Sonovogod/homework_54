using MobileStore.Models;
using MobileStore.ViewModels;

namespace MobileStore.Services.Abstractions;

public interface IBrandService
{
    List<ShortBrandViewModel> GetAll();
    void Add(Brand brand);
    Brand? GetById(int id);
    void Delete(int id);
    void Edit(Brand brand);
}