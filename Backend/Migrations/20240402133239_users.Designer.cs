﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Backend.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240402133239_users")]
    partial class Users
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SmartTrade.Models.Gallery", b =>
                {
                    b.Property<int>("Product_code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Product_code"));

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.HasKey("Product_code");

                    b.ToTable("Gallery");
                });

            modelBuilder.Entity("SmartTrade.Models.Person", b =>
                {
                    b.Property<int>("Email")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Email"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("integer");

                    b.HasKey("Email");

                    b.ToTable("Person");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("SmartTrade.Models.Product", b =>
                {
                    b.Property<int>("Product_code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Product_code"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Features")
                        .HasColumnType("text");

                    b.Property<int>("Huella")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("Product_code");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("SmartTrade.Models.WeatherForecast", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Summary")
                        .HasColumnType("text");

                    b.Property<int>("TemperatureC")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("WeatherForecasts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = new DateTime(2024, 4, 3, 13, 32, 39, 641, DateTimeKind.Utc).AddTicks(9211),
                            TemperatureC = 37
                        },
                        new
                        {
                            Id = 2,
                            Date = new DateTime(2024, 4, 4, 13, 32, 39, 641, DateTimeKind.Utc).AddTicks(9232),
                            TemperatureC = 35
                        },
                        new
                        {
                            Id = 3,
                            Date = new DateTime(2024, 4, 5, 13, 32, 39, 641, DateTimeKind.Utc).AddTicks(9232),
                            TemperatureC = 14
                        },
                        new
                        {
                            Id = 4,
                            Date = new DateTime(2024, 4, 6, 13, 32, 39, 641, DateTimeKind.Utc).AddTicks(9233),
                            TemperatureC = 27
                        },
                        new
                        {
                            Id = 5,
                            Date = new DateTime(2024, 4, 7, 13, 32, 39, 641, DateTimeKind.Utc).AddTicks(9233),
                            TemperatureC = 10
                        });
                });

            modelBuilder.Entity("SmartTrade.Models.Client", b =>
                {
                    b.HasBaseType("SmartTrade.Models.Person");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("Client");
                });

            modelBuilder.Entity("SmartTrade.Models.SalesPerson", b =>
                {
                    b.HasBaseType("SmartTrade.Models.Person");

                    b.Property<string>("Company")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.ToTable("Person", t =>
                        {
                            t.Property("Password")
                                .HasColumnName("SalesPerson_Password");
                        });

                    b.HasDiscriminator().HasValue("SalesPerson");
                });
#pragma warning restore 612, 618
        }
    }
}
