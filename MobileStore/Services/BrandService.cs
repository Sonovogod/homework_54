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

    public List<BrandViewModel> GetAll()
    {
        return _db.Brands.Select(b => new BrandViewModel
        {
            Id = b.Id,
            Name = b.Name
        }).ToList();
    }
}