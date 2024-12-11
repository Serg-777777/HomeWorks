namespace Presentation.Mappers.DtoViews.UserDtoViews;

public class UserSettingDtoView : IUserDtoView
{
    public bool? IsLoadFiles { get; set; }
    public bool? IsDownLoadFiles { get; set; }
    public bool? IsPlacePost { get; set; }
    public bool? IsReadPost { get; set; }
}
