using ConfSys.Domain.Entity;
using Quartz;

namespace ConfSys.Service.Interface;

public interface IOriginService 
{
    Task<List<Origin>> GetAllAsync(); 
}

public interface IOriginJob : IJob {}