namespace Domain.Models.Files;

public class FileModel : EntityBase
{

    public DateTime? DateCreated { get; private set; }
    public string FileName { get; private set; }
    public string? FullPath { get; private set; }
    public string UserKey { get; private set; }
    public string Index_UserKey_FileName { get; private set; }
    

    public FileModel(string userKey, string nameFile) 
    {
        UserKey = userKey;
        FileName = nameFile;
        DateCreated = DateTime.Now;
        Index_UserKey_FileName = string.Concat(UserKey, "_", FileName);
    }
    public FileModel SetFullPath(string path)
    {
        FullPath = path;
        return this;
    }
}
