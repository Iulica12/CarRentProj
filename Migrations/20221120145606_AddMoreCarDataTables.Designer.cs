﻿// <auto-generated />
using System;
using CarRentProj.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarRentProj.Migrations
{
    [DbContext(typeof(CarRentProjContext))]
    [Migration("20221120145606_AddMoreCarDataTables")]
    partial class AddMoreCarDataTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CarRentProj.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CarModelId")
                        .HasColumnType("int");

                    b.Property<int?>("ColourId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MakeId")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarModelId");

                    b.HasIndex("ColourId");

                    b.HasIndex("MakeId");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("CarRentProj.Models.CarModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CarModel");
                });

            modelBuilder.Entity("CarRentProj.Models.Colour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Colour");
                });

            modelBuilder.Entity("CarRentProj.Models.Make", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("MakeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Make");
                });

            modelBuilder.Entity("CarRentProj.Models.Car", b =>
                {
                    b.HasOne("CarRentProj.Models.CarModel", "CarModel")
                        .WithMany("Car")
                        .HasForeignKey("CarModelId");

                    b.HasOne("CarRentProj.Models.Colour", "Colour")
                        .WithMany("Car")
                        .HasForeignKey("ColourId");

                    b.HasOne("CarRentProj.Models.Make", "Make")
                        .WithMany("Car")
                        .HasForeignKey("MakeId");

                    b.Navigation("CarModel");

                    b.Navigation("Colour");

                    b.Navigation("Make");
                });

            modelBuilder.Entity("CarRentProj.Models.CarModel", b =>
                {
                    b.Navigation("Car");
                });

            modelBuilder.Entity("CarRentProj.Models.Colour", b =>
                {
                    b.Navigation("Car");
                });

            modelBuilder.Entity("CarRentProj.Models.Make", b =>
                {
                    b.Navigation("Car");
                });
#pragma warning restore 612, 618
        }
    }
}
