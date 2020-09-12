using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PC_Building_Application.Data.Models.Join_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.EntityConfigurations
{
    public class PCGPUConfiguration : IEntityTypeConfiguration<PCGPU>
    {
        public void Configure(EntityTypeBuilder<PCGPU> builder)
        {
            builder.HasKey(ps => new { ps.GPUId, ps.PCID, ps.Inserted });

            builder.HasOne(ps => ps.PC)
                .WithMany(pc => pc.PCGPUs)
                .HasForeignKey(ps => ps.PCID);

            builder.HasOne(ps => ps.GPU)
                .WithMany(s => s.PCGPUs)
                .HasForeignKey(ps => ps.GPUId);
        }
    }
}
