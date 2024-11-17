
using WebApp_DEBUG.Domain.Dto;
using WebApp_DEBUG.Domain.Dto.Mapper.UserDtoMapper;
using WebApp_DEBUG.Domain.Dto.UserDto;
using WebApp_DEBUG.Domain.Model.UserModel;

public static class UserRegistration
	{
		public static IServiceCollection AddUserServices(this IServiceCollection services, IConfiguration config)
		{
				services.AddDbContext<UserContext>();
	 			services.AddScoped<IDtoRepository<User,UserModelDto>, UserRepository>();
				services.AddAutoMapper(typeof(UserMapperProfile));
                return services;
		}
	}
