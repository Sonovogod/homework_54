using MobileStore.ViewModels;

namespace MobileStore.Services.Abstractions;

public interface IBrandService
{
    List<BrandViewModel> GetAll();
}