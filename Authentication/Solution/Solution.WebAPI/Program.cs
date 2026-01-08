using Solution.WebAPI.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.LoadEnvironmentVariables()
       .ConfigureDI()
       .LoadSettings()
       .ConfigureDatabase()
       .UseIdentity()
       .UseSecurity();

builder.Services.AddOpenApi();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();
app.UseSecurity();
app.MapControllers();


await app.RunAsync();
