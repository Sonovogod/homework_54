using Microsoft.AspNetCore.Mvc;
using MobileStore.Models;

namespace MobileStore.Controllers;

public class PhoneValidationController : Controller
{
    private readonly MobileContext _db;

    public PhoneValidationController(MobileContext db)
    {
        _db = db;
    }

    [AcceptVerbs("POST", "GET")]
    public bool CheckUniqueTitle([Bind(Prefix = "Phone.Title")]string title, [Bind(Prefix = "Phone.Id")]int id)
    {
        if (id != 0)
        {
            bool nameIsExist = _db.Phones.Any(x => x.Id != id && x.Title == title);
            if (nameIsExist)
                return false;
            return true;
        }
        return !_db.Phones.Any(x => x.Title.Equals(title));
    }
}