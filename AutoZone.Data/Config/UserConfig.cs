using AutoZone.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoZone.Data.Config
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Username).IsRequired();
            entity.Property(x => x.Email).IsRequired();
            entity.HasMany(x => x.Vehicles).WithOne(x => x.User).HasForeignKey(x => x.UserId);
            entity.HasMany(x => x.Transactions).WithOne(x => x.User).HasForeignKey(x => x.UserId);
            entity.Property(x => x.Role).HasConversion<int>();
        }
    }
}
