using ConfSys.Domain.Entity;
using ConfSys.Shared.Core.Data;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ConfSys.Data.UnitOfWork;

public partial class ConfUnitOfWork
{
    public IGenericRepo<User> UserRepo => _dbContext.GetService<IGenericRepo<User>>();

    public IGenericRepo<Members> MemberRepo =>_dbContext.GetService<IGenericRepo<Members>>();

    public IGenericRepo<Project> ProjectRepo => _dbContext.GetService<IGenericRepo<Project>>();

    public IGenericRepo<FamilyMember> FamilyMemberRepo => _dbContext.GetService<IGenericRepo<FamilyMember>>();

    public IGenericRepo<Origin> OriginRepo => _dbContext.GetService<IGenericRepo<Origin>>();

    public ConfUnitOfWork(ConfSysDbContext dbContext) => _dbContext = dbContext;
}
