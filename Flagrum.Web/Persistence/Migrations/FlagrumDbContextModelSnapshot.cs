﻿// <auto-generated />
using System;
using Flagrum.Web.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Flagrum.Web.Persistence.Migrations
{
    [DbContext(typeof(FlagrumDbContext))]
    partial class FlagrumDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.1");

            modelBuilder.Entity("Flagrum.Web.Persistence.Entities.ArchiveLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Path")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ArchiveLocations");
                });

            modelBuilder.Entity("Flagrum.Web.Persistence.Entities.AssetExplorerNode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ParentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("AssetExplorerNodes");
                });

            modelBuilder.Entity("Flagrum.Web.Persistence.Entities.AssetUri", b =>
                {
                    b.Property<string>("Uri")
                        .HasColumnType("TEXT");

                    b.Property<int>("ArchiveLocationId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Uri");

                    b.HasIndex("ArchiveLocationId");

                    b.ToTable("AssetUris");
                });

            modelBuilder.Entity("Flagrum.Web.Persistence.Entities.ModelReplacementFavourite", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id", "IsDefault");

                    b.ToTable("ModelReplacementFavourites");
                });

            modelBuilder.Entity("Flagrum.Web.Persistence.Entities.ModelReplacementPath", b =>
                {
                    b.Property<int>("ModelReplacementPresetId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Path")
                        .HasColumnType("TEXT");

                    b.HasKey("ModelReplacementPresetId", "Path");

                    b.ToTable("ModelReplacementPaths");
                });

            modelBuilder.Entity("Flagrum.Web.Persistence.Entities.ModelReplacementPreset", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ModelReplacementPresets");
                });

            modelBuilder.Entity("Flagrum.Web.Persistence.Entities.StatePair", b =>
                {
                    b.Property<int>("Key")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("Key");

                    b.ToTable("StatePairs");
                });

            modelBuilder.Entity("Flagrum.Web.Persistence.Entities.AssetExplorerNode", b =>
                {
                    b.HasOne("Flagrum.Web.Persistence.Entities.AssetExplorerNode", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("Flagrum.Web.Persistence.Entities.AssetUri", b =>
                {
                    b.HasOne("Flagrum.Web.Persistence.Entities.ArchiveLocation", "ArchiveLocation")
                        .WithMany("AssetUris")
                        .HasForeignKey("ArchiveLocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ArchiveLocation");
                });

            modelBuilder.Entity("Flagrum.Web.Persistence.Entities.ModelReplacementPath", b =>
                {
                    b.HasOne("Flagrum.Web.Persistence.Entities.ModelReplacementPreset", null)
                        .WithMany("ReplacementPaths")
                        .HasForeignKey("ModelReplacementPresetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Flagrum.Web.Persistence.Entities.ArchiveLocation", b =>
                {
                    b.Navigation("AssetUris");
                });

            modelBuilder.Entity("Flagrum.Web.Persistence.Entities.AssetExplorerNode", b =>
                {
                    b.Navigation("Children");
                });

            modelBuilder.Entity("Flagrum.Web.Persistence.Entities.ModelReplacementPreset", b =>
                {
                    b.Navigation("ReplacementPaths");
                });
#pragma warning restore 612, 618
        }
    }
}
