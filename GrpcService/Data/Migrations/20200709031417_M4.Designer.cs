﻿// <auto-generated />
using GrpcService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GrpcService.Data.Migrations
{
    [DbContext(typeof(WaterWorksDbContext))]
    [Migration("20200709031417_M4")]
    partial class M4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GrpcService.Models.Meter", b =>
                {
                    b.Property<int>("MeterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MeterNumber")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("MeterId");

                    b.HasIndex("MeterNumber")
                        .IsUnique()
                        .HasFilter("[MeterNumber] IS NOT NULL");

                    b.ToTable("Meters");

                    b.HasData(
                        new
                        {
                            MeterId = 1,
                            MeterNumber = "12345671"
                        },
                        new
                        {
                            MeterId = 2,
                            MeterNumber = "12345672"
                        },
                        new
                        {
                            MeterId = 3,
                            MeterNumber = "12345673"
                        },
                        new
                        {
                            MeterId = 4,
                            MeterNumber = "12345674"
                        },
                        new
                        {
                            MeterId = 5,
                            MeterNumber = "12345675"
                        });
                });

            modelBuilder.Entity("GrpcService.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("HashedPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Iterations")
                        .HasColumnType("int");

                    b.Property<string>("Salt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId");

                    b.HasIndex("UserName")
                        .IsUnique()
                        .HasFilter("[UserName] IS NOT NULL");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            HashedPassword = "Mya4WGifV2DdfbGXueYGMKBZlvLLfBAwa8j2avEzqhs=",
                            Iterations = 1,
                            Salt = "M91nsG2qR7vk4AS8TYA/vQFyHaQaVEQG9E004+XPzTY=",
                            UserName = "admin"
                        },
                        new
                        {
                            UserId = 2,
                            HashedPassword = "jHjOEJL4QnFSz2P4jSPV7mbNILD8bEdF6LPCsQr8WTI=",
                            Iterations = 1,
                            Salt = "J5uONlHya6G1w4NV3l70F0wa+vEw0df1jb+42PEAlyM=",
                            UserName = "user"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
