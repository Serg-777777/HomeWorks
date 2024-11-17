


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHostedServices(); //регистрация фоновых сервисов
builder.Services.AddUserServices(builder.Configuration); //регистрация сервисов пользователя+context

builder.Services.AddControllers();
builder.Services.AddControllersWithViews( );
builder.Services.AddLogging(p => p.AddConsole());

var app = builder.Build();
app.UseRouting();
app.UseHttpsRedirection();
app.MapControllers();

app.UseMonitorRequest(); //регистрация слоя middle пользователя 

app.MapControllerRoute(
    name: "user",
    pattern: "user/{action?}/{Id?}");

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{Id:int?}"); //шаблон представления




app.Run();
