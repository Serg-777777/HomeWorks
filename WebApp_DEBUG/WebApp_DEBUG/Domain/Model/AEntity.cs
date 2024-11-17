namespace WebApp_DEBUG.Domain.Model;

public abstract class AEntity
{
    public string EntityNameBase { get; }
    public AEntity(string entityName)
    {
        EntityNameBase = entityName;
    }
}


