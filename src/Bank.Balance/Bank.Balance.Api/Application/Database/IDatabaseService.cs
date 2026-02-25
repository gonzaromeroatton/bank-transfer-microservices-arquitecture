using Bank.Balance.Api.Domain.Entities.Balance;
using Microsoft.EntityFrameworkCore;

namespace Bank.Balance.Api.Application.Database;

/// <summary>
/// 
/// </summary>
public interface IDatabaseService
{
    /// <summary>
    /// 
    /// </summary>
    DbSet<BalanceEntity> Balance { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<bool> SaveAsync();
}
