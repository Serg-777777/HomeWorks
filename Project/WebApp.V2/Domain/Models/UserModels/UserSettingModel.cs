
namespace Domain.Models.UserModels;

   sealed public class UserSettingModel: IEntity
    {
        public const string TableName = " UserSetting";

        public int Id { get; private set; }
        public bool IsLoadFiles { get; private set; } = false; //загрузка файлов на сервер
        public bool IsDownLoadFiles { get; private set; } = true; //скачивание файлов с сервера
        public bool IsPlacePost { get; private set; } = true; // постить пост
        public bool IsReadPost { get; private set; } = true; // читать пост
        public string UserLoginKey { get; private set; }

    public UserSettingModel(int id, bool isLoadFiles, bool isDownLoadFiles, bool isPlaceText, bool isReadText, string userLoginKey)
    {
        IsLoadFiles = isLoadFiles;
        IsDownLoadFiles = isDownLoadFiles;
        IsPlacePost = isPlaceText;
        IsReadPost = isReadText;
        UserLoginKey = userLoginKey;
        Id = id;
    }

    public bool Equals(UserSettingModel? other)
        {
            return this.Id == other?.Id;
        }
    }

