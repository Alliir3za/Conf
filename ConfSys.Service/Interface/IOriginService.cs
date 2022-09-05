namespace ConfSys.Service.Interface;

public interface IOriginService
{
    Task<List<Origin>> GetAllOriginAsync();
}
