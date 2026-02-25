using Bank.Balance.Api.Application.Database;
using Bank.Balance.Api.Domain.Entities.Balance;
using Microsoft.EntityFrameworkCore;

namespace Bank.Balance.Api.Persistence.Database;

/// <summary>
/// 
/// </summary>
public sealed class DatabaseService : DbContext, IDatabaseService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="options"></param>
    public DatabaseService(DbContextOptions options) : base(options)
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public DbSet<BalanceEntity> Balance { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<bool> SaveAsync()
    {
        return await SaveChangesAsync() > 0;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
