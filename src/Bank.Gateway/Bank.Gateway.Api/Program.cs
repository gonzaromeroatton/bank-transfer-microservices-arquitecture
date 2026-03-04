using Bank.Gateway.Api.Api.Endpoint;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

ApiGatewayEndpoint.MapApiGatewayEndpoints(app);
// Configure the HTTP request pipeline.

app.Run();
