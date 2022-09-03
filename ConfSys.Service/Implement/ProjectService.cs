using ConfSys.Data;
using ConfSys.Domain.Entity;
using ConfSys.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace ConfSys.Service.Implement;

public class ProjectService : IProjectService
{
    private readonly ConfSysDbContext db;
    public ProjectService()
    {
        db = new ConfSysDbContext();
    }
   
}
