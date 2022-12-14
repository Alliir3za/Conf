#nullable disable
using ConfSys.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace ConfSys.Data;

public class ConfSysDbContext : DbContext
{
    public ConfSysDbContext(DbContextOptions<ConfSysDbContext> options) : base(options)
    => ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

    public ConfSysDbContext() => ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    
}