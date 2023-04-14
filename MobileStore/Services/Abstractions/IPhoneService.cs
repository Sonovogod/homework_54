using MobileStore.Models;
using MobileStore.ViewModels;

namespace MobileStore.Services.Abstractions;

public interface IPhoneService
{
   List<PhoneViewModel> GetAll();
   void Create(PhoneViewModel phone);
   Phone? GetById(int id);
   void DeleteById(int id);
   List<PhoneViewModel> SearchByFilter(PhoneSearchViewModel searchViewModel);
}