using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechTask.WebApi.Domain.Entities;

namespace TechTask.WebApi.Persistence.Configurations;

public class EstateConfiguration : IEntityTypeConfiguration<Estate>
{
    public void Configure(EntityTypeBuilder<Estate> builder)
    {
        //configure properties
        
        //configure relationships
        builder.HasOne(e => e.User).WithMany(u => u.Estates);
    }
}