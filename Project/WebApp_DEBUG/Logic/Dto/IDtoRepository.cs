using WebApp_DEBUG.Domain.Model;

namespace WebApp_DEBUG.Logic.Dto;


public interface IDtoRepository<TEnty, out VReselt> : IDisposable where TEnty : AEntity where VReselt : IDto
{
    IReadOnlyCollection<TEnty>? Entities();
    VReselt GetEntity(int id);
    VReselt CreateEntity(in IDto entity);
    VReselt UpdateEntity(int id, in IDto entity);
    void DeleteEntity(int id);
}

