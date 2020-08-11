using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PC_Building_Application.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.EntityConfigurations
{
    public class SocketTypeConfiguration : IEntityTypeConfiguration<SocketType>
    {
        public void Configure(EntityTypeBuilder<SocketType> builder)
        {
            builder.HasKey(st => st.Id);

            builder.HasIndex(st => st.Name);

            builder.HasMany(st => st.Motherboards)
                .WithOne(m => m.SocketType)
                .HasForeignKey(m => m.SocketTypeId);

            builder.HasMany(st => st.CPUs)
                .WithOne(cpu => cpu.SocketType)
                .HasForeignKey(cpu => cpu.SocketTypeId);
        }
    }
}
