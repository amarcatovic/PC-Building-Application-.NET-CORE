using Microsoft.EntityFrameworkCore;
using PC_Building_Application.Data.EntityConfigurations;
using PC_Building_Application.Data.Models;
using PC_Building_Application.Data.Models.Join_Classes;
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
            modelBuilder.ApplyConfiguration(new PhotoConfiguration());
            modelBuilder.ApplyConfiguration(new RAMConfiguration());
            modelBuilder.ApplyConfiguration(new PCRAMConfiguration());
            modelBuilder.ApplyConfiguration(new GPUConfiguration());
            modelBuilder.ApplyConfiguration(new CoolerConfiguration());
            modelBuilder.ApplyConfiguration(new CoolerSocketTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PowerSupplyConfiguration());
            modelBuilder.ApplyConfiguration(new CaseConfiguration());
            modelBuilder.ApplyConfiguration(new StorageTypeConfiguration());
            modelBuilder.ApplyConfiguration(new StorageConfiguration());
            modelBuilder.ApplyConfiguration(new PCStorageConfiguration());
            modelBuilder.ApplyConfiguration(new PCGPUConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<SocketType> SocketTypes { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Motherboard> Motherboards { get; set; }
        public DbSet<CPU> CPUs { get; set; }
        public DbSet<PC> PCs { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<RAM> RAMs { get; set; }
        public DbSet<PCRAM> PCRAM { get; set; }
        public DbSet<GPU> GPUs { get; set; }
        public DbSet<Cooler> Coolers { get; set; }
        public DbSet<CoolerSocketType> CoolerSocketType { get; set; }
        public DbSet<PowerSupply> PowerSupplies { get; set; }
        public DbSet<Case> Cases { get; set; }
        public DbSet<StorageType> StorageTypes { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<PCStorage> PCStorage { get; set; }
        public DbSet<PCGPU> PCGPU { get; set; }
    }
}
