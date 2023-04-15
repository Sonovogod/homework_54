using MobileStore.ViewModels;

namespace MobileStore.Services.Abstractions;

public interface IBrandService
{
    List<ShortBrandViewModel> GetAll();
    void Add(CreateBrandViewModel createBrandViewModel);
}