

namespace Domain.Models.UserModels
{
    public partial interface IUserProfileRepository<TBaseModel> where TBaseModel : EntityBase<UserProfileModel>
    {
        UserProfileModel? GetProfileByUserId(int idUser);
        bool UpdateProfileByUserId(int idUser, string? firstName, string? lastName, string? country, string? city, int? age);
    }
}
