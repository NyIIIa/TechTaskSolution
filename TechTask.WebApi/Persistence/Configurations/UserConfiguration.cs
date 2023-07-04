using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechTask.WebApi.Domain.Entities;

namespace TechTask.WebApi.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        //configure properties

        //configure relationships
        builder.HasMany(u => u.Estates).WithOne(e => e.User);
    }
}