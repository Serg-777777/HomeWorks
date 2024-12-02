namespace Infrastructure.DtoLogics.UserDtoLogics;

public class UserSettingDtoLogic:IUserDtoLogic
{
    public bool? IsLoadFiles { get; set; }
    public bool? IsDownLoadFiles { get; set; }
    public bool? IsPlacePost { get; set; }
    public bool? IsReadPost { get; set; }
}
