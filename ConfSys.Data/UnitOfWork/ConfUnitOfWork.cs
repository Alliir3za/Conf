#nullable disable
using ConfSys.Shared.Core.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ConfSys.Data.UnitOfWork;

public partial class ConfUnitOfWork : IConfUnitOfWork
{
    private readonly ConfSysDbContext _dbContext;
    public ChangeTracker ChangeTracker => _dbContext.ChangeTracker;
    public DatabaseFacade DatabaseFacade => _dbContext.Database;

    public void Dispose()
    {
        _dbContext.Dispose();
        GC.SuppressFinalize(this);
    }

    public async ValueTask DisposeAsync()
    {
        await _dbContext.DisposeAsync();
        GC.SuppressFinalize(this);
    }

    public Task<SaveChangesResult> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
