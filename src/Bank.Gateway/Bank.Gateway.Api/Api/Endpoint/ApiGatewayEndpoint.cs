using Bank.Gateway.Api.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Gateway.Api.Api.Endpoint;

/// <summary>
/// 
/// </summary>
public static class ApiGatewayEndpoint
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="app"></param>
    public static IEndpointRouteBuilder MapApiGatewayEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/api-gateway", ([FromBody] EndpointModel modelRequest) =>
        {
            return Results.Ok(modelRequest);
        })
        .WithName("ProcessGatewayRequest")
        .Produces<EndpointModel>(StatusCodes.Status200OK);

        return app;
    }
}
  