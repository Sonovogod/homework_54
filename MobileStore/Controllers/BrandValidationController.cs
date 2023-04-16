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
    public bool CheckUniqueName(string name, int id)
    {
        if (id != 0)
        {
            bool nameIsExist = _db.Brands.Any(x => x.Id != id && x.Name == name);
            if (nameIsExist)
                return false;
            return true;
        }
        return !_db.Brands.Any(x => x.Name == name);
    }

    [AcceptVerbs("Get", "Post")]
    public bool CheckData(DateTime DateEstablishment)
    {
        DateTime now = DateTime.Now;
        DateTime lastYears = now.AddYears(-100);

        if (DateEstablishment <= now && DateEstablishment > lastYears)
            return true;
        
        return false;
    }
}