using ConfSys.Domain.Entity;
using ConfSys.Shared.Core.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ConfSys.Data.UnitOfWork;

public interface IConfUnitOfWork : IDisposable, IAsyncDisposable
{
    public ChangeTracker ChangeTracker { get; }
    public DatabaseFacade DatabaseFacade { get; }

    public Task<SaveChangesResult> SaveChangesAsync(CancellationToken cancellationToken = default);

    #region Auth
    public IGenericRepo<User> UserRepo { get; }
    public IGenericRepo<Members> MemberRepo { get; }
    public IGenericRepo<Project> ProjectRepo { get; }
    public IGenericRepo<FamilyMember> FamilyMemberRepo { get; }
    public IGenericRepo<Origin> OriginRepo { get; }
    #endregion
}