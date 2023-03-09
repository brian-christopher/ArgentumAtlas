﻿// <auto-generated />
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ArgentumAtlas.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230308153616_Wda")]
    partial class Wda
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.3");

            modelBuilder.Entity("DomainModels.Platform", b =>
                {
                    b.Property<int>("PlatformId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("PlatformId");

                    b.ToTable("Platforms");

                    b.HasData(
                        new
                        {
                            PlatformId = 1,
                            Name = "Windows"
                        },
                        new
                        {
                            PlatformId = 2,
                            Name = "Linux"
                        },
                        new
                        {
                            PlatformId = 3,
                            Name = "Mac"
                        },
                        new
                        {
                            PlatformId = 4,
                            Name = "Android"
                        });
                });

            modelBuilder.Entity("DomainModels.Server", b =>
                {
                    b.Property<int>("ServerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BannerURL")
                        .HasColumnType("TEXT");

                    b.Property<string>("Content")
                        .HasColumnType("TEXT");

                    b.Property<string>("Discord")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Website")
                        .HasColumnType("TEXT");

                    b.HasKey("ServerId");

                    b.ToTable("ServerInfos");
                });

            modelBuilder.Entity("DomainModels.ServerPlatform", b =>
                {
                    b.Property<int>("ServerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PlatformId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ServerId", "PlatformId");

                    b.HasIndex("PlatformId");

                    b.ToTable("ServerPlatforms");
                });

            modelBuilder.Entity("DomainModels.ServerPlatform", b =>
                {
                    b.HasOne("DomainModels.Platform", "Platform")
                        .WithMany("ServerPlatforms")
                        .HasForeignKey("PlatformId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DomainModels.Server", "Server")
                        .WithMany("ServerPlatforms")
                        .HasForeignKey("ServerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Platform");

                    b.Navigation("Server");
                });

            modelBuilder.Entity("DomainModels.Platform", b =>
                {
                    b.Navigation("ServerPlatforms");
                });

            modelBuilder.Entity("DomainModels.Server", b =>
                {
                    b.Navigation("ServerPlatforms");
                });
#pragma warning restore 612, 618
        }
    }
}