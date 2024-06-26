﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeatherApi.Context;

#nullable disable

namespace WeatherApi.Migrations
{
    [DbContext(typeof(WeatherDbContext))]
    [Migration("20240111142011_Weather db initialization")]
    partial class Weatherdbinitialization
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WeatherApi.DTO.Condition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("icon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Condition");
                });

            modelBuilder.Entity("WeatherApi.DTO.Current", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("cloud")
                        .HasColumnType("int");

                    b.Property<int>("conditionId")
                        .HasColumnType("int");

                    b.Property<int>("is_day")
                        .HasColumnType("int");

                    b.Property<double>("temp_c")
                        .HasColumnType("float");

                    b.Property<double>("temp_f")
                        .HasColumnType("float");

                    b.Property<int>("wind_degree")
                        .HasColumnType("int");

                    b.Property<string>("wind_dir")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("wind_kph")
                        .HasColumnType("float");

                    b.Property<double>("wind_mph")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("conditionId");

                    b.ToTable("Current");
                });

            modelBuilder.Entity("WeatherApi.DTO.Location", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("lat")
                        .HasColumnType("float");

                    b.Property<string>("localtime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("lon")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("WeatherApi.DTO.Weather", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("currentId")
                        .HasColumnType("int");

                    b.Property<int>("locationID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("currentId");

                    b.HasIndex("locationID");

                    b.ToTable("CuontryWeather");
                });

            modelBuilder.Entity("WeatherApi.DTO.Current", b =>
                {
                    b.HasOne("WeatherApi.DTO.Condition", "condition")
                        .WithMany()
                        .HasForeignKey("conditionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("condition");
                });

            modelBuilder.Entity("WeatherApi.DTO.Weather", b =>
                {
                    b.HasOne("WeatherApi.DTO.Current", "current")
                        .WithMany()
                        .HasForeignKey("currentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WeatherApi.DTO.Location", "location")
                        .WithMany()
                        .HasForeignKey("locationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("current");

                    b.Navigation("location");
                });
#pragma warning restore 612, 618
        }
    }
}
