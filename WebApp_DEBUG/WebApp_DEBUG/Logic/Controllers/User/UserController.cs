
using Microsoft.AspNetCore.Mvc;
using WebApp_DEBUG.Domain.Dto.Mapper.UserDtoMapper;
using  WebApp_DEBUG.Domain.Dto;
using WebApp_DEBUG.Domain.Model.UserModel;


namespace WebApp_DEBUG.Logic.Controllers.User;

public class UserController : Controller
{
    IDtoRepository<WebApp_DEBUG.Domain.Model.UserModel.User, UserModelDto> _usersRepos;

    ILogger<UserController> _logger;
    public UserController(IDtoRepository<WebApp_DEBUG.Domain.Model.UserModel.User, UserModelDto> usersRepos, ILogger<UserController> logger)
    {
        _usersRepos = usersRepos;
        _logger = logger;
    }

    [HttpGet]
    public ActionResult Form()
    {
        var u = new UserModelDto();
        return View("Infrastructure/Views/User/Form.cshtml", u);
    }
    [HttpPost]
    public ActionResult Added(UserModelDto u)
    {
        _logger.LogWarning($"+++ {u.Login}");
        _usersRepos.CreateEntity(u);
        return View("Infrastructure/Views/User/Added.cshtml", u);
    }
    [HttpGet]
    public ActionResult List()
    {
        _logger.LogWarning($"+++ LIST TEST");
       //!!! Ошибка - Object reference not set to an instance of an object
        var us = _usersRepos.Entities();
        return View("Infrastructure/Views/User/List.cshtml", us);
    }
}
