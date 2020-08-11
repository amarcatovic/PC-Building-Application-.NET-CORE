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

            builder.Property(cpu => new { cpu.Name, cpu.Released, cpu.SocketTypeId, cpu.Clockspeed, 
                cpu.NoOfCores, cpu.SingleThreadRating, cpu.ManufacturerId})
                .IsRequired();

            builder.HasIndex(cpu => cpu.Name);
        }
    }
}
