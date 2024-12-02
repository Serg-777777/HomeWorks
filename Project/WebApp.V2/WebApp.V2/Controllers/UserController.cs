using Microsoft.AspNetCore.Mvc;
using Application.ServicesApps.UserServicesApps;
using Application.DtoApps.UserDtoApps;
using AutoMapper;
using Infrastructure.DtoLogics.UserDtoLogics;

namespace WebApp.V2.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private UserAdapterService _userAdapter;
    private IMapper _mapper;

    public UserController(UserAdapterService userAdapter, IMapper mapper, ILogger<UserController> logger)
    {
        _logger = logger;
        _userAdapter = userAdapter;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<UserDtoApp> GetAccountForm()
    {
        return Ok(new UserDtoApp ());
    }

    [HttpGet("{login:maxlength(20)}")]
    public ActionResult<UserDtoApp> GetUser([FromQuery] string login)
    {
        var userLogic = _userAdapter.GetUser(login);
        var userApp = _mapper.Map<UserDtoApp>(userLogic);
        return Ok(userApp);
    }

    [HttpGet("all")]
    public ActionResult<IReadOnlyCollection<UserDtoApp>> GetUsers()
    {
        var us = _userAdapter.GetUsers();
        var ms = _mapper.Map<IReadOnlyCollection<UserDtoApp>>(us);
        return Ok(ms);
    }

    [HttpPost]
    public ActionResult<UserDtoApp> AddUser(UserDtoApp userDtoApp)
    {
        var userLogic = _mapper.Map<UserDtoLogic>(userDtoApp);
       var res =  _userAdapter.CreateUser(userLogic);
        return Ok(userDtoApp);
    }
    [HttpPost]
    public ActionResult<UserDtoApp> AddUser(UserDtoApp userDtoApp, UserProfileDtoApp userProfileDtoApp, UserSettingDtoApp userSettingDtoApp)
    {
        var userLogic = _mapper.Map<UserDtoLogic>(userDtoApp);
        var profLogic = _mapper.Map<UserDtoLogic>(userProfileDtoApp);
        var settLogic = _mapper.Map<UserSettingDtoLogic>(userSettingDtoApp);
        _userAdapter.CreateUser(userLogic, profLogic, settLogic);
        return Ok(userDtoApp);
    }

    [HttpPut("profile/update/{login}")]
    public ActionResult<UserProfileDtoApp> UpdateProfile([FromQuery] string login, [FromBody] UserProfileDtoApp userProfile)
    {
        var userProfileLogic = _mapper.Map<UserProfileDtoLogic>(userProfile);
        _userAdapter.UpdateProfile(login, userProfileLogic);
        return Ok(userProfile);
    }

    [HttpGet("profile/{login}")]
    public ActionResult<UserProfileDtoApp?> GetProfile([FromQuery] string login)
    {
        var profileLogic = _userAdapter.GetProfile(login);
        var profileApp = _mapper.Map<UserProfileDtoApp>(profileLogic);
        return profileApp;
    }
    
}
