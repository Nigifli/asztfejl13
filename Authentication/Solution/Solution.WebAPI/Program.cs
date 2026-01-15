using Solution.WebAPI.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.LoadEnvironmentVariables()
       .ConfigureDI()
       .LoadSettings()
       .ConfigureDatabase()
       .UseIdentity()
       .UseSecurity()
       //.UseScalarOpenAPI()
       //.UseSwashbuckleOpenAPI()
       .UseReDocOpenAPI();

builder.Services.AddOpenApi();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();
app.UseSecurity();
app.MapControllers();
//app.UseScalarOpenAPI();
//app.UseSwashbuckleOpenAPI();
app.UseReDocOpenAPI();


await app.RunAsync();
