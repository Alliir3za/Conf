using ConfSys.Data.UnitOfWork;
using ConfSys.Domain.Entity;
using Quartz;

namespace ConfSys.Service.Implement;

public class OriginService : IOriginService
{
    private readonly IConfUnitOfWork _uow;
    public OriginService(IConfUnitOfWork uow) => _uow = uow;

    public async Task<List<Origin>> GetAllAsync() => await _uow.OriginRepo.ToListAsync();
}

public class OriginJob : IOriginJob
{
    private readonly IOriginService _originService;

    public OriginJob(IOriginService originService) => _originService = originService;

    public async Task Execute(IJobExecutionContext context)
    {
        var result = await _originService.GetAllAsync();
    }
}