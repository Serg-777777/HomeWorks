using Application.ServicesApps.Mappers.UserMappers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvcCore();
builder.Services.AddAutoMapper(typeof(UserMapperProfile));

var app = builder.Build();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.MapControllerRoute(
    name: "users",
    pattern: "User/{login}/{action}");

app.MapGet("/", () => "Welcome!!! ");
app.Run();
