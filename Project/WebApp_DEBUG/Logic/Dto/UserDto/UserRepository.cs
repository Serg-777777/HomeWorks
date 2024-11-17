
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApp_DEBUG.Domain.Model.UserModel;
using WebApp_DEBUG.Infrastructure.Context.UserContext;
using WebApp_DEBUG.Logic.Dto;
namespace WebApp_DEBUG.Logic.Dto.UserDto;



partial class UserRepository : IDtoRepository<User, UserModelDto>
{
    List<User> _users; // тест
    UserContext? _context = null;
    IMapper _mapper;
    ILogger<UserRepository> _log;

    public UserRepository(UserContext context, IMapper mapper, ILogger<UserRepository> log)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _log = log;
        // тест
        _users = new();
        var role = new UserRole() { RoleName = "admin" };
        var user = new User() { Id = 0, Login = "Woman", UserRole = role };
        _users.Add(user);
        user = new User() { Id = 1, Login = "Man", UserRole = role };
        _users.Add(user);
    }


    public virtual IReadOnlyCollection<User>? Entities()
    {
        //!!! Ошибка - Object reference not set to an instance of an object

        _log.LogWarning($"$$$ Count: {_context?.Users.Count()}");
        var us = _context?.Users.ToList();
        return us;

        // return _users.ToList();//тестинг
    }

    public virtual void DeleteEntity(int id)
    {
        throw new NotImplementedException();
    }

    public virtual void Dispose()
    {
        //  if (_context != null)
        //  _context.Dispose();
    }

    public virtual UserModelDto GetEntity(int id)
    {
        var u = _context?.Users.AsNoTracking().SingleOrDefault(p => p.Id == id);
        var m = _mapper.Map<UserModelDto>(u);
        return m;
    }

    public virtual UserModelDto CreateEntity(in IDto entity)
    {
        var e = (UserModelDto)entity;
        var r = new UserRole() { RoleName = "user" };
        var u = _mapper.Map<User>(e);
        u.UserRole = r;
        _context?.Users.Add(u);
        _context?.SaveChanges();
        return e;
    }

    public virtual UserModelDto UpdateEntity(int id, in IDto entity)
    {
        var e = (UserModelDto)entity;
        var m = _mapper.Map<User>(e);
        m.Id = id;
        _context?.Users.Update(m);
        _context?.SaveChanges();
        return e;
    }
}

