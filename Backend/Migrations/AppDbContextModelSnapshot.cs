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

            modelBuilder.Entity("SmartTrade.Models.List", b =>
                {
                    b.Property<int>("List_code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("List_code"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("List_code");

                    b.ToTable("List");

                    b.HasDiscriminator<string>("Discriminator").HasValue("List");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("SmartTrade.Models.Person", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
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

                    b.Property<int?>("List_code")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("Product_code");

                    b.HasIndex("List_code");

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
                            Date = new DateTime(2024, 4, 13, 19, 4, 46, 899, DateTimeKind.Utc).AddTicks(9548),
                            TemperatureC = 49
                        },
                        new
                        {
                            Id = 2,
                            Date = new DateTime(2024, 4, 14, 19, 4, 46, 899, DateTimeKind.Utc).AddTicks(9563),
                            TemperatureC = -20
                        },
                        new
                        {
                            Id = 3,
                            Date = new DateTime(2024, 4, 15, 19, 4, 46, 899, DateTimeKind.Utc).AddTicks(9564),
                            TemperatureC = 47
                        },
                        new
                        {
                            Id = 4,
                            Date = new DateTime(2024, 4, 16, 19, 4, 46, 899, DateTimeKind.Utc).AddTicks(9564),
                            TemperatureC = 31
                        },
                        new
                        {
                            Id = 5,
                            Date = new DateTime(2024, 4, 17, 19, 4, 46, 899, DateTimeKind.Utc).AddTicks(9565),
                            TemperatureC = 52
                        });
                });

            modelBuilder.Entity("SmartTrade.Models.WishList", b =>
                {
                    b.HasBaseType("SmartTrade.Models.List");

                    b.HasDiscriminator().HasValue("WishList");
                });

            modelBuilder.Entity("SmartTrade.Models.Client", b =>
                {
                    b.HasBaseType("SmartTrade.Models.Person");

                    b.HasDiscriminator().HasValue("Client");

                    b.HasData(
                        new
                        {
                            Email = "prueba1@prueba.com",
                            FullName = "Cliente 1",
                            Password = "cliente1",
                            PhoneNumber = 654654655
                        },
                        new
                        {
                            Email = "prueba2@prueba.com",
                            FullName = "Cliente 2",
                            Password = "cliente2",
                            PhoneNumber = 654654656
                        },
                        new
                        {
                            Email = "prueba3@prueba.com",
                            FullName = "Cliente 3",
                            Password = "cliente3",
                            PhoneNumber = 654654657
                        },
                        new
                        {
                            Email = "prueba4@prueba.com",
                            FullName = "Cliente 4",
                            Password = "cliente4",
                            PhoneNumber = 654654658
                        },
                        new
                        {
                            Email = "prueba5@prueba.com",
                            FullName = "Cliente 5",
                            Password = "cliente5",
                            PhoneNumber = 654654659
                        });
                });

            modelBuilder.Entity("SmartTrade.Models.SalesPerson", b =>
                {
                    b.HasBaseType("SmartTrade.Models.Person");

                    b.Property<string>("Company")
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("SalesPerson");
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
                            Huella = 32,
                            Name = "product6",
                            Price = 16f
                        },
                        new
                        {
                            Product_code = 7,
                            Category = "Grocery",
                            Description = "descripcion7",
                            Features = "caracteristicas7",
                            Huella = 24,
                            Name = "product7",
                            Price = 17f
                        },
                        new
                        {
                            Product_code = 8,
                            Category = "Grocery",
                            Description = "descripcion8",
                            Features = "caracteristicas8",
                            Huella = -18,
                            Name = "product8",
                            Price = 18f
                        },
                        new
                        {
                            Product_code = 9,
                            Category = "Grocery",
                            Description = "descripcion9",
                            Features = "caracteristicas9",
                            Huella = 40,
                            Name = "product9",
                            Price = 19f
                        },
                        new
                        {
                            Product_code = 10,
                            Category = "Grocery",
                            Description = "descripcion10",
                            Features = "caracteristicas10",
                            Huella = -15,
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
                            Huella = 32,
                            Name = "product1",
                            Price = 11f
                        },
                        new
                        {
                            Product_code = 2,
                            Category = "Sports",
                            Description = "descripcion2",
                            Features = "caracteristicas2",
                            Huella = 12,
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
                            Huella = 17,
                            Name = "product4",
                            Price = 14f
                        },
                        new
                        {
                            Product_code = 5,
                            Category = "Sports",
                            Description = "descripcion5",
                            Features = "caracteristicas5",
                            Huella = 27,
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
                            Huella = 53,
                            Name = "product11",
                            Price = 21f
                        },
                        new
                        {
                            Product_code = 12,
                            Category = "Techno",
                            Description = "descripcion12",
                            Features = "caracteristicas12",
                            Huella = 11,
                            Name = "product12",
                            Price = 22f
                        },
                        new
                        {
                            Product_code = 13,
                            Category = "Techno",
                            Description = "descripcion13",
                            Features = "caracteristicas13",
                            Huella = 18,
                            Name = "product13",
                            Price = 23f
                        },
                        new
                        {
                            Product_code = 14,
                            Category = "Techno",
                            Description = "descripcion14",
                            Features = "caracteristicas14",
                            Huella = 15,
                            Name = "product14",
                            Price = 24f
                        },
                        new
                        {
                            Product_code = 15,
                            Category = "Techno",
                            Description = "descripcion15",
                            Features = "caracteristicas15",
                            Huella = 26,
                            Name = "product15",
                            Price = 25f
                        });
                });

            modelBuilder.Entity("SmartTrade.Models.Product", b =>
                {
                    b.HasOne("SmartTrade.Models.List", null)
                        .WithMany("Products")
                        .HasForeignKey("List_code");
                });

            modelBuilder.Entity("SmartTrade.Models.List", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
