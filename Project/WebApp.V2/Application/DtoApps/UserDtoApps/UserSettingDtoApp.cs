

namespace Application.DtoApps.UserDtoApps;

public class UserSettingDtoApp:IUserDtoApp
{
    public bool? IsLoadFiles { get; set; }
    public bool? IsDownLoadFiles { get; set; }
    public bool? IsPlacePost { get; set; }
    public bool? IsReadPost { get; set; }
}
