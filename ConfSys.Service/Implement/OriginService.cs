namespace ConfSys.Service.Implement;

public class OriginService : IOriginService
{
    private readonly ConfSysDbContext db;
    public OriginService() => db = new ConfSysDbContext();

    public async Task<List<Origin>> GetAllOriginAsync()
      => await db.Origins.ToListAsync();
}
