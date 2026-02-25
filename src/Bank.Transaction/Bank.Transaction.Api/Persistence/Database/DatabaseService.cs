using Bank.Transaction.Api.Application.Database;
using Bank.Transaction.Api.Domain.Entities.Transaction;
using Microsoft.EntityFrameworkCore;

namespace Bank.Transaction.Api.Persistence.Database;

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
    public DbSet<TransactionEntity> Transaction { get; set; }

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
