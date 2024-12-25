using Application.AppServices.UserAppServices;
using AutoMapper;
using Infrastructure.DtoLogics.UserDtoLogics;
using Microsoft.AspNetCore.Mvc;
using Presentation.Mappers.DtoViews.UserDtoViews;

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

        [HttpPost]
        public ActionResult Editing(UserProfileDtoView dtoView)
        {
            int id = (int)dtoView.UserModelId!;
            var profLogic = _profileService.GetProfile(id);
            if (profLogic != null)
            {
                var dtoLogic = _mapper.Map<UserProfileDtoLogic>(dtoView);
                var profNew = _profileService.UpdateProfile(id, dtoLogic);
                var profNewView = _mapper.Map<UserProfileDtoView>(profNew);
                profNewView.UserModelId = id;
                return LocalRedirect($"/user/info/{id}");
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
            profView.UserModelId = id;
            return View(profView);
        }

    }
}
