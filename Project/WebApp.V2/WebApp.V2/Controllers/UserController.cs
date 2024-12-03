using Application.DtoApps.UserDtoApps;
using Application.ServicesApps.UserServicesApps;
using AutoMapper;
using Infrastructure.DtoLogics.UserDtoLogics;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Views.UserController
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private UserMapperService _userAdapter;
        private IMapper _mapper;
        public UserController(UserMapperService userAdapter, IMapper mapper, ILogger<UserController> logger)
        {
            _logger = logger;
            _userAdapter = userAdapter;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var userDtoApp = new UserDtoApp();
            ViewBag.Profile = new UserProfileDtoApp();
            ViewBag.Setting = new UserSettingDtoApp();
            return View(userDtoApp);
        }

        [HttpGet]
        public ActionResult Details(string login)
        {
            var userLogic = _userAdapter.GetUser(login);
            var userApp = _mapper.Map<UserDtoApp>(userLogic);
            return View(userApp);
        }

        [HttpGet]
        public ActionResult Profile(string login)
        {
            var prof = _userAdapter.GetProfile(login);
            var profApp = _mapper.Map<UserProfileDtoApp>(prof);
            return View(profApp);
        }

        [HttpGet]
        public ActionResult Setting(string login)
        {
            var sett = _userAdapter.GetSetting(login);
            var settApp = _mapper.Map<UserSettingDtoApp>(sett);
            return View(settApp);
        }

        [HttpPost]
        public ActionResult Add(UserDtoApp userDtoApp, UserProfileDtoApp profileDtoApp)
        {
            var userLogic = _mapper.Map<UserDtoLogic>(userDtoApp);
            var profLogic = _mapper.Map<UserProfileDtoLogic>(profileDtoApp);
            _userAdapter.CreateUser(userLogic, profLogic);

            return RedirectToAction(nameof(Details), userLogic.Login);
        }

        [HttpPut]
        public ActionResult EditUser(string login, UserDtoApp userDtoApp)
        {
            var userLogic = _mapper.Map<UserDtoLogic>(userDtoApp);
            _userAdapter.UpdateUser(login, userLogic);
            return RedirectToAction(nameof(Details), userLogic.Login);
        }

        [HttpPut]
        public ActionResult EditProfile(string login, UserProfileDtoApp profileDtoApp)
        {
            var userLogic = _mapper.Map<UserProfileDtoLogic>(profileDtoApp);
            _userAdapter.UpdateProfile(login, userLogic);
            return RedirectToAction(nameof(Profile), $"{login}/profile");
        }

        [HttpPut]
        public ActionResult EditeSetting(string login, UserSettingDtoApp settingDtoApp)
        {
            var settLogic = _mapper.Map<UserSettingDtoLogic>(settingDtoApp);
            _userAdapter.UpdateSetting(login, settLogic);
            return RedirectToAction(nameof(Setting), $"{login}/setting");
        }

        [HttpDelete]
        public ActionResult Delete(string login)
        {
            var userLogic = new UserDtoLogic() { Login = login };
            var res = _userAdapter.DeleteUser(userLogic);
            return RedirectToAction(nameof(Index));
        }

        //rкак получить несколько объектов из тела запроса?
        [NonAction]
        public ActionResult Create(IFormCollection collection)
        {
            return RedirectToAction(nameof(Index));
        }

    }
}
