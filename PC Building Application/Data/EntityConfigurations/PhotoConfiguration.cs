using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PC_Building_Application.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data.EntityConfigurations
{
    public class PhotoConfiguration : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Url)
                .IsRequired();

            builder.Property(p => p.PublicId)
                .IsRequired();

            builder.Property(p => p.DateAdded)
                .IsRequired();

            builder.Property(p => p.Description)
                .HasDefaultValue("This Photo Does Not Have A Description Yet!");

            builder.HasMany(p => p.Users)
                .WithOne(u => u.Photo)
                .HasForeignKey(u => u.PhotoId);

            builder.HasMany(p => p.Motherboards)
                .WithOne(m => m.Photo)
                .HasForeignKey(m => m.PhotoId);
        }
    }
}
