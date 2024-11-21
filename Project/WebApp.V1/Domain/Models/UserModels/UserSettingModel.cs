

namespace Domain.Models.UserModel
{
    public class UserSettingModel:IEntity
    {
        public const string EntityName = " UserSettingMode";

        public int Id { set; get; }
        public bool isLoadFiles { set; get; } = false;
        public bool isDownLoadFiles { set; get; } = true;

        public required int UserModelId { set; get; }
    }
}
