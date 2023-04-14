namespace MobileStore.Models;

public class Phone
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Price { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }

    public int BrandId { get; set; }
    public Brand Brand { get; set; }
}