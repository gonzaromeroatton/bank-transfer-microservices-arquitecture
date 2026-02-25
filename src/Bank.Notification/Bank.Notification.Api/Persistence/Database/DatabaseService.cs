using Bank.Notification.Api.Application.Database;
using Bank.Notification.Api.Domain.Entities.Notification;
using Microsoft.Azure.Cosmos;

namespace Bank.Notification.Api.Persistence.Database;

/// <summary>
/// 
/// </summary>
public sealed class DatabaseService : IDatabaseService
{
    private readonly CosmosClient cosmosClient;
    private readonly Container container;

    public DatabaseService(IConfiguration configuration)
    {
        string connectionString = configuration["NOTIFICATIONDBCONSTR"];
        string dataBase = configuration["NOTIFICATIONDBNAME"];
        string containerName = configuration["NOTIFICATIONDBCONTAINER"];

        cosmosClient = new CosmosClient(connectionString);
        container = cosmosClient.GetContainer(dataBase, containerName);
    }

    /// <summary>
    /// Asynchronously adds a new notification entity to the data store.
    /// </summary>
    /// <param name="entity">The notification entity to add. The entity's Id and NotificationDate properties are set automatically before
    /// storage.</param>
    /// <returns>A task that represents the asynchronous operation. The task result is <see langword="true"/> if the entity was
    /// successfully added; otherwise, <see langword="false"/>.</returns>
    public async Task<bool> AddAsync(NotificationEntity entity)
    {
        entity.Id = Guid.NewGuid().ToString();
        entity.NotificationDate = DateTime.UtcNow;

        var response = await container.CreateItemAsync(entity, new PartitionKey(entity.CorrelationId));

        if(response.StatusCode == System.Net.HttpStatusCode.Created)
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// Asynchronously retrieves all notification entities from the data store.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of all <see
    /// cref="NotificationEntity"/> objects found in the data store. The list will be empty if no notifications are
    /// present.</returns>
    public async Task<List<NotificationEntity>> GetAllAsync()
    {
        var query = container.GetItemQueryIterator<NotificationEntity>("SELECT * FROM c");
        var list = new List<NotificationEntity>();

        while(query.HasMoreResults)
        {
            var response = await query.ReadNextAsync();
            list.AddRange(response);
        }
        return list;
    }
}
