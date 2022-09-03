using ConfSys.Domain.Entity;

namespace ConfSys.Service.Interface;

public interface IOriginService
{
    public Task<List<Origin>> OriginsList(string origin);
}
