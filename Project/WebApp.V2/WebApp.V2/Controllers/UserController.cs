using Application.DtoLogics.UserDtoLogics;
using Application.ServicesViews.UserServicesApps;
using AutoMapper;
using Infrastructure.DtoLogics.UserDtoLogics;
using Microsoft.AspNetCore.Mvc;
using Presentation.DtoViews.UserDtoViews;

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

    [HttpGet]
    public ActionResult Authorize()
    {
        ViewBag.Title = "Авторизация";
        return View();
    }

    [HttpPost]
    public ActionResult Authorize(string login, string password)
    {
        var userUnfoLogic = _userService.Authorize(login, password);
        var userUnfoView = _mapper.Map<UserFullDtoView>(userUnfoLogic);
        ViewBag.Layout = "_Master";
        return View("Info", userUnfoView);
    }

    public ActionResult Index()
    {
        var userDtoApp = new UserDtoView();
        ViewBag.Title = "Форма";
        return View(userDtoApp);
    }
    [HttpGet]
    public ActionResult Info([FromRoute] int id)
    {
        var infoLogic = _userService.Info(id);
        var infoView = _mapper.Map<UserFullDtoView>(infoLogic);
        return View(infoView);
    }
    [HttpPost]
    public ActionResult Add(UserDtoView userDtoApp)
    {
        var userLogic = _mapper.Map<UserDtoLogic>(userDtoApp);
        var userNewModel = _userService.CreateUser(userLogic);
        var id = userNewModel?.Id;
        return LocalRedirect($"~/user/all");
    }

    [HttpGet]
    public ActionResult Edit([FromRoute] int id)
    {
        var userLogic = _userService.GetUser(id);
        if (userLogic != null)
        {
            var userView = _mapper.Map<UserEditDtoView>(userLogic);
            ViewBag.Title = "Правка";
            ViewData["layot"] = "_Master";
            return View(userView);
        }
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public ActionResult Editing([FromForm] UserEditDtoView userDtoView)
    {
        var user = _userService.GetUser(userDtoView.Id);
        if (user != null)
        {
            var userLogic = _mapper.Map<UserFullDtoLogic>(userDtoView);
            _userService.UpdateUser(userLogic);
            return LocalRedirect($"~/user/info/{userDtoView.Id}");
        }
        return BadRequest($"Пользователь не найден");
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
    public ActionResult AllUpdate(IFormCollection forms)
    {
        _logger.LogInformation($"::: TEST NAME DateCreated-: {forms["DateCreated-1"]}");
        _logger.LogInformation($"::: TEST Request.Form Count: {forms.Count()}");

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
