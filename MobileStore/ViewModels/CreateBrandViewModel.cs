using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace MobileStore.ViewModels;

public class CreateBrandViewModel
{
    public List<BrandViewModel>? Brands { get; set; }
    public int Id { get; set; }
    [Required(ErrorMessage = "Поле не может быть пустым")]
    [Remote("CheckUniqueName", "BrandValidation", ErrorMessage = "Такое наименоване бренда уже есть", AdditionalFields = "Name, Id")]
    [StringLength(50, MinimumLength = 1, ErrorMessage = "Минимальное количество знаков: 1, Максимальное - 50")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Поле не может быть пустым")]
    [StringLength(50, MinimumLength = 1, ErrorMessage = "Минимальное количество знаков: 1, Максимальное - 50")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "Поле не может быть пустым")]
    [Remote("CheckData", "BrandValidation", ErrorMessage = "Дата не должна быть позже текущей и не старее 100лет")]
    [DataType(DataType.DateTime)]
    public DateTime? DateEstablishment  { get; set; }
}