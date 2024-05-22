﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StartDatabaseSeed.Data;

#nullable disable

namespace StartDatabaseSeed.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("GenreItemCatalog", b =>
                {
                    b.Property<string>("GenresId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ItemsTmdbId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("GenresId", "ItemsTmdbId");

                    b.HasIndex("ItemsTmdbId");

                    b.ToTable("GenreItemCatalog");
                });

            modelBuilder.Entity("StartDatabaseSeed.Models.Addon", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("HomePage")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("StreamingId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("StreamingId");

                    b.ToTable("addons");
                });

            modelBuilder.Entity("StartDatabaseSeed.Models.Genre", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("StartDatabaseSeed.Models.ItemCatalog", b =>
                {
                    b.Property<string>("TmdbId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("OriginalTitle")
                        .HasColumnType("longtext");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("TmdbId");

                    b.ToTable("ItemsCatalog");
                });

            modelBuilder.Entity("StartDatabaseSeed.Models.ItemCatalog_Streaming", b =>
                {
                    b.Property<string>("ItemCatologId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("StreamingId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ItemCatalogTmdbId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double?>("Price")
                        .HasColumnType("double");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<bool>("expiresSoon")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("ItemCatologId", "StreamingId");

                    b.HasIndex("ItemCatalogTmdbId");

                    b.HasIndex("StreamingId");

                    b.ToTable("ItemsCatalog_Streamings");
                });

            modelBuilder.Entity("StartDatabaseSeed.Models.Streaming", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("HomePage")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Streamings");
                });

            modelBuilder.Entity("GenreItemCatalog", b =>
                {
                    b.HasOne("StartDatabaseSeed.Models.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StartDatabaseSeed.Models.ItemCatalog", null)
                        .WithMany()
                        .HasForeignKey("ItemsTmdbId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StartDatabaseSeed.Models.Addon", b =>
                {
                    b.HasOne("StartDatabaseSeed.Models.Streaming", null)
                        .WithMany("addons")
                        .HasForeignKey("StreamingId");
                });

            modelBuilder.Entity("StartDatabaseSeed.Models.ItemCatalog_Streaming", b =>
                {
                    b.HasOne("StartDatabaseSeed.Models.ItemCatalog", null)
                        .WithMany("Streamings")
                        .HasForeignKey("ItemCatalogTmdbId");

                    b.HasOne("StartDatabaseSeed.Models.Streaming", null)
                        .WithMany("Items")
                        .HasForeignKey("StreamingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StartDatabaseSeed.Models.ItemCatalog", b =>
                {
                    b.Navigation("Streamings");
                });

            modelBuilder.Entity("StartDatabaseSeed.Models.Streaming", b =>
                {
                    b.Navigation("Items");

                    b.Navigation("addons");
                });
#pragma warning restore 612, 618
        }
    }
}
