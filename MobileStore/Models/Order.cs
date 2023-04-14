namespace MobileStore.Models;

public class Order
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Address { get; set; }
    public string ContactPhone { get; set; }
    public int PhoneId { get; set; }
    public Phone Phone { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}