using Microsoft.AspNetCore.Mvc;
using Application.AppServices.FilesServices;

using Presentation.Dto;
namespace Presentation.Controllers.Api;

[Route("api/[controller]")]
[ApiController]
public class FilesController : ControllerBase
{
    IFileService _fileService;
    string? _uKey = null; //TESTING
    public FilesController(IFileService fileService)
    {
        _fileService = fileService;
        //_uKey = Request.Headers["user-kye"].First()!; //ОШИБКА
        if (_uKey == null) 
            _uKey = "test-login";
    }

    [HttpPost]
    public ActionResult Upload(IFormCollection upfile)
    {
        if (_uKey !=default)
        {
           var res =  _fileService.UploadFile(upfile, _uKey!);
            var fileDto = new FilesDtoView(upfile.Files[0].FileName);
            return RedirectToAction("Index","FileHtml");
        }
        return BadRequest("Bad Request");
    }

    [HttpDelete("{fileName}")]
    public ActionResult Delete(string fileName)
    {
        _fileService.DeleteFile(fileName, _uKey!);
        return Ok();
    }

    [HttpGet("{fileName}")]
    public async Task<ActionResult> GetFille(string fileName)
    {
        if (String.IsNullOrEmpty(_uKey)) return BadRequest();

        var f = _fileService.DownloadFile(fileName, _uKey!);
        if (f != null)
        {
            await Response.SendFileAsync(f.PhysicalPath!);
            // return File(f.PhysicalPath!, "application/octet-stream"); 
        }
        return NotFound();
    }
    
    [HttpGet("attach/{fileName}")]
    public async Task<ActionResult> GetAttach(string fileName)
    {
        if (_uKey != null)
        {
            Response.Headers.ContentDisposition = "attachment";
            await Response.SendFileAsync(_uKey!);
        }
        return NotFound();
    }
    
}
