using Application.ServicesApps.UserServicesApps;
using AutoMapper;
using Infrastructure.DtoLogics.UserDtoLogics;
using Microsoft.AspNetCore.Mvc;
using Presentation.Mappers.DtoApps.UserDtoViews;
using Presentation.Mappers.DtoViews.UserDtoViews;

namespace Presentation.Controllers;

public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;
    private UserService _userService;
    private IMapper _mapper;
    public UserController(UserService userService, IMapper mapper, ILogger<UserController> logger)
    {
        _logger = logger;
        _userService = userService;
        _mapper = mapper;
    }

    public ActionResult Index()
    {
        var userDtoApp = new UserDtoView();
        ViewBag.Title = "Форма";
        return View(userDtoApp);
    }

    [HttpPost]
    public ActionResult Add(UserDtoView userDtoApp)
    {
        var userLogic = _mapper.Map<UserDtoLogic>(userDtoApp);
        var userNewModel = _userService.CreateUser(userLogic);
        _logger.LogInformation($":::TEST ADD::: Login:{userNewModel?.Id}, Login:{userNewModel?.Login},  Email:{userNewModel?.Email}");
        var id = userNewModel?.Id;
        return LocalRedirect($"~/user/details/{id}");
    }

    [HttpGet]
    public ActionResult Details([FromRoute] int id)
    {
        _logger.LogInformation($":::TEST ADD::: ID:{id}");
        var userLogic = _userService.GetUser(id);
        if(userLogic != null)
        {
            var userView = _mapper.Map<UserIdDtoView>(userLogic);
            return View(userView);
        }
        return BadRequest($"Не найден ID: {id}");
    }
    [HttpPut]
    public ActionResult Edit([FromRoute] int id, [FromBody] UserDtoView userDtoApp)
    {
        var userLogic = _mapper.Map<UserDtoLogic>(userDtoApp);
        var user = _userService.UpdateUser(id, userLogic);
        return RedirectToAction(nameof(Details), user.Id);
    }

    [HttpDelete]
    public ActionResult Delete([FromRoute] int id)
    {
        var res = _userService.DeleteUser(id);
        return RedirectToAction(nameof(Index));
    }

}
