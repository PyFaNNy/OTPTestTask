
using Microsoft.EntityFrameworkCore;
using TestWebApi.Domain.Entities;

namespace TestWebApi.Application.Interfaces;

public interface IAppDbContext
{
    DbSet<Employee> Employees
    {
        get;
        set;
    }
    
    DbSet<Position> Positions
    {
        get;
        set;
    }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    int SaveChanges();
}