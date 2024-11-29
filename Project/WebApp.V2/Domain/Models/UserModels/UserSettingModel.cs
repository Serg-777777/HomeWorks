
namespace Domain.Models.UserModels;

   sealed public class UserSettingModel: IEntity
    {
        public const string EntityName = " UserSettingMode";

        public int Id { get; private set; }
        public bool IsLoadFiles { get; private set; } = false; //загрузка файлов на сервер
        public bool IsDownLoadFiles { get; private set; } = true; //скачивание файлов с сервера
        public bool IsPlacePost { get; private set; } = true; // постить пост
        public bool IsReadPost { get; private set; } = true; // читать пост
        public int? UserModelId { get; private set; }

    public UserSettingModel(bool isLoadFiles, bool isDownLoadFiles, bool isPlaceText, bool isReadText, int? userModelId)
    {
        IsLoadFiles = isLoadFiles;
        IsDownLoadFiles = isDownLoadFiles;
        IsPlacePost = isPlaceText;
        IsReadPost = isReadText;
        UserModelId = userModelId;
    }

        

        public bool Equals(UserSettingModel? other)
        {
            return this.Id == other?.Id;
        }
    }

