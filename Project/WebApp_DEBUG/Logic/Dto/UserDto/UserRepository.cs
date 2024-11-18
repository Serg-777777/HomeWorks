
using AutoMapper;
using WebApp_DEBUG.Domain.Model.UserModel;
using WebApp_DEBUG.Infrastructure.Context.UserContext;
namespace WebApp_DEBUG.Logic.Dto.UserDto;



partial class UserRepository : IDtoRepository<User, UserModelDto>
{
    UserContext? _context;
    IMapper _mapper;
    ILogger<UserRepository> _log;

    public UserRepository(UserContext context, IMapper mapper, ILogger<UserRepository> log)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _log = log;

    }
    public virtual UserModelDto CreateEntity(in IDto entity)
    {
        //Работает
        var e = (UserModelDto)entity;
        var r = new UserRole() { RoleName = "user" };
        var u = _mapper.Map<User>(e);
        u.UserRole = r;
        _context?.Users.Add(u);
        _context?.SaveChanges();
        return e;
    }

    public virtual IReadOnlyCollection<User>? Entities()
    {
        //!!! Ошибка - Object reference not set to an instance of an object
        var us = _context?.Users.ToList();
        return us;
    }


    public virtual void Dispose()
    {
        _context?.Dispose();
    }

    public virtual UserModelDto GetEntity(int id)
    {
        throw new NotImplementedException();
    }
    public virtual void DeleteEntity(int id)
    {
        throw new NotImplementedException();
    }

    public virtual UserModelDto UpdateEntity(int id, in IDto entity)
    {
        throw new NotImplementedException();
    }
}

