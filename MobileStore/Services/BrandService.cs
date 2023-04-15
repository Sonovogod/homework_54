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

    public void Add(CreateBrandViewModel createBrandViewModel)
    {
       _db.Add(BrandExtension.MapToBrandModel(createBrandViewModel));
       _db.SaveChanges();
    }
}