using Application.ServicesApps.UserServicesApps;
using AutoMapper;
using Infrastructure.DtoLogics.UserDtoLogics;
using Microsoft.AspNetCore.Mvc;
using Presentation.Mappers.DtoApps.UserDtoApps;

namespace Presentation.Controllers;

public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;
    private UserMapperService _userMapper;
    private IMapper _mapper;
    public UserController(UserMapperService userAdapter, IMapper mapper, ILogger<UserController> logger)
    {
        _logger = logger;
        _userMapper = userAdapter;
        _mapper = mapper;
    }

    public ActionResult Index()
    {
        var userDtoApp = new UserDtoApp();
        ViewData["prof"] = new UserProfileDtoApp();
        ViewBag.Title = "Форма";
        return View(userDtoApp);
    }

    [HttpPost]
    public ActionResult Add(UserDtoApp userDtoApp, UserProfileDtoApp profileDtoApp)
    {
        var userLogic = _mapper.Map<UserDtoLogic>(userDtoApp);
        var profLogic = _mapper.Map<UserProfileDtoLogic>(profileDtoApp);

        _logger.LogInformation($":::TEST CONTROL ADD::: Login:{userLogic?.Login}, Name:{profLogic?.FirstName}"); 

        _userMapper.CreateUser(userLogic!, profLogic!);
        var str = userLogic?.Login;
        return LocalRedirect($"~/user/details/{str}");
    }
    
    [HttpGet]
    public ActionResult Details([FromRoute] string login) // не получает значение
    {
        //login = "mylogin"; //test
        var userLogic = _userMapper.GetUsers().SingleOrDefault(u=>u.Login==login); // ошибка не найден
        if (userLogic == null) return BadRequest($"!!! пользователь '{login}' не найден !!!");
        var userApp = _mapper.Map<UserDtoApp>(userLogic);
       
        return View(userApp);
    }

    [HttpGet]
    public ActionResult Profile([FromRoute] int userID)
    {
        var prof = _userMapper.GetProfile(userID);
        var profApp = _mapper.Map<UserProfileDtoApp>(prof);
        return View(profApp);
    }

    [HttpGet]
    public ActionResult Setting([FromRoute] int userID)
    {
        var sett = _userMapper.GetSetting(userID);
        var settApp = _mapper.Map<UserSettingDtoApp>(sett);
        return View(settApp);
    }

    [HttpPut]
    public ActionResult Edit([FromRoute] int userID, UserDtoApp userDtoApp)
    {
        var userLogic = _mapper.Map<UserDtoLogic>(userDtoApp);
        _userMapper.UpdateUser(userID, userLogic);
        return RedirectToAction(nameof(Details), userID);
    }

    [HttpPut]
    public ActionResult EditProfile([FromRoute] int userID, UserProfileDtoApp profileDtoApp)
    {
        var userLogic = _mapper.Map<UserProfileDtoLogic>(profileDtoApp);
        _userMapper.UpdateProfile(userID, userLogic);
        return RedirectToAction(nameof(Profile), userID);
    }

    [HttpPut]
    public ActionResult EditSetting([FromRoute] int userID, UserSettingDtoApp settingDtoApp)
    {
        var settLogic = _mapper.Map<UserSettingDtoLogic>(settingDtoApp);
        _userMapper.UpdateSetting(userID, settLogic);
        return RedirectToAction(nameof(Setting), userID);
    }

    [HttpDelete]
    public ActionResult Delete([FromRoute] int userID)
    {
        var res = _userMapper.DeleteUser(userID);
        return RedirectToAction(nameof(Index));
    }

}
