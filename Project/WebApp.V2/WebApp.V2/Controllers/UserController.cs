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

    [HttpGet]
    public ActionResult Authorize()
    {
        ViewBag.Title = "Авторизация";
        return View();
    }

    [HttpPost]
    public ActionResult Authorize(string login, string password)
    {
        var userFullLogic = _userService.Authorize(login, password);
        
        if (userFullLogic != null)
        {
            var userFullView = _mapper.Map<UserFullDtoView>(userFullLogic);
            var profModel = userFullLogic?.ProfileModel;
            var profLogic = _mapper.Map<UserProfileDtoLogic>(profModel);
            var profView = _mapper.Map<UserProfileDtoView>(profLogic);
            var obj = new UserInfoDtoView(userFullView, profView);
            ViewBag.IdUser = userFullLogic?.Id;
            return View("Info", obj);
            // return  RedirectToAction("Info", id);
           // return LocalRedirect($"~/user/info/{id}");
        }
        return BadRequest("Пользователь не найден!");
    }

    public ActionResult Index()
    {
        var userDtoApp = new UserDtoView();
        ViewBag.Title = "Форма";
        return View(userDtoApp);
    }
    [HttpGet]
    public ActionResult Info([FromRoute] int idUser)
    {
        var userFullLogic = _userService.GetUser(idUser);
        if(userFullLogic != null)
        {
            var userFullView = _mapper.Map<UserFullDtoView>(userFullLogic);
            var profLogic = _mapper.Map<UserProfileDtoLogic>(userFullLogic?.ProfileModel);
            var profView = _mapper.Map<UserProfileDtoView>(profLogic);
            var obj = new UserInfoDtoView(userFullView, profView);
            return View(obj);
        }
        return BadRequest("Пользователь не найден!");

    }
    [HttpPost]
    public ActionResult Add(UserDtoView userDtoApp)
    {
        var userLogic = _mapper.Map<UserDtoLogic>(userDtoApp);
        var userNewModel = _userService.CreateUser(userLogic);
        _logger.LogInformation($":::TEST ADD::: Id:{userNewModel?.Id}, Login:{userNewModel?.Login},  Email:{userNewModel?.Email},  Role:{userNewModel?.Role?.RoleUser}");
        var id = userNewModel?.Id;
        ViewBag.IdUser = id;
        return LocalRedirect($"~/user/info/{id}");
    }

    [HttpGet]
    public ActionResult Edit([FromRoute] int id)
    {
        var userLogic = _userService.GetUser(id);
        if (userLogic != null)
        {
            var userView= _mapper.Map<UserFullDtoView>(userLogic);
            ViewBag.Title = "Правка";
            ViewData["layot"] = "_Master";
            ViewBag.IdUser = id;
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
            _logger.LogInformation($":::TEST::: Role View:{userDtoApp.Role?.RoleUser}");

            var userLogic = _mapper.Map<UserFullDtoLogic>(userDtoApp);

            _logger.LogInformation($":::TEST::: Role Logic:{userDtoApp.Role?.RoleUser}");

            _userService.UpdateUser(id, userLogic);
            ViewBag.IdUser = id;
            return LocalRedirect($"~/user/info/{id}");
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
