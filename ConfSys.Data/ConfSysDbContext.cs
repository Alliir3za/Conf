#nullable disable
using ConfSys.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace ConfSys.Data;

public class ConfSysDbContext : DbContext
{
    public ConfSysDbContext(DbContextOptions<ConfSysDbContext> options)
       : base(options)
    {
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Origin> Origins { get; set; }
    public DbSet<FamilyMember> FamilyMembers { get; set; }
    public DbSet<Members> Members { get; set; }
}
