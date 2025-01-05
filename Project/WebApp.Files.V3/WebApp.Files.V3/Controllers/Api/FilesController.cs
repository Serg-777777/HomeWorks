using Microsoft.AspNetCore.Mvc;
using Application.AppServices.FilesServices;
using Presentation.Dto;
namespace Presentation.Controllers.Api;

[Route("api/[controller]")]
[ApiController]
public class FilesController : ControllerBase
{
    IFileService _fileService;
    string _keyName;
    public FilesController(IFileService fileService)
    {
        _fileService = fileService;
        _keyName = "userkey";
    }

    [HttpPost]
    public ActionResult Upload(IFormCollection upfile)
    {
        var _uKey = upfile[_keyName];
        if (!String.IsNullOrEmpty(_uKey))
        {
           var res =  _fileService.UploadFile(upfile, _uKey!);
            var fileDto = new FilesDtoView(upfile.Files[0].FileName);
            return RedirectToAction("Index","FileHtml");
        }
        return BadRequest("Bad Request");
    }

    [HttpGet("all/{userKey}")]
    public ActionResult<List<string>?> All(string userKey)
    {
        var files = _fileService.GetFiles(userKey);
        //return files;
        return LocalRedirect($"/filehtml/all?userkey={userKey}");
    }
    [HttpGet("delete/{userkey}")]
    public ActionResult Delete([FromRoute] string userkey, [FromQuery] string fileName)
    {
        _fileService.DeleteFile(fileName, userkey!);
        return LocalRedirect($"/filehtml/all?userkey={userkey}");
    }

    [HttpGet("{userkey}")]
    public async Task<ActionResult> GetFille([FromRoute] string userkey, [FromQuery] string fileName)
    {
        if (String.IsNullOrEmpty(userkey)) return BadRequest();

        var f = _fileService.DownloadFile(fileName, userkey!);
        if (f != null)
        {
            await Response.SendFileAsync(f);
            return NoContent();
        }
        return NotFound();
    }
    
    [HttpGet("attach/{userkey}")]
    public ActionResult GetAttach([FromRoute] string userkey, [FromQuery] string fileName)
    {
        if (userkey != null)
        {
            var f = _fileService.DownloadFile(fileName, userkey!);
            if (f != null)
            {
                //Response.Headers.ContentDisposition = "attachment";
                return PhysicalFile(f.PhysicalPath!, "application/octet-stream",f.Name);
            }
        }
        return NotFound();
    }
}
