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
    public bool CheckUniqueTitle([Bind(Prefix = "Phone.Title")]string title)
    {
        return !_db.Phones.Any(p => p.Title.Equals(title));
    }
}