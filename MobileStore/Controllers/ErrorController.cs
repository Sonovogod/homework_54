using Microsoft.AspNetCore.Mvc;

namespace MobileStore.Controllers;

public class ErrorController : Controller
{
    // GET
    public IActionResult Error()
    {
        return View();
    }
}