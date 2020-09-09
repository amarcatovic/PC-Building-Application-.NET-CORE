using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PC_Building_Application.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.EntityConfigurations
{
    public class PowerSupplyConfiguration : IEntityTypeConfiguration<PowerSupply>
    {
        public void Configure(EntityTypeBuilder<PowerSupply> builder)
        {
            builder.HasKey(ps => ps.Id);

            builder.Property(ps => ps.Name)
                .IsRequired();

            builder.Property(ps => ps.Power)
                .IsRequired();

            builder.HasOne(ps => ps.Photo)
                .WithMany(p => p.PowerSupplies)
                .HasForeignKey(ps => ps.PhotoId);

            builder.HasOne(ps => ps.Manufacturer)
                .WithMany(m => m.PowerSupplies)
                .HasForeignKey(ps => ps.ManufacturerId);
        }
    }
}
