﻿// <auto-generated />
using System;
using InnowisePet.Services.Storage.DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InnowisePet.Services.Storage.API.Migrations
{
    [DbContext(typeof(StorageDbContext))]
    partial class StorageDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("InnowisePet.Models.Entities.ProductStorageModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid>("StorageId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("StorageId");

                    b.ToTable("ProductStorages");
                });

            modelBuilder.Entity("InnowisePet.Models.Entities.StorageModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Storages");
                });

            modelBuilder.Entity("InnowisePet.Models.Entities.ProductStorageModel", b =>
                {
                    b.HasOne("InnowisePet.Models.Entities.StorageModel", "Storage")
                        .WithMany("ProductStorages")
                        .HasForeignKey("StorageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Storage");
                });

            modelBuilder.Entity("InnowisePet.Models.Entities.StorageModel", b =>
                {
                    b.Navigation("ProductStorages");
                });
#pragma warning restore 612, 618
        }
    }
}