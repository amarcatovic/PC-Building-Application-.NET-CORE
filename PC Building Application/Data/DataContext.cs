﻿using Microsoft.EntityFrameworkCore;
using PC_Building_Application.Data.EntityConfigurations;
using PC_Building_Application.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Building_Application.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opt) : base(opt) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new SocketTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ManufacturerConfiguration());
            modelBuilder.ApplyConfiguration(new MotherboardConfiguration());
            modelBuilder.ApplyConfiguration(new CPUConfiguration());
            modelBuilder.ApplyConfiguration(new PCConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<SocketType> SocketTypes { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Motherboard> Motherboards { get; set; }
        public DbSet<CPU> CPUs { get; set; }
        public DbSet<PC> PCs { get; set; }
    }
}
