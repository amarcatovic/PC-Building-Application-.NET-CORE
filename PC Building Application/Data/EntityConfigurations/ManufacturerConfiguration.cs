using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PC_Building_Application.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.EntityConfigurations
{
    public class ManufacturerConfiguration : IEntityTypeConfiguration<Manufacturer>
    {
        public void Configure(EntityTypeBuilder<Manufacturer> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Name)
                .IsRequired();

            builder.Property(m => m.Country)
                .IsRequired();

            builder.Property(m => m.City)
                .IsRequired();

            builder.HasMany(m => m.Motherboards)
                .WithOne(mb => mb.Manufacturer)
                .HasForeignKey(mb => mb.ManufacturerId);

            builder.HasMany(m => m.CPUs)
                .WithOne(cpu => cpu.Manufacturer)
                .HasForeignKey(cpu => cpu.ManufacturerId);

            builder.HasIndex(m => m.Name);

            builder.Property(m => m.PhotoId)
                .HasDefaultValue(1);

            builder.HasOne(m => m.Photo)
                .WithMany(p => p.Manufacturers)
                .HasForeignKey(m => m.PhotoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
