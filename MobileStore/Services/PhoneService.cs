using Microsoft.EntityFrameworkCore;
using MobileStore.Enums;
using MobileStore.Extensions;
using MobileStore.Models;
using MobileStore.Services.Abstractions;
using MobileStore.ViewModels;

namespace MobileStore.Services;

public class PhoneService : IPhoneService
{
    private readonly MobileContext _db;

    public PhoneService(MobileContext db)
    {
        _db = db;
    }

    public List<PhoneViewModel> GetAll()
    {
        return _db.Phones
            .Include(p => p.Brand)
            .MapToPhoneViewModel();
    }

    public void Create(PhoneViewModel phone)
    {
        var newPhone = new Phone
        {
            Id = phone.Id,
            BrandId = phone.BrandId,
            Title = phone.Title,
            Price = phone.Price
        };
        _db.Phones.Add(newPhone);
        _db.SaveChanges();
    }

    public Phone? GetById(int id)
    {
        return _db.Phones
            .Include(p => p.Brand)
            .FirstOrDefault(p => p.Id == id);
    }

    public void DeleteById(int id)
    {
        var phone = _db.Phones.FirstOrDefault(p => p.Id == id);
        if (phone is null)
        {
            throw new Exception();
        }

        phone.IsDeleted = true;
        _db.Phones.Update(phone);
        _db.SaveChanges();
    }

    public List<PhoneViewModel> SearchByFilter(PhoneSearchViewModel searchViewModel)
    {
        var phones = _db.Phones
            .Include(p => p.Brand)
            .Where(p => EF.Functions.Like(
                searchViewModel.Criterion == SearchPhoneCriterion.SearchByCompany
                    ? p.Brand.Name
                    : p.Title,
                $"%{searchViewModel.Filter}%"));
        return phones.MapToPhoneViewModel();
    }
}