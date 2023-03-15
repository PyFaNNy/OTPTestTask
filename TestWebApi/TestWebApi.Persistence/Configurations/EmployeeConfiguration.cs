using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestWebApi.Domain.Entities;

namespace TestWebApi.Persistence.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.Property(x => x.FirstName)
            .IsRequired()
            .HasMaxLength(32);
        
        builder.Property(x => x.LastName)
            .IsRequired()
            .HasMaxLength(32);
        
        builder.Property(x => x.MiddleName)
            .IsRequired()
            .HasMaxLength(32);
        
        builder.Property(x => x.DateBirth)
            .IsRequired();

        builder.HasMany(x => x.Positions)
            .WithMany(p => p.Employees);
    }
}