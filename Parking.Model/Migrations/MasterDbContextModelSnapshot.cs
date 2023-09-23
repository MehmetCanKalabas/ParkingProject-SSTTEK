﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Parking.Model.Context;

#nullable disable

namespace Parking.Model.Migrations
{
    [DbContext(typeof(MasterDbContext))]
    partial class MasterDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Parking.Model.Entities.CarPark", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsOpen")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("CarParks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsOpen = true
                        });
                });

            modelBuilder.Entity("Parking.Model.Entities.TyreChangedVehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VehicleId");

                    b.ToTable("TyreChangedVehicle");
                });

            modelBuilder.Entity("Parking.Model.Entities.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CarParkId")
                        .HasColumnType("int");

                    b.Property<string>("CarParkType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CheckOutTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Color")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EntryTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("HasParked")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("ModelYear")
                        .HasMaxLength(4)
                        .HasColumnType("int");

                    b.Property<double>("MotorPowerInKW")
                        .HasColumnType("float");

                    b.Property<string>("Plate")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<double>("ServiceFee")
                        .HasColumnType("float");

                    b.Property<double>("StayTime")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CarParkId");

                    b.ToTable("Vehicles");

                    b.HasDiscriminator<string>("CarParkType").HasValue("Vehicle");
                });

            modelBuilder.Entity("Parking.Model.Entities.WashedVehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VehicleId");

                    b.ToTable("WashedVehicle");
                });

            modelBuilder.Entity("Parking.Model.Entities.FirstClassVehicle", b =>
                {
                    b.HasBaseType("Parking.Model.Entities.Vehicle");

                    b.Property<bool>("Autopilot")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("WashedVehicleId")
                        .HasColumnType("int");

                    b.HasIndex("WashedVehicleId");

                    b.HasDiscriminator().HasValue("FirstClass");
                });

            modelBuilder.Entity("Parking.Model.Entities.SecondClassVehicle", b =>
                {
                    b.HasBaseType("Parking.Model.Entities.Vehicle");

                    b.Property<double>("LuggageVolume")
                        .HasColumnType("float");

                    b.Property<int?>("TyreChangedVehicleId")
                        .HasColumnType("int");

                    b.HasIndex("TyreChangedVehicleId");

                    b.HasDiscriminator().HasValue("SecondClass");
                });

            modelBuilder.Entity("Parking.Model.Entities.ThirdClassVehicle", b =>
                {
                    b.HasBaseType("Parking.Model.Entities.Vehicle");

                    b.HasDiscriminator().HasValue("ThirdClass");
                });

            modelBuilder.Entity("Parking.Model.Entities.TyreChangedVehicle", b =>
                {
                    b.HasOne("Parking.Model.Entities.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("Parking.Model.Entities.Vehicle", b =>
                {
                    b.HasOne("Parking.Model.Entities.CarPark", "CarPark")
                        .WithMany("ParkedVehicles")
                        .HasForeignKey("CarParkId");

                    b.Navigation("CarPark");
                });

            modelBuilder.Entity("Parking.Model.Entities.WashedVehicle", b =>
                {
                    b.HasOne("Parking.Model.Entities.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("Parking.Model.Entities.FirstClassVehicle", b =>
                {
                    b.HasOne("Parking.Model.Entities.WashedVehicle", "WashedVehicle")
                        .WithMany()
                        .HasForeignKey("WashedVehicleId");

                    b.Navigation("WashedVehicle");
                });

            modelBuilder.Entity("Parking.Model.Entities.SecondClassVehicle", b =>
                {
                    b.HasOne("Parking.Model.Entities.TyreChangedVehicle", "TyreChangedVehicle")
                        .WithMany()
                        .HasForeignKey("TyreChangedVehicleId");

                    b.Navigation("TyreChangedVehicle");
                });

            modelBuilder.Entity("Parking.Model.Entities.CarPark", b =>
                {
                    b.Navigation("ParkedVehicles");
                });
#pragma warning restore 612, 618
        }
    }
}