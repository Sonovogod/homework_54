using MobileStore.Models;
using MobileStore.ViewModels;

namespace MobileStore.Extensions;

public static class OrderExtension
{
    public static Order MapToOrder(this OrderViewModel self, Order dest)
    {
        dest.Address = self.Address;
        dest.ContactPhone = self.ContactPhone;
        dest.Id = self.Id;
        dest.Username = self.Username;
        dest.PhoneId = self.ShortPhone.Id;
        
        return dest;
    }
}