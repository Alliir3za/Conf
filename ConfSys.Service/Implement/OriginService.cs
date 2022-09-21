using ConfSys.Domain.Entity;

namespace ConfSys.Service.Implement;

public class OriginService : IOriginService
{
    private readonly ConfSysDbContext _db;
    public OriginService(ConfSysDbContext db) => _db = db;

    public async Task<List<Origin>> GetAllAsync()
      => await _db.Origins.ToListAsync();
}
