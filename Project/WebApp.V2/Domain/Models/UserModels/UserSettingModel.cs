
namespace Domain.Models.UserModels;

 public class UserSettingModel : IEntity
{
    public const string TableName = " UserSetting";

    public int Id { get; set; }
    public bool IsLoadFiles { get; private set; } = false; //загрузка файлов на сервер
    public bool IsDownLoadFiles { get; private set; } = true; //скачивание файлов с сервера
    public bool IsPlacePost { get; private set; } = true; // постить пост
    public bool IsReadPost { get; private set; } = true; // читать пост
    public int UserModelId { get; set; }
    public UserModel? UserModel { get; set; }
    protected UserSettingModel() { }
    public UserSettingModel(bool isLoadFiles, bool isDownLoadFiles, bool isPlaceText, bool isReadText)
    {
        IsLoadFiles = isLoadFiles;
        IsDownLoadFiles = isDownLoadFiles;
        IsPlacePost = isPlaceText;
        IsReadPost = isReadText;

    }
    public UserSettingModel SetUserProperty(UserModel user)
    {
        UserModel = user;
        UserModelId = user.Id;
        return this;
    }
    public bool Equals(UserSettingModel? other)
    {
        return this.Id == other?.Id;
    }
    public UserSettingModel SetValues(UserSettingModel entity)
    {
        IsLoadFiles = entity.IsLoadFiles;
        IsDownLoadFiles = entity.IsDownLoadFiles;
        IsPlacePost = entity.IsPlacePost;
        IsReadPost = entity.IsReadPost;
        return this;
    }
}

