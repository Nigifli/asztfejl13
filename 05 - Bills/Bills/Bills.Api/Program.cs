using Bills.Api.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.LoadAppSettingsVariables()
       .ConfigureDI()
       .ConfigureDatabase();

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
