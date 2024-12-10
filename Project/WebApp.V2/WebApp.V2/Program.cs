using Application.ServicesApps.Mappers.UserMappers;
using Application.ServicesApps.UserServicesApps;
using Infrastructure.Contexts.UserContexts;
using Infrastructure.Repositories.UserRepos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<UserService>();
builder.Services.AddDbContext<UserContext>();

builder.Services.AddAutoMapper(typeof(UserMapperProfile));
builder.Services.AddLogging(p => p.AddConsole());

var app = builder.Build();

app.UseRouting();
app.UseHttpsRedirection();
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseStatusCodePages();
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Menu}/{action=Index}/{id?}");


app.Run();
