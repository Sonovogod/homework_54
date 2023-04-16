using MobileStore.Models;
using MobileStore.ViewModels;

namespace MobileStore.Extensions;

public static class PhoneExtension
{
    public static List<PhoneViewModel> MapToPhoneViewModel(this IEnumerable<Phone> self)
    {
        return self.Select(p => new PhoneViewModel
        {
            Id = p.Id,
            BrandName = p.Brand.Name,
            BrandId = p.Brand.Id,
            Title = p.Title,
            Price = p.Price,
            CreatedAt = p.CreatedAt,
            UpdatedAt = p.UpdatedAt
        }).ToList();
    }

    public static PhoneViewModel MapToPhoneViewModel(Phone phone)
    {
        PhoneViewModel viewModel = new PhoneViewModel
        {
            Id = phone.Id,
            Title = phone.Title,
            Price = phone.Price,
            CreatedAt = phone.CreatedAt,
            UpdatedAt = phone.UpdatedAt,
            BrandId = phone.Brand.Id,
            BrandName = phone.Brand.Name
        };
        return viewModel;
    }
    
    public static CreatePhonePageViewModel MapToCreatePhonePageViewModel(Phone phone, List<ShortBrandViewModel> brands)
    {
        CreatePhonePageViewModel createPhonePageViewModel = new CreatePhonePageViewModel
        {
            Phone = new PhoneViewModel()
            {
                Id = phone.Id,
                Title = phone.Title,
                Price = phone.Price,
                CreatedAt = phone.CreatedAt,
                UpdatedAt = phone.UpdatedAt,
                BrandId = phone.Brand.Id,
                BrandName = phone.Brand.Name
            },
            Brands = brands
        };
        return createPhonePageViewModel;
    }
    
    public static Phone MapToPhoneModel(CreatePhonePageViewModel createPhonePageViewModel)
    {
        Phone phone = new Phone()
        {
            Id = createPhonePageViewModel.Phone.Id,
            Title = createPhonePageViewModel.Phone.Title,
            Price = createPhonePageViewModel.Phone.Price,
            CreatedAt = createPhonePageViewModel.Phone.CreatedAt,
            UpdatedAt = createPhonePageViewModel.Phone.UpdatedAt,
            BrandId = createPhonePageViewModel.Phone.BrandId
        };
        return phone;
    }
}