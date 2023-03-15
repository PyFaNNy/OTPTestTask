using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using TestWebApi.Domain.Entities;

namespace TestWebApi.Persistence.Configurations;

public class PositionConfiguration : IEntityTypeConfiguration<Position>
{
    public void Configure(EntityTypeBuilder<Position> builder)
    {
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(64);
        
        builder.Property(x => x.Grade)
            .IsRequired();

        builder.HasMany(x => x.Employees)
            .WithMany(p => p.Positions);
    }
}