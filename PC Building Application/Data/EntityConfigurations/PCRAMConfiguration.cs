using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PC_Building_Application.Data.Models.Join_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data
{
    public class PCRAMConfiguration : IEntityTypeConfiguration<PCRAM>
    {
        public void Configure(EntityTypeBuilder<PCRAM> builder)
        {
            builder.HasKey(pcram => new { pcram.PCId, pcram.RAMId, pcram.Inserted });

            builder.HasOne(pcram => pcram.RAM)
                .WithMany(ram => ram.PCRAMs)
                .HasForeignKey(pcram => pcram.RAMId);

            builder.HasOne(pcram => pcram.PC)
                .WithMany(pc => pc.PCRAMs)
                .HasForeignKey(pcram => pcram.PCId);
                
        }
    }
}
