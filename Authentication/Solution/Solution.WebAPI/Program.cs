using Solution.WebAPI.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.LoadEnvironmentVariables()
       .ConfigureDatabase();

builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
