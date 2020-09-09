using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.EntityConfigurations
{
    public class StorageTypeConfiguration : IEntityTypeConfiguration<StorageType>
    {
        public void Configure(EntityTypeBuilder<StorageType> builder)
        {
            builder.HasMany(st => st.Storages)
                .WithOne(s => s.StorageType)
                .HasForeignKey(s => s.StorageTypeId);
        }
    }
}
