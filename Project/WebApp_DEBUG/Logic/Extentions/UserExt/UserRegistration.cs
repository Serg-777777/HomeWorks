using Microsoft.EntityFrameworkCore;
using WebApp_DEBUG.Domain.Model.UserModel;
using WebApp_DEBUG.Infrastructure.Context.UserContext;
using WebApp_DEBUG.Logic.Dto;
using WebApp_DEBUG.Logic.Dto.Mapper.UserMap;
using WebApp_DEBUG.Logic.Dto.UserDto;

public static class UserRegistration
	{
		public static IServiceCollection AddUserServices(this IServiceCollection services, IConfiguration config)
		{
                services.AddDbContext<UserContext>(p=> p.UseSqlite(@"Data Source=Domain/DBase/dbTest.db")); //JSON конфиг
			   services.AddTransient<IDtoRepository<User,UserModelDto>, UserRepository>();
				services.AddAutoMapper(typeof(UserMapperProfile));
                return services;
		}
	}
