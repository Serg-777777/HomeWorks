namespace Infrastructure.DtoLogics.UserDtoLogics;

public class UserSettingDtoLogic:IUserDtoLogic
{
    public bool? IsLoadFiles { get; set; } = false;
    public bool? IsDownLoadFiles { get; set; } = true;
    public bool? IsPlacePost { get; set; } = true;
    public bool? IsReadPost { get; set; } = true;
}
