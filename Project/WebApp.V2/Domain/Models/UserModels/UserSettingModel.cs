
namespace Domain.Models.UserModels;

   sealed public partial class UserSettingModel:EntityBase<UserSettingModel>, IEntity
    {
        public const string EntityName = " UserSettingMode";

        public int? Id { private set; get; }
        public bool isLoadFiles { private set; get; } = false; //загрузка файлов на сервер
        public bool isDownLoadFiles { private set; get; } = true; //скачивание файлов с сервера
        public int? UserModelId { private set; get; }

        public UserSettingModel(int id, bool isLoadFiles, bool isDownLoadFiles, int userModelId)
        {
            Id = id;
            this.isLoadFiles = isLoadFiles;
            this.isDownLoadFiles = isDownLoadFiles;
            UserModelId = userModelId;
        }
        public UserSettingModel()
         {
            this.Id = null;
            this.UserModelId=null;
         }
         
        public bool UpdateValues(int idUser, bool isLoadFiles, bool isDownLoadFiles)
        {
            var settings = base._entities.Value.FirstOrDefault(s => s.UserModelId == idUser);

            if(settings!=null)
            {
                settings.isLoadFiles = isLoadFiles;
                settings.isDownLoadFiles = isDownLoadFiles;
                return true;
            }
             return false;
        }

        public UserSettingModel? AddSettings()
        {
            if(this.Id!=null)
                return base.AddEntity(this);
            return null;
        }
        public bool RemoveSettings()
        {
            if (this.Id != null)
             return base.RemoveEntity(this);
            return false;
        }

        public override bool Equals(UserSettingModel? other)
        {
            return this.Id == other?.Id;
        }
    }

