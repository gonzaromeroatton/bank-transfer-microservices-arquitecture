using Bank.Transaction.Api.Application.Database;
using Bank.Transaction.Api.Persistence.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DatabaseService>(options =>
{
    options.UseSqlServer(builder.Configuration["TRANSACTIONSQLDBCONSTR"]);
});
builder.Services.AddScoped<IDatabaseService, DatabaseService>();

var app = builder.Build();

app.MapGet("/transaction", async ([FromServices] IDatabaseService databaseService) =>
{
    var data = await databaseService.Transaction.ToListAsync();

    return data;
});

app.Run();
