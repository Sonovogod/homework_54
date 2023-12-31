using MobileStore.Models;
using MobileStore.ViewModels;

namespace MobileStore.Services.Abstractions;

public interface IPhoneService
{
   List<PhoneViewModel> GetAll();
   void Create(PhoneViewModel phone);
   Phone? GetById(int id);
   void DeleteById(int id);
   void Edit(Phone phone);
   List<PhoneViewModel> SearchByFilter(PhoneSearchViewModel searchViewModel);
}