﻿// <auto-generated />
using System;
using DInventory_MVCApplication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DInventory_MVCApplication.Migrations
{
    [DbContext(typeof(ApplicationDataContext))]
    partial class ApplicationDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-preview.2.22153.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DInventory_Models.BusChildren", b =>
                {
                    b.Property<int>("BusChildID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BusChildID"), 1L, 1);

                    b.Property<string>("BusChildName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("BusChildShortName")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<int>("BusParentID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(800)
                        .HasColumnType("nvarchar(800)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("BusChildID");

                    b.HasIndex("BusParentID");

                    b.ToTable("BusChildren", "Masters");
                });

            modelBuilder.Entity("DInventory_Models.BusParents", b =>
                {
                    b.Property<int>("BusParentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BusParentID"), 1L, 1);

                    b.Property<string>("BusParentName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("BusParentShortName")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(800)
                        .HasColumnType("nvarchar(800)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("BusParentID");

                    b.ToTable("BusParents", "Masters");
                });

            modelBuilder.Entity("DInventory_Models.BusChildren", b =>
                {
                    b.HasOne("DInventory_Models.BusParents", "BusParents")
                        .WithMany("ListOfBusChildren")
                        .HasForeignKey("BusParentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BusParents");
                });

            modelBuilder.Entity("DInventory_Models.BusParents", b =>
                {
                    b.Navigation("ListOfBusChildren");
                });
#pragma warning restore 612, 618
        }
    }
}