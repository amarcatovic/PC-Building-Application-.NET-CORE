using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.EntityConfigurations
{
    public class StorageConfiguration : IEntityTypeConfiguration<Storage>
    {
        public void Configure(EntityTypeBuilder<Storage> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                .IsRequired();

            builder.Property(s => s.Released)
                .IsRequired();

            builder.Property(s => s.Capacity)
                .IsRequired();

            builder.HasOne(s => s.Photo)
               .WithMany(p => p.Storages)
               .HasForeignKey(s => s.PhotoId);

            builder.HasOne(s => s.Manufacturer)
                .WithMany(m => m.Storages)
                .HasForeignKey(s => s.ManufacturerId);
        }
    }
}
