using Microsoft.AspNetCore.Mvc;
using MobileStore.Models;

namespace MobileStore.Controllers;

public class BrandValidationController : Controller
{
    private readonly MobileContext _db;

    public BrandValidationController(MobileContext db)
    {
        _db = db;
    }
    
    [AcceptVerbs("Get", "Post")]
    public bool CheckUniqueName(string name)
    {
        return !_db.Brands.Any(x => x.Name.Equals(name));
    }
}