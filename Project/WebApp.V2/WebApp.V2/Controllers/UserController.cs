using Application.DtoLogics.UserDtoLogics;
using Application.ServicesViews.UserServicesApps;
using AutoMapper;
using Infrastructure.DtoLogics.UserDtoLogics;
using Microsoft.AspNetCore.Mvc;
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
        _logger.LogInformation($":::TEST ADD::: Id:{userNewModel?.Id}, Login:{userNewModel?.Login},  Email:{userNewModel?.Email}");
        var id = userNewModel?.Id;
        return LocalRedirect($"~/user/details/{id}");
    }

    [HttpGet]
    public ActionResult Details([FromRoute] int id)
    {
        _logger.LogInformation($":::TEST ADD::: ID:{id}");
        var userLogic = _userService.GetUser(id);
        if (userLogic != null)
        {
            var userView = _mapper.Map<UserDtoView>(userLogic);
            ViewData["id"] = id;
            return View(userView);
        }
        return BadRequest($"Не найден ID: {id}");
    }

    [HttpGet]
    public ActionResult Edit([FromRoute] int id)
    {
        var userLogic = _userService.GetUser(id);
        if (userLogic != null)
        {
            var userView= _mapper.Map<UserFullDtoView>(userLogic);
            ViewBag.Title = "Обновление";
            return View(userView);
        }
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public ActionResult Edit([FromRoute] int id, UserFullDtoView userDtoApp)
    {
        var u = _userService.GetUser(id);
        if (u != null)
        {
            var userLogic = _mapper.Map<UserFullDtoLogic>(userDtoApp);
            _userService.UpdateUser(id, userLogic);
            return LocalRedirect("~/user/all");
        }
        return BadRequest($"Пользователь ID: {id} не найден");
    }
    [HttpGet]
    public ActionResult Delete([FromRoute] int id)
    {
        var res = _userService.DeleteUser(id);
        return LocalRedirect("~/user/all");
    }
    [HttpGet]
    public ActionResult All()
    {
        var usLogic = _userService.GetUsers();
        var usView = _mapper.Map<List<UserFullDtoView>>(usLogic);
        ViewBag.Layout = "_Master";
        return View(usView);
    }
    [HttpPost]
    public ActionResult AllUpdate([FromBody] FormCollection forms)
    {
        _logger.LogInformation($"::: Request.Form Count: {forms.Count()}");

        foreach (var f in forms)
        {
            _logger.LogInformation($"::: Request.Form Key: {f.Key} Value:{f.Value}");
        }

        // var us = _mapper.Map<List<UserFullDtoLogic>>(userFullDtos);
        // var res = _userService.UpdateUsers(us);

        return LocalRedirect("~/user/all");
    }
    [HttpGet]
    public ActionResult Erase([FromRoute] int id)
    {
        var res = _userService.EraseUser(id);
        return LocalRedirect("~/user/all");
    }
}
