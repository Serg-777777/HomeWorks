using Presentation.Config;

var builder = WebApplication.CreateBuilder();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRegistrServices(); //сервисы
builder.Services.AddControllersWithViews();

var app = builder.Build();
app.UseRouting();
app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.MapControllers();
app.MapControllerRoute(
    name:"defaukt",
    pattern: "{controller=FileLoader}/{action=Index}/{id?}");

app.Run();
