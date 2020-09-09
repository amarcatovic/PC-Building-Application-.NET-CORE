using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PC_Building_Application.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.EntityConfigurations
{
    public class CoolerConfiguration : IEntityTypeConfiguration<Cooler>
    {
        public void Configure(EntityTypeBuilder<Cooler> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired();

            builder.Property(c => c.Released)
                .IsRequired();

            builder.Property(c => c.IsWaterCooler)
                .IsRequired();

            builder.Property(c => c.HasRGB)
                .IsRequired();

            builder.Property(c => c.Price)
                .IsRequired();

            builder.HasOne(c => c.Photo)
                .WithMany(p => p.Coolers)
                .HasForeignKey(c => c.PhotoId);

            builder.HasOne(c => c.Manufacturer)
                .WithMany(m => m.Coolers)
                .HasForeignKey(c => c.ManufacturerId);
        }
    }
}
