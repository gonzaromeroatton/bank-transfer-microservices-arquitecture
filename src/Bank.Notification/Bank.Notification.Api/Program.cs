using Bank.Notification.Api.Application.Database;
using Bank.Notification.Api.Domain.Entities.Notification;
using Bank.Notification.Api.Persistence.Database;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IDatabaseService, DatabaseService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapGet("/notification", async ([FromServices] IDatabaseService databaseService) =>
{
    var entity = new NotificationEntity
    {
        CorrelationId = Guid.NewGuid().ToString(),
        Type = "Email",
        Content = "This is a test notification.",
        TransactionState = true,
        CustomerId = 1
    };

    await databaseService.AddAsync(entity);

    var data = await databaseService.GetAllAsync();

    return data;
});

app.Run();

