

using Application.AppServices.FilesServices;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;


public class FileHtmlController : Controller
{
    IFileService _fileService;

    public FileHtmlController(IFileService fileService)
    {
        _fileService = fileService;
    }
 
    public ActionResult Index()
    {
        return View();
    }
    [HttpGet]
    public ActionResult All([FromQuery] string userKey)
    {
        var fs = _fileService.GetFiles(userKey);
        return View(fs);
    }
}
