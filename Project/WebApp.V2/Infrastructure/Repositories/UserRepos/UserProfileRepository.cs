

using Domain.Models.UserModels;

namespace Infrastructure.Repositories.UserRepos
{
    sealed public partial class UserProfileRepository : IUserProfileRepository<UserProfileModel>
    {
        public UserProfileModel? GetProfileByUserId(int idUser)
        {
            var profile =new UserProfileModel().Entities().FirstOrDefault(p=> p.UserModelId == idUser);
            return profile;
        }

        public bool UpdateProfileByUserId(int idUser, string? firstName, string? lastName, string? country, string? city, int? age)
        {
            var res = new UserProfileModel().UpdateValues(idUser, firstName, lastName, country, city, age);
            return res;
        }

    }
}
