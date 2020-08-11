using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PC_Building_Application.Data.Models;
using System;

namespace PC_Building_Application.Data.EntityConfigurations
{
    public class CPUConfiguration : IEntityTypeConfiguration<CPU>
    {
        public void Configure(EntityTypeBuilder<CPU> builder)
        {
            builder.HasKey(cpu => cpu.Id);

            builder.Property(cpu => cpu.Name)
                .IsRequired();

            builder.Property(cpu => cpu.Released)
               .IsRequired();

            builder.Property(cpu => cpu.SocketTypeId)
               .IsRequired();

            builder.Property(cpu => cpu.Clockspeed)
               .IsRequired();

            builder.Property(cpu => cpu.NoOfCores)
               .IsRequired();

            builder.Property(cpu => cpu.SingleThreadRating)
               .IsRequired();

            builder.Property(cpu => cpu.ManufacturerId)
               .IsRequired();

            builder.HasIndex(cpu => cpu.Name);
        }
    }
}
