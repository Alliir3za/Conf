using ConfSys.Domain.Entity;

namespace ConfSys.Service.Interface;

public interface IOriginService
{
    Task<List<Origin>> GetAllAsync(); 
}
