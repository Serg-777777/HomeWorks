using Application.DtoLogics.UserDtoLogics;
using Application.ServicesViews.UserServicesApps;
using AutoMapper;
using Infrastructure.DtoLogics.UserDtoLogics;
using Microsoft.AspNetCore.Mvc;
using Presentation.DtoViews.UserDtoViews;
using Presentation.Validation;

namespace Presentation.Controllers;

public sealed class UserController : Controller
{
    private readonly ILogger<UserController> _logger;
    private UserService _userService;
    private IMapper _mapper;
    private IValidationUser _validationUser;

    public UserController(UserService userService, IMapper mapper, IValidationUser validationUser, ILogger<UserController> logger)
    {
        _logger = logger;
        _userService = userService;
        _mapper = mapper;
        _validationUser = validationUser;
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
        //validation
        var valid = _validationUser.Validate(login, password);
        if(!valid.IsValid) return BadRequest(valid.Errors[0].ErrorMessage);
        //validation

        var userUnfoLogic = _userService.AuthorizeAsync(login, password);
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
        //validation
        var valid = _validationUser.Validate(id);
        if (!valid.IsValid) return BadRequest(valid.Errors[0].ErrorMessage);
        //validation

        var infoLogic = _userService.Info(id);
        if (infoLogic == null) return BadRequest();
        var infoView = _mapper.Map<UserFullDtoView>(infoLogic);
        return View(infoView);
    }
    [HttpPost]
    public ActionResult Add(UserDtoView userDtoApp)
    {
        //validation
        var valid = _validationUser.Validate(userDtoApp);
        if (!valid.IsValid) return BadRequest(valid.Errors[0].ErrorMessage);
        //validation

        var userLogic = _mapper.Map<UserDtoLogic>(userDtoApp);
        var userNewModel = _userService.CreateUserAsync(userLogic);
        var id = userNewModel?.Id;
        return LocalRedirect($"~/user/all");
    }

    [HttpGet]
    public ActionResult Edit([FromRoute] int id)
    {
        //validation
        var valid = _validationUser.Validate(id);
        if (!valid.IsValid) return BadRequest(valid.Errors[0].ErrorMessage);
        //validation

        var userLogic = _userService.GetUserAsync(id);
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
        //validation
        var valid = _validationUser.Validate(userDtoView);
        if (!valid.IsValid) return BadRequest(valid.Errors[0].ErrorMessage);
        //validation

        var user = _userService.GetUserAsync(userDtoView.Id);
        if (user != null)
        {
            var userLogic = _mapper.Map<UserFullDtoLogic>(userDtoView);
            _userService?.UpdateUserAsync(userLogic);
            return LocalRedirect($"~/user/info/{userDtoView.Id}");
        }
        return BadRequest($"Пользователь не найден");
    }
    [HttpGet]
    public ActionResult Delete([FromRoute] int id)
    {
        //validation
        var valid = _validationUser.Validate(id);
        if (!valid.IsValid) return BadRequest(valid.Errors[0].ErrorMessage);
        //validation

        var result = _userService.DeleteUserAsync(id);
        return LocalRedirect("~/user/all");
    }

    [HttpGet]
    public ActionResult Erase([FromRoute] int id)
    {
        //validation
        var valid = _validationUser.Validate(id);
        if (!valid.IsValid) return BadRequest(valid.Errors[0].ErrorMessage);
        //validation

        var result = _userService.EraseUser(id);
        return LocalRedirect("~/user/all");
    }

    [HttpGet]
    public ActionResult All()
    {
        var usLogic = _userService.GetUsersAsync();
        var usView = _mapper.Map<List<UserFullDtoView>>(usLogic);
        ViewBag.Layout = "_Master";
        return View(usView);
    }


}
