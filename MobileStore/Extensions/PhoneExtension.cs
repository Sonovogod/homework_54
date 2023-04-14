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
}