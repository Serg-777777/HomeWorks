using Application.AppServices.UserAppServices;
using AutoMapper;
using Infrastructure.DtoLogics.UserDtoLogics;
using Microsoft.AspNetCore.Mvc;
using Presentation.DtoViews.UserDtoViews;
using Presentation.Validation;

namespace Presentation.Controllers
{
    public class ProfileController : Controller
    {
        private UserProfileService _profileService;
        private IValidationUserProfile _validationProfile;
        private IMapper _mapper;
        private ILogger<UserController> _logger;


        public ProfileController(UserProfileService profileService, IMapper mapper, ILogger<UserController> logger, IValidationUserProfile validation)
        {
            _profileService = profileService;
            _mapper = mapper;
            _logger = logger;
            _validationProfile = validation;
        }

        [HttpGet("/profile/{id}")]
        public ActionResult Index([FromRoute] int idUser)
        {
            //validation
            var res = _validationProfile.Validate(idUser);
            if (!res.IsValid) return BadRequest(res.Errors[0].ErrorMessage);
            //validation

            ViewBag.Title = "Профиль";
            var prof = _profileService.GetProfileAsync(idUser);
            UserProfileDtoView? profView;
            if (prof== null)
                return BadRequest("Правка. Профиль не найден!");
            profView = _mapper.Map<UserProfileDtoView>(prof);
            return View(profView);
        }

        [HttpPost]
        public ActionResult Editing([FromRoute] int idUser, [FromForm] UserProfileDtoView dtoView)
        {
            //validation
            var res = _validationProfile.Validate(idUser, dtoView);
            if (!res.IsValid) return BadRequest(res.Errors[0].ErrorMessage);
            //validation

            var profLogic = _profileService.GetProfileAsync(idUser);
            if (profLogic != default)
            {
                var dtoLogic = _mapper.Map<UserProfileDtoLogic>(dtoView);
                var profNew = _profileService.UpdateProfileAsync(idUser, dtoLogic);
                var profNewView = _mapper.Map<UserProfileDtoView>(profNew);
           
                return LocalRedirect($"/profile/{idUser}");
            }
            return BadRequest("Editing. Нет профиля пользователя!");
        }

        [HttpGet]
        public ActionResult Edit([FromRoute] int idUser)
        {
            //validation
            var res = _validationProfile.Validate(idUser);
            if (!res.IsValid) return BadRequest(res.Errors[0].ErrorMessage);
            //validation

            ViewBag.Title = "Профайл";
            var prof = _profileService.GetProfileAsync(idUser);
            UserProfileDtoView? profView;
            if (prof == null) 
                return BadRequest("Правка. Профиль не найден!");
            profView = _mapper.Map<UserProfileDtoView>(prof);
            profView.UserId = idUser;
            return View(profView);
        }

    }
}
