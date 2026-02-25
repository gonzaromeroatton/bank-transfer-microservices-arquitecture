using Bank.Transfer.Api.Application.Database;
using Bank.Transfer.Api.Domain.Entities.Transfer;
using Microsoft.EntityFrameworkCore;

namespace Bank.Transfer.Api.Persistence.Database;

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
    public DbSet<TransferEntity> Transfer { get; set; }

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
