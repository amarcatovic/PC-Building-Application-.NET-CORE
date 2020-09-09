﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PC_Building_Application.Data;

namespace PC_Building_Application.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0-preview.7.20365.15");

            modelBuilder.Entity("PC_Building_Application.Data.Models.CPU", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Clockspeed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ManufacturerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("NoOfCores")
                        .HasColumnType("int");

                    b.Property<int>("PhotoId")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<DateTime>("Released")
                        .HasColumnType("datetime2");

                    b.Property<int>("SingleThreadRating")
                        .HasColumnType("int");

                    b.Property<int>("SocketTypeId")
                        .HasColumnType("int");

                    b.Property<string>("TurboSpeed")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ManufacturerId");

                    b.HasIndex("Name");

                    b.HasIndex("PhotoId");

                    b.HasIndex("SocketTypeId");

                    b.ToTable("CPUs");
                });

            modelBuilder.Entity("PC_Building_Application.Data.Models.Case", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("HasRGB")
                        .HasColumnType("bit");

                    b.Property<bool>("HasScreen")
                        .HasColumnType("bit");

                    b.Property<int>("ManufacturerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("NoOfUSB3Ports")
                        .HasColumnType("tinyint");

                    b.Property<int>("PhotoId")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<DateTime>("Released")
                        .HasColumnType("datetime2");

                    b.Property<string>("Size")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ManufacturerId");

                    b.HasIndex("PhotoId");

                    b.ToTable("Cases");
                });

            modelBuilder.Entity("PC_Building_Application.Data.Models.Cooler", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("HasRGB")
                        .HasColumnType("bit");

                    b.Property<bool>("IsWaterCooler")
                        .HasColumnType("bit");

                    b.Property<int>("ManufacturerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhotoId")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<DateTime>("Released")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ManufacturerId");

                    b.HasIndex("PhotoId");

                    b.ToTable("Coolers");
                });

            modelBuilder.Entity("PC_Building_Application.Data.Models.GPU", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("HasDVI")
                        .HasColumnType("bit");

                    b.Property<bool>("HasVGA")
                        .HasColumnType("bit");

                    b.Property<int>("ManufacturerId")
                        .HasColumnType("int");

                    b.Property<string>("MemoryType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NoOfDisplayPorts")
                        .HasColumnType("int");

                    b.Property<int>("NoOfHDMIPorts")
                        .HasColumnType("int");

                    b.Property<string>("PCIPort")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhotoId")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<DateTime>("Released")
                        .HasColumnType("datetime2");

                    b.Property<string>("VRAM")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ManufacturerId");

                    b.HasIndex("PhotoId");

                    b.ToTable("GPUs");
                });

            modelBuilder.Entity("PC_Building_Application.Data.Models.Join_Classes.CoolerSocketType", b =>
                {
                    b.Property<int>("CoolerId")
                        .HasColumnType("int");

                    b.Property<int>("SocketTypeId")
                        .HasColumnType("int");

                    b.HasKey("CoolerId", "SocketTypeId");

                    b.HasIndex("SocketTypeId");

                    b.ToTable("CoolerSocketType");
                });

            modelBuilder.Entity("PC_Building_Application.Data.Models.Join_Classes.PCRAM", b =>
                {
                    b.Property<int>("PCId")
                        .HasColumnType("int");

                    b.Property<int>("RAMId")
                        .HasColumnType("int");

                    b.HasKey("PCId", "RAMId");

                    b.HasIndex("RAMId");

                    b.ToTable("PCRAM");
                });

            modelBuilder.Entity("PC_Building_Application.Data.Models.Manufacturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("Manufacturers");
                });

            modelBuilder.Entity("PC_Building_Application.Data.Models.Motherboard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("HasRGB")
                        .HasColumnType("bit");

                    b.Property<int>("ManufacturerId")
                        .HasColumnType("int");

                    b.Property<int>("MaxMemmoryFreq")
                        .HasColumnType("int");

                    b.Property<string>("MemoryType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("NoOfM2Slots")
                        .HasColumnType("int");

                    b.Property<int>("NoOfPCIeSlots")
                        .HasColumnType("int");

                    b.Property<int>("NoOfRAMSlots")
                        .HasColumnType("int");

                    b.Property<int>("PhotoId")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<DateTime>("Released")
                        .HasColumnType("datetime2");

                    b.Property<int>("SocketTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ManufacturerId");

                    b.HasIndex("PhotoId");

                    b.HasIndex("SocketTypeId");

                    b.HasIndex("Name", "Released");

                    b.ToTable("Motherboards");
                });

            modelBuilder.Entity("PC_Building_Application.Data.Models.PC", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("BuildDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BuildTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CPUId")
                        .HasColumnType("int");

                    b.Property<int>("CaseId")
                        .HasColumnType("int");

                    b.Property<int>("CoolerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateBuilt")
                        .HasColumnType("datetime2");

                    b.Property<int>("GPUId")
                        .HasColumnType("int");

                    b.Property<int>("MotherboardId")
                        .HasColumnType("int");

                    b.Property<int>("PowerSupplyId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CPUId");

                    b.HasIndex("CaseId");

                    b.HasIndex("CoolerId");

                    b.HasIndex("GPUId");

                    b.HasIndex("MotherboardId");

                    b.HasIndex("PowerSupplyId");

                    b.HasIndex("UserId");

                    b.ToTable("PCs");
                });

            modelBuilder.Entity("PC_Building_Application.Data.Models.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("This Photo Does Not Have A Description Yet!");

                    b.Property<string>("PublicId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("PC_Building_Application.Data.Models.PowerSupply", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<byte>("EfficiencyRating")
                        .HasColumnType("tinyint");

                    b.Property<bool>("Has24PinCable")
                        .HasColumnType("bit");

                    b.Property<int>("ManufacturerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("NoOfCPUCables")
                        .HasColumnType("tinyint");

                    b.Property<byte>("NoOfPCIe6Pins")
                        .HasColumnType("tinyint");

                    b.Property<byte>("NoOfPCIe8Pins")
                        .HasColumnType("tinyint");

                    b.Property<byte>("NoOfSATACables")
                        .HasColumnType("tinyint");

                    b.Property<int>("PhotoId")
                        .HasColumnType("int");

                    b.Property<string>("Power")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<DateTime>("Released")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ManufacturerId");

                    b.HasIndex("PhotoId");

                    b.ToTable("PowerSupplies");
                });

            modelBuilder.Entity("PC_Building_Application.Data.Models.RAM", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CapacityPerStick")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HasRGB")
                        .HasColumnType("bit");

                    b.Property<int>("ManufacturerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("NoOfSticks")
                        .HasColumnType("smallint");

                    b.Property<int>("PhotoId")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<DateTime>("Released")
                        .HasColumnType("datetime2");

                    b.Property<int>("Speed")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ManufacturerId");

                    b.HasIndex("PhotoId");

                    b.ToTable("RAMs");
                });

            modelBuilder.Entity("PC_Building_Application.Data.Models.SocketType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("SocketTypes");
                });

            modelBuilder.Entity("PC_Building_Application.Data.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("EmailConfirmed")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("PhotoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("PhotoId");

                    b.HasIndex("UserName", "Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PC_Building_Application.Data.PCStorage", b =>
                {
                    b.Property<int>("StorageId")
                        .HasColumnType("int");

                    b.Property<int>("PCId")
                        .HasColumnType("int");

                    b.HasKey("StorageId", "PCId");

                    b.HasIndex("PCId");

                    b.ToTable("PCStorage");
                });

            modelBuilder.Entity("PC_Building_Application.Data.Storage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Capacity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HasCooling")
                        .HasColumnType("bit");

                    b.Property<int>("ManufacturerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhotoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Released")
                        .HasColumnType("datetime2");

                    b.Property<int>("StorageTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ManufacturerId");

                    b.HasIndex("PhotoId");

                    b.HasIndex("StorageTypeId");

                    b.ToTable("Storages");
                });

            modelBuilder.Entity("PC_Building_Application.Data.StorageType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("StorageTypes");
                });

            modelBuilder.Entity("PC_Building_Application.Data.Models.CPU", b =>
                {
                    b.HasOne("PC_Building_Application.Data.Models.Manufacturer", "Manufacturer")
                        .WithMany("CPUs")
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PC_Building_Application.Data.Models.Photo", "Photo")
                        .WithMany("CPUs")
                        .HasForeignKey("PhotoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PC_Building_Application.Data.Models.SocketType", "SocketType")
                        .WithMany("CPUs")
                        .HasForeignKey("SocketTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PC_Building_Application.Data.Models.Case", b =>
                {
                    b.HasOne("PC_Building_Application.Data.Models.Manufacturer", "Manufacturer")
                        .WithMany("Cases")
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PC_Building_Application.Data.Models.Photo", "Photo")
                        .WithMany("Cases")
                        .HasForeignKey("PhotoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PC_Building_Application.Data.Models.Cooler", b =>
                {
                    b.HasOne("PC_Building_Application.Data.Models.Manufacturer", "Manufacturer")
                        .WithMany("Coolers")
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PC_Building_Application.Data.Models.Photo", "Photo")
                        .WithMany("Coolers")
                        .HasForeignKey("PhotoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PC_Building_Application.Data.Models.GPU", b =>
                {
                    b.HasOne("PC_Building_Application.Data.Models.Manufacturer", "Manufacturer")
                        .WithMany("GPUs")
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PC_Building_Application.Data.Models.Photo", "Photo")
                        .WithMany("GPUs")
                        .HasForeignKey("PhotoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PC_Building_Application.Data.Models.Join_Classes.CoolerSocketType", b =>
                {
                    b.HasOne("PC_Building_Application.Data.Models.Cooler", "Cooler")
                        .WithMany("CoolerSocketTypes")
                        .HasForeignKey("CoolerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PC_Building_Application.Data.Models.SocketType", "SocketType")
                        .WithMany("CoolerSocketTypes")
                        .HasForeignKey("SocketTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PC_Building_Application.Data.Models.Join_Classes.PCRAM", b =>
                {
                    b.HasOne("PC_Building_Application.Data.Models.PC", "PC")
                        .WithMany("PCRAMs")
                        .HasForeignKey("PCId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PC_Building_Application.Data.Models.RAM", "RAM")
                        .WithMany("PCRAMs")
                        .HasForeignKey("RAMId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PC_Building_Application.Data.Models.Motherboard", b =>
                {
                    b.HasOne("PC_Building_Application.Data.Models.Manufacturer", "Manufacturer")
                        .WithMany("Motherboards")
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PC_Building_Application.Data.Models.Photo", "Photo")
                        .WithMany("Motherboards")
                        .HasForeignKey("PhotoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PC_Building_Application.Data.Models.SocketType", "SocketType")
                        .WithMany("Motherboards")
                        .HasForeignKey("SocketTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PC_Building_Application.Data.Models.PC", b =>
                {
                    b.HasOne("PC_Building_Application.Data.Models.CPU", "CPU")
                        .WithMany("PCs")
                        .HasForeignKey("CPUId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PC_Building_Application.Data.Models.Case", "Case")
                        .WithMany("PCs")
                        .HasForeignKey("CaseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PC_Building_Application.Data.Models.Cooler", "Cooler")
                        .WithMany("PCs")
                        .HasForeignKey("CoolerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PC_Building_Application.Data.Models.GPU", "GPU")
                        .WithMany("PCs")
                        .HasForeignKey("GPUId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PC_Building_Application.Data.Models.Motherboard", "Motherboard")
                        .WithMany("PCs")
                        .HasForeignKey("MotherboardId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PC_Building_Application.Data.Models.PowerSupply", "PowerSupply")
                        .WithMany("PCs")
                        .HasForeignKey("PowerSupplyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PC_Building_Application.Data.Models.User", "User")
                        .WithMany("PCs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PC_Building_Application.Data.Models.PowerSupply", b =>
                {
                    b.HasOne("PC_Building_Application.Data.Models.Manufacturer", "Manufacturer")
                        .WithMany("PowerSupplies")
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PC_Building_Application.Data.Models.Photo", "Photo")
                        .WithMany("PowerSupplies")
                        .HasForeignKey("PhotoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PC_Building_Application.Data.Models.RAM", b =>
                {
                    b.HasOne("PC_Building_Application.Data.Models.Manufacturer", "Manufacturer")
                        .WithMany("RAMs")
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PC_Building_Application.Data.Models.Photo", "Photo")
                        .WithMany("RAMs")
                        .HasForeignKey("PhotoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PC_Building_Application.Data.Models.User", b =>
                {
                    b.HasOne("PC_Building_Application.Data.Models.Photo", "Photo")
                        .WithMany("Users")
                        .HasForeignKey("PhotoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PC_Building_Application.Data.PCStorage", b =>
                {
                    b.HasOne("PC_Building_Application.Data.Models.PC", "PC")
                        .WithMany("PCStorages")
                        .HasForeignKey("PCId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PC_Building_Application.Data.Storage", "Storage")
                        .WithMany("PCStorages")
                        .HasForeignKey("StorageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PC_Building_Application.Data.Storage", b =>
                {
                    b.HasOne("PC_Building_Application.Data.Models.Manufacturer", "Manufacturer")
                        .WithMany("Storages")
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PC_Building_Application.Data.Models.Photo", "Photo")
                        .WithMany("Storages")
                        .HasForeignKey("PhotoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PC_Building_Application.Data.StorageType", "StorageType")
                        .WithMany("Storages")
                        .HasForeignKey("StorageTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
