﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class migracionWishlist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gallery",
                columns: table => new
                {
                    Product_code = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gallery", x => x.Product_code);
                });

            migrationBuilder.CreateTable(
                name: "List",
                columns: table => new
                {
                    List_code = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_List", x => x.List_code);
                });

            migrationBuilder.CreateTable(
                name: "WeatherForecasts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TemperatureC = table.Column<int>(type: "integer", nullable: false),
                    Summary = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherForecasts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<int>(type: "integer", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    wishListId = table.Column<int>(type: "integer", nullable: true),
                    Company = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Email);
                    table.ForeignKey(
                        name: "FK_Person_List_wishListId",
                        column: x => x.wishListId,
                        principalTable: "List",
                        principalColumn: "List_code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Product_code = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Features = table.Column<string>(type: "text", nullable: true),
                    Huella = table.Column<int>(type: "integer", nullable: false),
                    Category = table.Column<string>(type: "text", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    List_code = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Product_code);
                    table.ForeignKey(
                        name: "FK_Products_List_List_code",
                        column: x => x.List_code,
                        principalTable: "List",
                        principalColumn: "List_code");
                });

            migrationBuilder.InsertData(
                table: "List",
                columns: new[] { "List_code", "Discriminator", "Name" },
                values: new object[] { 1, "WishList", "WishList" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Product_code", "Category", "Description", "Discriminator", "Features", "Huella", "List_code", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Sports", "descripcion1", "SportProduct", "caracteristicas1", 40, null, "product1", 11f },
                    { 2, "Sports", "descripcion2", "SportProduct", "caracteristicas2", 13, null, "product2", 12f },
                    { 3, "Sports", "descripcion3", "SportProduct", "caracteristicas3", 33, null, "product3", 13f },
                    { 4, "Sports", "descripcion4", "SportProduct", "caracteristicas4", 35, null, "product4", 14f },
                    { 5, "Sports", "descripcion5", "SportProduct", "caracteristicas5", -15, null, "product5", 15f },
                    { 6, "Grocery", "descripcion6", "GroceryProduct", "caracteristicas6", 30, null, "product6", 16f },
                    { 7, "Grocery", "descripcion7", "GroceryProduct", "caracteristicas7", 54, null, "product7", 17f },
                    { 8, "Grocery", "descripcion8", "GroceryProduct", "caracteristicas8", -20, null, "product8", 18f },
                    { 9, "Grocery", "descripcion9", "GroceryProduct", "caracteristicas9", 36, null, "product9", 19f },
                    { 10, "Grocery", "descripcion10", "GroceryProduct", "caracteristicas10", 23, null, "product10", 20f },
                    { 11, "Techno", "descripcion11", "TechnoProduct", "caracteristicas11", 52, null, "product11", 21f },
                    { 12, "Techno", "descripcion12", "TechnoProduct", "caracteristicas12", -5, null, "product12", 22f },
                    { 13, "Techno", "descripcion13", "TechnoProduct", "caracteristicas13", 17, null, "product13", 23f },
                    { 14, "Techno", "descripcion14", "TechnoProduct", "caracteristicas14", 44, null, "product14", 24f },
                    { 15, "Techno", "descripcion15", "TechnoProduct", "caracteristicas15", 16, null, "product15", 25f }
                });

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 14, 19, 15, 11, 985, DateTimeKind.Utc).AddTicks(1038), null, 36 },
                    { 2, new DateTime(2024, 4, 15, 19, 15, 11, 985, DateTimeKind.Utc).AddTicks(1063), null, 24 },
                    { 3, new DateTime(2024, 4, 16, 19, 15, 11, 985, DateTimeKind.Utc).AddTicks(1064), null, 14 },
                    { 4, new DateTime(2024, 4, 17, 19, 15, 11, 985, DateTimeKind.Utc).AddTicks(1065), null, 18 },
                    { 5, new DateTime(2024, 4, 18, 19, 15, 11, 985, DateTimeKind.Utc).AddTicks(1066), null, -17 }
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Email", "Discriminator", "FullName", "Password", "PhoneNumber", "wishListId" },
                values: new object[,]
                {
                    { "prueba1@prueba.com", "Client", "Cliente 1", "cliente1", 654654655, 1 },
                    { "prueba2@prueba.com", "Client", "Cliente 2", "cliente2", 654654656, 1 },
                    { "prueba3@prueba.com", "Client", "Cliente 3", "cliente3", 654654657, 1 },
                    { "prueba4@prueba.com", "Client", "Cliente 4", "cliente4", 654654658, 1 },
                    { "prueba5@prueba.com", "Client", "Cliente 5", "cliente5", 654654659, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Person_wishListId",
                table: "Person",
                column: "wishListId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_List_code",
                table: "Products",
                column: "List_code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gallery");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "WeatherForecasts");

            migrationBuilder.DropTable(
                name: "List");
        }
    }
}
