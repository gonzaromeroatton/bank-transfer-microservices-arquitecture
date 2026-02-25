using Bank.Notification.Api.Domain.Entities.Notification;
using Microsoft.Azure.Cosmos;

namespace Bank.Notification.Api.Application.Database;

/// <summary>
/// 
/// </summary>
public interface IDatabaseService
{
    Task<bool> AddAsync(NotificationEntity entity);
    Task<List<NotificationEntity>> GetAllAsync();
}
