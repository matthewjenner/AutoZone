using AutoZone.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoZone.Data.Config
{
    public class VehicleConfig : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> entity)
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Make).IsRequired();
            entity.Property(x => x.Model).IsRequired();
            entity.Property(x => x.Price).HasPrecision(18, 2);
            entity.HasOne(x => x.User).WithMany(x => x.Vehicles).HasForeignKey(x => x.UserId);
        }
    }
}
