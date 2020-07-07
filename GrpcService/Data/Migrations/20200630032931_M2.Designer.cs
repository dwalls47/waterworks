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
    [Migration("20200630032931_M2")]
    partial class M2
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
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MeterId");

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

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            HashedPassword = "admin",
                            UserName = "admin"
                        },
                        new
                        {
                            UserId = 2,
                            HashedPassword = "user",
                            UserName = "user"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}