using MobileStore.Extensions;
using MobileStore.Models;
using MobileStore.Services.Abstractions;
using MobileStore.ViewModels;

namespace MobileStore.Services;

public class BrandService : IBrandService
{
    private readonly MobileContext _db;

    public BrandService(MobileContext db)
    {
        _db = db;
    }

    public List<ShortBrandViewModel> GetAll()
    {
        return _db.Brands.Select(b => new ShortBrandViewModel
        {
            Id = b.Id,
            Name = b.Name
        }).ToList();
    }

    public void Add(Brand brand)
    {
       _db.Add(brand);
       _db.SaveChanges();
    }

    public Brand? GetById(int id) => _db.Brands.FirstOrDefault(x => x.Id == id);

    public void Delete(int id)
    {
        var brand = GetById(id);
        if (brand == null) return;
        _db.Brands.Remove(brand);
        _db.SaveChanges();
    }

    public void Edit(Brand brand)
    {
        _db.Brands.Update(brand);
        _db.SaveChanges();
    }
  
}