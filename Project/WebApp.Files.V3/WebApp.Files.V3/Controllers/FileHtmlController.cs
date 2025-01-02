

using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;


public class FileHtmlController : Controller
{
    public FileHtmlController()
    {
    }
 
    public ActionResult Index()
    {
        Response.Headers.TryAdd("user-kye", "login111");
        return View();
    }

}
