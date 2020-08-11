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
            builder.HasKey(m => m.Id);

            builder.Property(m => new { m.Name, m.Released, m.SocketTypeId, m.MaxMemmoryFreq, 
                m.MemoryType, m.NoOfM2Slots, m.NoOfPCIeSlots, m.NoOfRAMSlots, m.HasRGB, m.ManufacturerId })
                .IsRequired();

            builder.HasKey(m => new { m.Name, m.Released });
        }
    }
}
