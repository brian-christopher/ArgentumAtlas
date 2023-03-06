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
    [Migration("20230306020944_ChangeField")]
    partial class ChangeField
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

                    b.Property<string>("IconURL")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("PlatformId");

                    b.ToTable("Platforms");

                    b.HasData(
                        new
                        {
                            PlatformId = 1,
                            IconURL = "/images/os/windows.png",
                            Name = "Windows"
                        },
                        new
                        {
                            PlatformId = 2,
                            IconURL = "/images/os/linux.png",
                            Name = "Linux"
                        },
                        new
                        {
                            PlatformId = 3,
                            IconURL = "/images/os/mac.png",
                            Name = "Mac"
                        },
                        new
                        {
                            PlatformId = 4,
                            IconURL = "/images/os/android.png",
                            Name = "Android"
                        });
                });

            modelBuilder.Entity("DomainModels.ServerInfo", b =>
                {
                    b.Property<int>("ServerInfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BannerURL")
                        .HasColumnType("TEXT");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(3000)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.HasKey("ServerInfoId");

                    b.ToTable("ServerInfos");
                });
#pragma warning restore 612, 618
        }
    }
}
