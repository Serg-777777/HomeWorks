namespace Presentation.Mappers.DtoViews.UserDtoViews
{
    public class UserInfoDtoView
    {
        public UserInfoDtoView(UserFullDtoView? account, UserProfileDtoView? profile)
        {
            Account = account;
            Profile = profile;
        }

        public UserFullDtoView? Account { get; private set; }
        public UserProfileDtoView? Profile { get; private set; }
    }
}
