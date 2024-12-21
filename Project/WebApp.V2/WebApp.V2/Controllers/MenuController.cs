
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

public class MenuController : Controller
{
    public ActionResult Index()
    {
        ViewData["msg"] = "Welcome";
        return View();
    }
}
