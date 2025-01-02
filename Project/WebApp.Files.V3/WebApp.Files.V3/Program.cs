using Presentation.Config;

var builder = WebApplication.CreateBuilder();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddRegistrServices(); //сервисы
builder.Services.AddControllersWithViews();

var app = builder.Build();
app.UseRouting();
app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapControllers();
app.MapControllerRoute(
    name:"defaukt",
    pattern: "{controller=FileHtml}/{action=Index}/{id?}");

app.Run();
