using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers;

public class Main : Controller
{
    public IActionResult Portfolio()
    {
        return View();
    }
}