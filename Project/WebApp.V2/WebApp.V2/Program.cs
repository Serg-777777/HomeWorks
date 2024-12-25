using Application.ServicesViews.Mappers.UserMappers;
using Presentation.Configs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddControllersWithViews();
builder.Services.AddUsersServices(builder.Configuration); 
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
