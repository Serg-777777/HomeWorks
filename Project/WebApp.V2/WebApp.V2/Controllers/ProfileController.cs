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
        public ActionResult Editing([FromRoute] int idUser, UserProfileDtoView dtoView)
        {
            var profLogic = _profileService.GetProfile(idUser);
            if (profLogic != null)
            {
                var dtoLogic = _mapper.Map<UserProfileDtoLogic>(dtoView);
                var profNew = _profileService.UpdateProfile(idUser, dtoLogic);
                var profNewView = _mapper.Map<UserProfileDtoView>(profNew);
            }
            return LocalRedirect($"/user/info/{idUser}");
        }

        [HttpGet]
        public ActionResult Edit([FromRoute] int idUser)
        {
            ViewBag.UserId = idUser;
            ViewBag.Title = "Профайл";
            var prof = _profileService.GetProfile(idUser);
            UserProfileDtoView? profView;
            if (prof != null)
            {
                profView = _mapper.Map<UserProfileDtoView>(prof);
            }
            else
                profView = new UserProfileDtoView();

            return View(profView);
        }

    }
}
