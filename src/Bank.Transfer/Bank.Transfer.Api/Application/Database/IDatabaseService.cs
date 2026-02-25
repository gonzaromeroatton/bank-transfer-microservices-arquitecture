using Bank.Transfer.Api.Domain.Entities.Transfer;
using Microsoft.EntityFrameworkCore;

namespace Bank.Transfer.Api.Application.Database;

/// <summary>
/// 
/// </summary>
public interface IDatabaseService
{
    /// <summary>
    /// 
    /// </summary>
    DbSet<TransferEntity> Transfer { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<bool> SaveAsync();
}
