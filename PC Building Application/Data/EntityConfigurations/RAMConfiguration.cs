using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PC_Building_Application.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.EntityConfigurations
{
    public class RAMConfiguration : IEntityTypeConfiguration<RAM>
    {
        public void Configure(EntityTypeBuilder<RAM> builder)
        {
            builder.HasKey(ram => ram.Id);

            builder.Property(ram => ram.Price)
                .IsRequired();

            builder.Property(ram => ram.Name)
                .IsRequired();

            builder.Property(ram => ram.NoOfSticks)
                .IsRequired();

            builder.Property(ram => ram.Speed)
                .IsRequired();

            builder.Property(ram => ram.CapacityPerStick)
                .IsRequired();

            builder.Property(ram => ram.HasRGB)
                .IsRequired();

            builder.Property(ram => ram.Type)
                .IsRequired();
        }
    }
}
