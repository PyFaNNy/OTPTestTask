using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TestWebApi.Application.Interfaces;
using TestWebApi.Domain.Entities;

namespace TestWebApi.Persistence;

public class AppDbContext : DbContext, IAppDbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Position> Positions { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
    
    public override int SaveChanges()
    {
        var result = base.SaveChanges();

        return result;
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        var result = await base.SaveChangesAsync(cancellationToken);

        return result;
    }
}