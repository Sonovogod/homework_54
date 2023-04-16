using MobileStore.Models;
using MobileStore.ViewModels;

namespace MobileStore.Extensions;

public static class BrandExtension
{
    public static Brand MapToBrandModel(CreateBrandViewModel createBrandViewModel)
    {
        Brand brand = new Brand()
        {
            Id = createBrandViewModel.Id,
            Name = createBrandViewModel.Name,
            Email = createBrandViewModel.Email,
            DateEstablishment = createBrandViewModel.DateEstablishment
        };
        return brand;
    }

    public static CreateBrandViewModel MapToCreateBrandViewModel(Brand brand)
    {
        CreateBrandViewModel brandViewModel = new CreateBrandViewModel()
        {
            Id = brand.Id,
            Name = brand.Name,
            Email = brand.Email,
            DateEstablishment = brand.DateEstablishment
        };
        return brandViewModel;
    }
}