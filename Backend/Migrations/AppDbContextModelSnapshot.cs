﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Backend.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("SmartTrade.Models.Product", b =>
                {
                    b.Property<int>("Product_code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Product_code"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Discriminator")
                        .IsRequired()
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

                    b.ToTable("Products");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Product");

                    b.UseTphMappingStrategy();
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
                            Date = new DateTime(2024, 4, 1, 12, 48, 38, 746, DateTimeKind.Utc).AddTicks(3129),
                            TemperatureC = 44
                        },
                        new
                        {
                            Id = 2,
                            Date = new DateTime(2024, 4, 2, 12, 48, 38, 746, DateTimeKind.Utc).AddTicks(3143),
                            TemperatureC = -7
                        },
                        new
                        {
                            Id = 3,
                            Date = new DateTime(2024, 4, 3, 12, 48, 38, 746, DateTimeKind.Utc).AddTicks(3144),
                            TemperatureC = 40
                        },
                        new
                        {
                            Id = 4,
                            Date = new DateTime(2024, 4, 4, 12, 48, 38, 746, DateTimeKind.Utc).AddTicks(3144),
                            TemperatureC = -12
                        },
                        new
                        {
                            Id = 5,
                            Date = new DateTime(2024, 4, 5, 12, 48, 38, 746, DateTimeKind.Utc).AddTicks(3145),
                            TemperatureC = 52
                        });
                });

            modelBuilder.Entity("SmartTrade.Models.GroceryProduct", b =>
                {
                    b.HasBaseType("SmartTrade.Models.Product");

                    b.HasDiscriminator().HasValue("GroceryProduct");

                    b.HasData(
                        new
                        {
                            Product_code = 6,
                            Category = "Grocery",
                            Description = "descripcion6",
                            Features = "caracteristicas6",
                            Huella = 19,
                            Name = "product6",
                            Price = 16f
                        },
                        new
                        {
                            Product_code = 7,
                            Category = "Grocery",
                            Description = "descripcion7",
                            Features = "caracteristicas7",
                            Huella = 17,
                            Name = "product7",
                            Price = 17f
                        },
                        new
                        {
                            Product_code = 8,
                            Category = "Grocery",
                            Description = "descripcion8",
                            Features = "caracteristicas8",
                            Huella = 2,
                            Name = "product8",
                            Price = 18f
                        },
                        new
                        {
                            Product_code = 9,
                            Category = "Grocery",
                            Description = "descripcion9",
                            Features = "caracteristicas9",
                            Huella = 30,
                            Name = "product9",
                            Price = 19f
                        },
                        new
                        {
                            Product_code = 10,
                            Category = "Grocery",
                            Description = "descripcion10",
                            Features = "caracteristicas10",
                            Huella = 12,
                            Name = "product10",
                            Price = 20f
                        });
                });

            modelBuilder.Entity("SmartTrade.Models.SportProduct", b =>
                {
                    b.HasBaseType("SmartTrade.Models.Product");

                    b.HasDiscriminator().HasValue("SportProduct");

                    b.HasData(
                        new
                        {
                            Product_code = 1,
                            Category = "Sports",
                            Description = "descripcion1",
                            Features = "caracteristicas1",
                            Huella = 0,
                            Name = "product1",
                            Price = 11f
                        },
                        new
                        {
                            Product_code = 2,
                            Category = "Sports",
                            Description = "descripcion2",
                            Features = "caracteristicas2",
                            Huella = 10,
                            Name = "product2",
                            Price = 12f
                        },
                        new
                        {
                            Product_code = 3,
                            Category = "Sports",
                            Description = "descripcion3",
                            Features = "caracteristicas3",
                            Huella = -3,
                            Name = "product3",
                            Price = 13f
                        },
                        new
                        {
                            Product_code = 4,
                            Category = "Sports",
                            Description = "descripcion4",
                            Features = "caracteristicas4",
                            Huella = -9,
                            Name = "product4",
                            Price = 14f
                        },
                        new
                        {
                            Product_code = 5,
                            Category = "Sports",
                            Description = "descripcion5",
                            Features = "caracteristicas5",
                            Huella = 43,
                            Name = "product5",
                            Price = 15f
                        });
                });

            modelBuilder.Entity("SmartTrade.Models.TechnoProduct", b =>
                {
                    b.HasBaseType("SmartTrade.Models.Product");

                    b.HasDiscriminator().HasValue("TechnoProduct");

                    b.HasData(
                        new
                        {
                            Product_code = 11,
                            Category = "Techno",
                            Description = "descripcion11",
                            Features = "caracteristicas11",
                            Huella = 15,
                            Name = "product11",
                            Price = 21f
                        },
                        new
                        {
                            Product_code = 12,
                            Category = "Techno",
                            Description = "descripcion12",
                            Features = "caracteristicas12",
                            Huella = 33,
                            Name = "product12",
                            Price = 22f
                        },
                        new
                        {
                            Product_code = 13,
                            Category = "Techno",
                            Description = "descripcion13",
                            Features = "caracteristicas13",
                            Huella = 52,
                            Name = "product13",
                            Price = 23f
                        },
                        new
                        {
                            Product_code = 14,
                            Category = "Techno",
                            Description = "descripcion14",
                            Features = "caracteristicas14",
                            Huella = 48,
                            Name = "product14",
                            Price = 24f
                        },
                        new
                        {
                            Product_code = 15,
                            Category = "Techno",
                            Description = "descripcion15",
                            Features = "caracteristicas15",
                            Huella = 31,
                            Name = "product15",
                            Price = 25f
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
