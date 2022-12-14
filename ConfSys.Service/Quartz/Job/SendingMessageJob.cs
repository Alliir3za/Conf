using ConfSys.Data.UnitOfWork;
using ConfSys.Domain;
using Microsoft.IdentityModel.Tokens;
using Quartz;

namespace ConfSys.Service;

[DisallowConcurrentExecution]
public class SendingMessageJob : IJob
{
    private readonly IConfUnitOfWork _uow;
    public SendingMessageJob(IConfUnitOfWork uow)
       => _uow = uow;

    public async Task Execute(IJobExecutionContext context)
    {
        var result = _uow.UserRepo.Where(x => x.Status == MessageType.ReadyForSent && x.SendDateTime >= DateTime.Now.AddHours(-1)).ToList();

        foreach (var item in result)
        {
            item.Status = MessageType.Sent;
            _uow.SaveChangesAsync();
        }
    }
}
