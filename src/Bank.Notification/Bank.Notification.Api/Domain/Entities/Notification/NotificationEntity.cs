using Newtonsoft.Json;

namespace Bank.Notification.Api.Domain.Entities.Notification;

public sealed class NotificationEntity
{
    [JsonProperty("id")] // This is mandatory: CosmosDB requires the first character in properties names to be lowercase, and the "id" property is required for CosmosDB documents.
    public string Id { get; set; } // For CosmosDB this should be a string

    [JsonProperty("correlationId")]
    public string CorrelationId { get; set; }

    [JsonProperty("notificationDate")]
    public DateTime NotificationDate { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("content")]
    public string Content { get; set; }

    [JsonProperty("transactionState")]
    public bool TransactionState { get; set; }

    [JsonProperty("customerId")]
    public int CustomerId { get; set; }
}
