
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

        public async Task<UserProfileDtoLogic>? GetProfileAsync(int idUser)
        {
            var prof = await _profileRepository.GetEntityAsync(idUser)!;
            if (prof != default)
            {
                var profLogic = _mapper.Map<UserProfileDtoLogic>(prof);
                return profLogic;
            }
            return null!;
        }

        public async Task<UserProfileDtoLogic>? CreateProfileAsync(UserProfileDtoLogic userProfileDto)
        {
            var prof = _mapper.Map<UserProfileModel>(userProfileDto);
            var profNew = await _profileRepository.AddEntityAsync(prof)!;
            var profNewView = _mapper.Map<UserProfileDtoLogic>(profNew);
            return profNewView;
        }

        public async Task<bool> DeleteProfileAsync(int idUser)
        {
            var res = await _profileRepository.RemoveEntityAsync(idUser);
            return res;
        }

        public async Task<UserProfileDtoLogic>? UpdateProfileAsync(int idUser, UserProfileDtoLogic userProfileDto)
        {
            var prof = _mapper.Map<UserProfileModel>(userProfileDto);
            var profNew = await _profileRepository.UpdateEntityAsync(idUser, prof)!;
            var profNewView = _mapper.Map<UserProfileDtoLogic>(profNew);
            return profNewView;
        }

    }

}
