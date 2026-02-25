namespace Bank.Gateway.Api.Application.Models;

/// <summary>
/// 
/// </summary>
public sealed class EndpointModel
{
    public int CustomerId { get; set; }
    public decimal Amount { get; set; }
    public string SourceAccount { get; set; } = string.Empty;
    public string DestinationAccount { get; set; } = string.Empty;
}
