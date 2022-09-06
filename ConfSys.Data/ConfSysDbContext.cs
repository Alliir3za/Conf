#nullable disable
using ConfSys.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace ConfSys.Data;

public class ConfSysDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Origin> Origins { get; set; }
    public DbSet<FamilyMember> FamilyMembers { get; set; }
    public DbSet<Members> Members { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("server=.;database=Confsys;trusted_connection=true;");
        base.OnConfiguring(optionsBuilder);
    }
}
