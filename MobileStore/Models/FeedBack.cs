namespace MobileStore.Models;

public class FeedBack
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Comments { get; set; }
    public int Grade { get; set; }
    
    public int PhoneId { get; set; }
    public Phone Phone { get; set; }
}