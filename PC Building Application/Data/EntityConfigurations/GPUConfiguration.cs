using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PC_Building_Application.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.EntityConfigurations
{
    public class GPUConfiguration : IEntityTypeConfiguration<GPU>
    {
        public void Configure(EntityTypeBuilder<GPU> builder)
        {
            builder.HasKey(gpu => gpu.Id);

            builder.Property(gpu => gpu.Name)
                .IsRequired();

            builder.Property(gpu => gpu.MemoryType)
                .IsRequired();

            builder.Property(gpu => gpu.Released)
                .IsRequired();

            builder.Property(gpu => gpu.PCIPort)
                .IsRequired();

            builder.Property(gpu => gpu.MemoryType)
                .IsRequired();

            builder.Property(gpu => gpu.VRAM)
                .IsRequired();

            builder.Property(gpu => gpu.NoOfHDMIPorts)
                .IsRequired();

            builder.Property(gpu => gpu.NoOfDisplayPorts)
                .IsRequired();

            builder.Property(gpu => gpu.HasDVI)
                .IsRequired();

            builder.Property(gpu => gpu.HasVGA)
                .IsRequired();

            builder.Property(gpu => gpu.Price)
                .IsRequired();

            builder.HasOne(gpu => gpu.Photo)
                .WithMany(p => p.GPUs)
                .HasForeignKey(gpu => gpu.PhotoId);

            builder.HasOne(gpu => gpu.Manufacturer)
                .WithMany(m => m.GPUs)
                .HasForeignKey(gpu => gpu.ManufacturerId);
        }
    }
}
