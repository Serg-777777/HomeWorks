using Microsoft.AspNetCore.Mvc;
using Application.AppServices.FilesServices;
using Presentation.Mapping.DtoViews.FileDtoViews;
using AutoMapper;
using Application.Mapping.DtoLogics.FileDtoLogics;

namespace Presentation.Controllers.Api;

[Route("api/[controller]")]
[ApiController]
public class FilesController : ControllerBase
{
    FileService _fileService;
    IMapper _mapper;
    public FilesController(FileService fileService, IMapper mapper)
    {
        _fileService = fileService;
        _mapper = mapper;
    }

    [HttpPost]
    public ActionResult Add(FileDtoView fileDtoView)
    {
        var fileLogic = _mapper.Map<FileDtoLogic>(fileDtoView);
        if (_fileService.LoadFile(fileLogic.UserKey, Request.Form))
            return Ok();
        return BadRequest();
    }

    [HttpDelete]
    public ActionResult Delete(FileDtoView fileDtoView)
    {
        var fileDtoLog = _mapper.Map<FileDtoLogic>(fileDtoView);
        if (_fileService.DeleteFile(fileDtoLog))
            return Ok();
        return BadRequest();
    }

    [HttpGet]
    public async Task<ActionResult> GetFille(FileDtoView fileDtoView)
    {
        var fileDtoLog = _mapper.Map<FileDtoLogic>(fileDtoView);
        var filePath = _fileService.GetFilePath(fileDtoLog);
        if (filePath != null)
        {
            await Response.SendFileAsync(filePath!);
        }
        return NotFound();
    }

    [HttpGet]
    public async Task<ActionResult> GetFilleAttach(FileDtoView fileDtoView)
    {
        var fileDtoLog = _mapper.Map<FileDtoLogic>(fileDtoView);
        var filePath = _fileService.GetFilePath(fileDtoLog);
        if (filePath != null)
        {
            Response.Headers.ContentDisposition = "attachment";
            await Response.SendFileAsync(filePath!);
        }
        return NotFound();
    }
}
