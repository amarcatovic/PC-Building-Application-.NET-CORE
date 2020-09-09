﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PC_Building_Application.Data;

namespace PC_Building_Application.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200909115823_AddPriceToCPUž")]
    partial class AddPriceToCPU
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<DateTime>("DateBuilt")
                        .HasColumnType("datetime2");

                    b.Property<int>("MotherboardId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CPUId");

                    b.HasIndex("MotherboardId");

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

            modelBuilder.Entity("PC_Building_Application.Data.Models.CPU", b =>
                {
                    b.HasOne("PC_Building_Application.Data.Models.Manufacturer", "Manufacturer")
                        .WithMany("CPUs")
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PC_Building_Application.Data.Models.Photo", "Photo")
                        .WithMany()
                        .HasForeignKey("PhotoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PC_Building_Application.Data.Models.SocketType", "SocketType")
                        .WithMany("CPUs")
                        .HasForeignKey("SocketTypeId")
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

                    b.HasOne("PC_Building_Application.Data.Models.Motherboard", "Motherboard")
                        .WithMany("PCs")
                        .HasForeignKey("MotherboardId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PC_Building_Application.Data.Models.User", "User")
                        .WithMany("PCs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PC_Building_Application.Data.Models.User", b =>
                {
                    b.HasOne("PC_Building_Application.Data.Models.Photo", "Photo")
                        .WithMany("Users")
                        .HasForeignKey("PhotoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
