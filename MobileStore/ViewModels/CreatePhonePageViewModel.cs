namespace MobileStore.ViewModels;

public class CreatePhonePageViewModel
{
    public PhoneViewModel Phone { get; set; }
    public string? ErrorMessage { get; set; }
    public List<ShortBrandViewModel>? Brands { get; set; }
}