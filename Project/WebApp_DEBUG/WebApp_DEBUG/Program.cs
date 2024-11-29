


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHostedServices(); //����������� ������� ��������
builder.Services.AddUserServices(builder.Configuration); //����������� �������� ������������+context

builder.Services.AddControllers();
builder.Services.AddControllersWithViews( );
builder.Services.AddLogging(p => p.AddConsole());

var app = builder.Build();
app.UseRouting();
app.UseHttpsRedirection();
app.MapControllers();

app.UseMonitorRequest(); //����������� ���� middle ������������ 

app.MapControllerRoute(
    name: "user",
    pattern: "user/{action?}/{Id?}");

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{Id:int?}"); //������ �������������




app.Run();
