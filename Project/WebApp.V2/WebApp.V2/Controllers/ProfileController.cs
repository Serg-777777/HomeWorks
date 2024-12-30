using Application.AppServices.UserAppServices;
using AutoMapper;
using Infrastructure.DtoLogics.UserDtoLogics;
using Microsoft.AspNetCore.Mvc;
using Presentation.DtoViews.UserDtoViews;

namespace Presentation.Controllers
{
    public class ProfileController : Controller
    {
        UserProfileService _profileService;
        IMapper _mapper;
        ILogger<UserController> _logger;

        public ProfileController(UserProfileService profileService, IMapper mapper, ILogger<UserController> logger)
        {
            _profileService = profileService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("/profile/{id}")]
        public ActionResult Index([FromRoute] int id)
        {
            ViewBag.Title = "Профиль";
            var prof = _profileService.GetProfile(id);
            UserProfileDtoView? profView;
            if (prof== null)
                return BadRequest("Правка. Профиль не найден!");
            profView = _mapper.Map<UserProfileDtoView>(prof);
            return View(profView);
        }

        [HttpPost]
        public ActionResult Editing([FromRoute] int id, [FromForm] UserProfileDtoView dtoView)
        {
            var profLogic = _profileService.GetProfile(id);
            if (profLogic != null)
            {
                var dtoLogic = _mapper.Map<UserProfileDtoLogic>(dtoView);
                var profNew = _profileService.UpdateProfile(id, dtoLogic);
                var profNewView = _mapper.Map<UserProfileDtoView>(profNew);
           
                return LocalRedirect($"/profile/{id}");
            }
            return BadRequest("Editing. Нет профиля пользователя!");
        }

        [HttpGet]
        public ActionResult Edit([FromRoute] int id)
        {
            ViewBag.Title = "Профайл";
            var prof = _profileService.GetProfile(id);
            UserProfileDtoView? profView;
            if (prof == null) 
                return BadRequest("Правка. Профиль не найден!");
            profView = _mapper.Map<UserProfileDtoView>(prof);
            profView.UserId = id;
            return View(profView);
        }

    }
}
