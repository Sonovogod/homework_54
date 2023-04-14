using System.ComponentModel.DataAnnotations;

namespace MobileStore.Enums;

public enum SearchPhoneCriterion
{
    [Display(Name = "Искать по производителю")]
    SearchByCompany,
    [Display(Name = "Искать по наименованию")]
    SearchByTitle
}