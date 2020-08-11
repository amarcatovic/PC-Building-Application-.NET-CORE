using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PC_Building_Application.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.EntityConfigurations
{
    public class MotherboardConfiguration : IEntityTypeConfiguration<Motherboard>
    {
        public void Configure(EntityTypeBuilder<Motherboard> builder)
        {

            builder.Property(m => m.Name)
                .IsRequired();

            builder.Property(m => m.Released)
               .IsRequired();

            builder.Property(m => m.SocketTypeId)
               .IsRequired();

            builder.Property(m => m.MaxMemmoryFreq)
               .IsRequired();

            builder.Property(m => m.MemoryType)
               .IsRequired();

            builder.Property(m => m.NoOfM2Slots)
               .IsRequired();

            builder.Property(m => m.NoOfPCIeSlots)
               .IsRequired();

            builder.Property(m => m.NoOfRAMSlots)
               .IsRequired();

            builder.Property(m => m.HasRGB)
               .IsRequired();

            builder.Property(m => m.ManufacturerId)
               .IsRequired();

            builder.HasIndex(m => new { m.Name, m.Released });

            builder.HasKey(m => m.Id);
        }
    }
}
