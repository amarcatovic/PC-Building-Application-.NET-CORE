using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PC_Building_Application.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.EntityConfigurations
{
    public class PCConfiguration : IEntityTypeConfiguration<PC>
    {
        public void Configure(EntityTypeBuilder<PC> builder)
        {
            builder.HasKey(pc => pc.Id);

            builder.Property(pc => pc.BuildTitle)
                .IsRequired();

            builder.Property(pc => pc.BuildDescription)
                .IsRequired();

            builder.Property(pc => pc.DateBuilt)
                .IsRequired();

            builder.HasOne(pc => pc.Motherboard)
                .WithMany(m => m.PCs)
                .HasForeignKey(pc => pc.MotherboardId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(pc => pc.CPU)
                .WithMany(cpu => cpu.PCs)
                .HasForeignKey(pc => pc.CPUId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(pc => pc.User)
                .WithMany(u => u.PCs)
                .HasForeignKey(pc => pc.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(pc => pc.GPU)
                .WithMany(gpu => gpu.PCs)
                .HasForeignKey(pc => pc.GPUId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(pc => pc.Cooler)
                .WithMany(c => c.PCs)
                .HasForeignKey(pc => pc.CoolerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
