#nullable disable
using ConfSys.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace ConfSys.Data;

public class ConfSysDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("server =.; database = Confsys; trusted_connection = true; ");
        base.OnConfiguring(optionsBuilder);
    }
    public DbSet<User> Users { get; set; }
    public DbSet<City> Cities { get; set; }

}

