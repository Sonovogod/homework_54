using System.ComponentModel.DataAnnotations;
using MobileStore.Models;

namespace MobileStore.ViewModels;

public class FeedBackViewModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Поле обязательно для заполнения")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Минимальное количество знаков: 3, Максимальное - 50")]
    public string UserName { get; set; }
    [Required(ErrorMessage = "Поле обязательно для заполнения")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Минимальное количество знаков: 3, Максимальное - 100")]
    public string Comments { get; set; }
    [Required(ErrorMessage = "Поле обязательно для заполнения")]
    public int Grade { get; set; }
    public int PhoneId { get; set; }
}