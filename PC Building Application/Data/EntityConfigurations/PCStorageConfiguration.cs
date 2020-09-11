using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.EntityConfigurations
{
    public class PCStorageConfiguration : IEntityTypeConfiguration<PCStorage>
    {
        public void Configure(EntityTypeBuilder<PCStorage> builder)
        {
            builder.HasKey(ps => new { ps.StorageId, ps.PCId, ps.Inserted });

            builder.HasOne(ps => ps.PC)
                .WithMany(pc => pc.PCStorages)
                .HasForeignKey(ps => ps.PCId);

            builder.HasOne(ps => ps.Storage)
                .WithMany(s => s.PCStorages)
                .HasForeignKey(ps => ps.StorageId);
        }
    }
}
