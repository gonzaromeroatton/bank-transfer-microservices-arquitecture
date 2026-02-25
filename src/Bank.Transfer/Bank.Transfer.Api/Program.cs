using Bank.Transfer.Api.Application.Database;
using Bank.Transfer.Api.Persistence.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DatabaseService>(options =>
{
    options.UseSqlServer(builder.Configuration["TRANSFERSQLDBCONSTR"]);
});
builder.Services.AddScoped<IDatabaseService, DatabaseService>();


var app = builder.Build();
app.MapGet("/transfer", async ([FromServices] IDatabaseService databaseService) =>
{
    var data = await databaseService.Transfer.ToListAsync();

    return data;
});


app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
