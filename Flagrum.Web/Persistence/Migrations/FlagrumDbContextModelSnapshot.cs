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

            modelBuilder.Entity("Flagrum.Web.Persistence.Entities.EarcMod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(37)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("EarcMods");
                });

            modelBuilder.Entity("Flagrum.Web.Persistence.Entities.EarcModBackup", b =>
                {
                    b.Property<string>("Uri")
                        .HasColumnType("TEXT");

                    b.Property<int>("Flags")
                        .HasColumnType("INTEGER");

                    b.Property<ushort>("Key")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("Locale")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("LocalizationType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("RelativePath")
                        .HasColumnType("TEXT");

                    b.Property<uint>("Size")
                        .HasColumnType("INTEGER");

                    b.HasKey("Uri");

                    b.ToTable("EarcModBackups");
                });

            modelBuilder.Entity("Flagrum.Web.Persistence.Entities.EarcModEarc", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("EarcModId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("EarcRelativePath")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EarcModId");

                    b.ToTable("EarcModEarcs");
                });

            modelBuilder.Entity("Flagrum.Web.Persistence.Entities.EarcModReplacement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("EarcModEarcId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ReplacementFilePath")
                        .HasColumnType("TEXT");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Uri")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EarcModEarcId");

                    b.ToTable("EarcModReplacements");
                });

            modelBuilder.Entity("Flagrum.Web.Persistence.Entities.FestivalAllDependency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Uri")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("FestivalAllDependencies");
                });

            modelBuilder.Entity("Flagrum.Web.Persistence.Entities.FestivalDependency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ParentId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Uri")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("FestivalDependencies");
                });

            modelBuilder.Entity("Flagrum.Web.Persistence.Entities.FestivalFinalDependency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Uri")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("FestivalFinalDependencies");
                });

            modelBuilder.Entity("Flagrum.Web.Persistence.Entities.FestivalMaterialDependency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ParentId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Uri")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("FestivalMaterialDependencies");
                });

            modelBuilder.Entity("Flagrum.Web.Persistence.Entities.FestivalModelDependency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ParentId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Uri")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("FestivalModelDependencies");
                });

            modelBuilder.Entity("Flagrum.Web.Persistence.Entities.FestivalSubdependency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ParentId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Uri")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("FestivalSubdependencies");
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

            modelBuilder.Entity("Flagrum.Web.Persistence.Entities.Ps4ArchiveAsset", b =>
                {
                    b.Property<int>("Ps4ArchiveLocationId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Ps4AssetUriId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Ps4ArchiveLocationId", "Ps4AssetUriId");

                    b.HasIndex("Ps4AssetUriId");

                    b.ToTable("Ps4ArchiveAssets");
                });

            modelBuilder.Entity("Flagrum.Web.Persistence.Entities.Ps4ArchiveLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Path")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Ps4ArchiveLocations");
                });

            modelBuilder.Entity("Flagrum.Web.Persistence.Entities.Ps4AssetUri", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Uri")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Ps4AssetUris");
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

            modelBuilder.Entity("Flagrum.Web.Persistence.Entities.EarcModEarc", b =>
                {
                    b.HasOne("Flagrum.Web.Persistence.Entities.EarcMod", "EarcMod")
                        .WithMany("Earcs")
                        .HasForeignKey("EarcModId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EarcMod");
                });

            modelBuilder.Entity("Flagrum.Web.Persistence.Entities.EarcModReplacement", b =>
                {
                    b.HasOne("Flagrum.Web.Persistence.Entities.EarcModEarc", "EarcModEarc")
                        .WithMany("Replacements")
                        .HasForeignKey("EarcModEarcId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EarcModEarc");
                });

            modelBuilder.Entity("Flagrum.Web.Persistence.Entities.FestivalDependency", b =>
                {
                    b.HasOne("Flagrum.Web.Persistence.Entities.FestivalDependency", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("Flagrum.Web.Persistence.Entities.FestivalMaterialDependency", b =>
                {
                    b.HasOne("Flagrum.Web.Persistence.Entities.FestivalModelDependency", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("Flagrum.Web.Persistence.Entities.FestivalModelDependency", b =>
                {
                    b.HasOne("Flagrum.Web.Persistence.Entities.FestivalSubdependency", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("Flagrum.Web.Persistence.Entities.FestivalSubdependency", b =>
                {
                    b.HasOne("Flagrum.Web.Persistence.Entities.FestivalDependency", "Parent")
                        .WithMany("Subdependencies")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("Flagrum.Web.Persistence.Entities.ModelReplacementPath", b =>
                {
                    b.HasOne("Flagrum.Web.Persistence.Entities.ModelReplacementPreset", null)
                        .WithMany("ReplacementPaths")
                        .HasForeignKey("ModelReplacementPresetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Flagrum.Web.Persistence.Entities.Ps4ArchiveAsset", b =>
                {
                    b.HasOne("Flagrum.Web.Persistence.Entities.Ps4ArchiveLocation", "Ps4ArchiveLocation")
                        .WithMany("ArchiveAssets")
                        .HasForeignKey("Ps4ArchiveLocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Flagrum.Web.Persistence.Entities.Ps4AssetUri", "Ps4AssetUri")
                        .WithMany("ArchiveAssets")
                        .HasForeignKey("Ps4AssetUriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ps4ArchiveLocation");

                    b.Navigation("Ps4AssetUri");
                });

            modelBuilder.Entity("Flagrum.Web.Persistence.Entities.ArchiveLocation", b =>
                {
                    b.Navigation("AssetUris");
                });

            modelBuilder.Entity("Flagrum.Web.Persistence.Entities.AssetExplorerNode", b =>
                {
                    b.Navigation("Children");
                });

            modelBuilder.Entity("Flagrum.Web.Persistence.Entities.EarcMod", b =>
                {
                    b.Navigation("Earcs");
                });

            modelBuilder.Entity("Flagrum.Web.Persistence.Entities.EarcModEarc", b =>
                {
                    b.Navigation("Replacements");
                });

            modelBuilder.Entity("Flagrum.Web.Persistence.Entities.FestivalDependency", b =>
                {
                    b.Navigation("Children");

                    b.Navigation("Subdependencies");
                });

            modelBuilder.Entity("Flagrum.Web.Persistence.Entities.FestivalModelDependency", b =>
                {
                    b.Navigation("Children");
                });

            modelBuilder.Entity("Flagrum.Web.Persistence.Entities.FestivalSubdependency", b =>
                {
                    b.Navigation("Children");
                });

            modelBuilder.Entity("Flagrum.Web.Persistence.Entities.ModelReplacementPreset", b =>
                {
                    b.Navigation("ReplacementPaths");
                });

            modelBuilder.Entity("Flagrum.Web.Persistence.Entities.Ps4ArchiveLocation", b =>
                {
                    b.Navigation("ArchiveAssets");
                });

            modelBuilder.Entity("Flagrum.Web.Persistence.Entities.Ps4AssetUri", b =>
                {
                    b.Navigation("ArchiveAssets");
                });
#pragma warning restore 612, 618
        }
    }
}
