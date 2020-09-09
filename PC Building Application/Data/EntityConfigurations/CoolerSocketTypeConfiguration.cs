using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PC_Building_Application.Data.Models.Join_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.EntityConfigurations
{
    public class CoolerSocketTypeConfiguration : IEntityTypeConfiguration<CoolerSocketType>
    {
        public void Configure(EntityTypeBuilder<CoolerSocketType> builder)
        {
            builder.HasKey(cs => new { cs.CoolerId, cs.SocketTypeId });

            builder.HasOne(cs => cs.Cooler)
                .WithMany(c => c.CoolerSocketTypes)
                .HasForeignKey(cs => cs.CoolerId);

            builder.HasOne(cs => cs.SocketType)
                .WithMany(st => st.CoolerSocketTypes)
                .HasForeignKey(cs => cs.SocketTypeId);
        }
    }
}
