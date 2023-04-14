
namespace MobileStore.ViewModels;

public class OrderViewModel
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Address { get; set; }
    public string ContactPhone { get; set; }
    public ShortPhoneViewModel ShortPhone { get; set; }
}