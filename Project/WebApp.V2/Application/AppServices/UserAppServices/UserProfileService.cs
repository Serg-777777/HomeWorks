
using AutoMapper;
using Domain.Models.UserModels;
using Infrastructure.DtoLogics.UserDtoLogics;

namespace Application.AppServices.UserAppServices
{
    public class UserProfileService
    {
        private IMapper _mapper;
        private IUserProfileRepository _profileRepository;

        public UserProfileService(IUserProfileRepository profileRepository, IMapper mapper)
        {
            _mapper = mapper;
            _profileRepository = profileRepository;
        }

        public UserProfileDtoLogic? GetProfile(int idUser)
        {
            var prof = _profileRepository.GetEntity(idUser);
            if (prof != null)
            {
                var profLogic = _mapper.Map<UserProfileDtoLogic>(prof);
                return profLogic;
            }
            return null;
        }

        public UserProfileDtoLogic? CreateProfile(UserProfileDtoLogic userProfileDto)
        {
            var prof = _mapper.Map<UserProfileModel>(userProfileDto);
            var profNew = _profileRepository.AddEntity(prof);
            var profNewView = _mapper.Map<UserProfileDtoLogic>(profNew);
            return profNewView;
        }

        public bool DeleteProfile(int idUser)
        {
            var res = _profileRepository.RemoveEntity(idUser);
            return res;
        }

        public UserProfileDtoLogic? UpdateProfile(int idUser, UserProfileDtoLogic userProfileDto)
        {
            var prof = _mapper.Map<UserProfileModel>(userProfileDto);
            var profNew = _profileRepository.UpdateEntity(idUser, prof);
            var profNewView = _mapper.Map<UserProfileDtoLogic>(profNew);
            return profNewView;
        }

    }

}
