using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace MobileStore.ViewModels;

public class PhoneViewModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Поле обязательно для заполнения")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Минимальное количество знаков: 3, Максимальное - 50")]
    [DataType(DataType.Text, ErrorMessage = "тут должен быть только текст")]
    [Remote(action:"CheckUniqueTitle", controller:"PhoneValidation", ErrorMessage = "Название занято")]
    public string Title { get; set; }
    
    [Required(ErrorMessage = "Поле обязательно для заполнения")]
    [Range(1000, 5000, ErrorMessage = "Стоимость не должна быть ниже 1000 у.е и дороже 5000 у.е.")]
    [RegularExpression(@"^\d+$", ErrorMessage = "Поле должно содежать только числа")]
    [DataType(DataType.Currency, ErrorMessage = "Здесь должны быть только деньги")]
    public int Price { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    [Required(ErrorMessage = "Поле обязательно для заполнения")]
    public int BrandId { get; set; }
    public string BrandName { get; set; }
}