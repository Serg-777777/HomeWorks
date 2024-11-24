
namespace Domain.Models.UserModels;

   sealed public partial class UserSettingModel:EntityBase<UserSettingModel>, IEntity
    {
        public const string EntityName = " UserSettingMode";

        public UserSettingModel(int id, bool isLoadFiles, bool isDownLoadFiles, int userModelId)
        {
            Id = id;
            this.isLoadFiles = isLoadFiles;
            this.isDownLoadFiles = isDownLoadFiles;
            UserModelId = userModelId;
        }

        public int Id {private set; get; }
        public bool isLoadFiles { private set; get; } =false; //загрузка файлов на сервер
        public bool isDownLoadFiles {private set; get; } = true; //скачивание файлов с сервера
        public int UserModelId {private set; get; }

        public UserSettingModel? AddSettings()
        {
            return base.AddEntity(this);
        }
        public bool RemoveSettings()
        {
            return base.RemoveEntity(this);
        }

        public override bool Equals(UserSettingModel? other)
        {
            return this.Id == other?.Id;
        }
    }

