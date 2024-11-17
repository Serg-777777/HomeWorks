
using Microsoft.AspNetCore.Mvc;
using WebApp_DEBUG.Domain.Model.UserModel;
using WebApp_DEBUG.Logic.Dto;
using WebApp_DEBUG.Logic.Dto.UserDto;

namespace WebApp_DEBUG.Infrastructure.Api.UserApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IDtoRepository<User, UserModelDto> _users;
        public UserController(IDtoRepository<User, UserModelDto> users)
        {
            _users = users;
        }

        [HttpGet]
        //     [Authorize]
        public IReadOnlyCollection<User> Get()
        {
            return _users.Entities()!;
        }

        [HttpGet("{id:int}")]
        public UserModelDto Get(int id)
        {
            var u = _users.GetEntity(id);

            return u!;

        }

        [HttpPost]
        public void Post([FromBody] UserModelDto user)
        {
            _users.CreateEntity(user);
        }

        [HttpPut("{id:int}")]
        public void Put(int id, [FromBody] UserCurrentDto user)
        {
            _users.UpdateEntity(id, user);
        }

        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {
            _users.DeleteEntity(id);
        }
    }
}
