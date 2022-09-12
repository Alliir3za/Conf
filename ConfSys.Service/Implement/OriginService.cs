namespace ConfSys.Service.Implement;

public class OriginService : IOriginService
{
    private readonly ConfSysDbContext db;
    public OriginService() => db = new ConfSysDbContext();

    public async Task<List<Origin>> GetAllAsync()
      => await db.Origins.ToListAsync();
}
