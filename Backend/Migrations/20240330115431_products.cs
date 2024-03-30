using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class products : Migration
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
                name: "GroceryProduct",
                columns: table => new
                {
                    Product_code = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Category = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Features = table.Column<string>(type: "text", nullable: true),
                    Huella = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroceryProduct", x => x.Product_code);
                });

            migrationBuilder.CreateTable(
                name: "SportProduct",
                columns: table => new
                {
                    Product_code = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Category = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Features = table.Column<string>(type: "text", nullable: true),
                    Huella = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportProduct", x => x.Product_code);
                });

            migrationBuilder.CreateTable(
                name: "TechnoProduct",
                columns: table => new
                {
                    Product_code = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Category = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Features = table.Column<string>(type: "text", nullable: true),
                    Huella = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnoProduct", x => x.Product_code);
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

            migrationBuilder.InsertData(
                table: "GroceryProduct",
                columns: new[] { "Product_code", "Category", "Description", "Features", "Huella", "Name", "Price" },
                values: new object[,]
                {
                    { 6, "Grocerie", "descripci�n6", "caracter�sticas6", 10, "product6", 16f },
                    { 7, "Grocerie", "descripci�n7", "caracter�sticas7", 13, "product7", 17f },
                    { 8, "Grocerie", "descripci�n8", "caracter�sticas8", -9, "product8", 18f },
                    { 9, "Grocerie", "descripci�n9", "caracter�sticas9", -16, "product9", 19f },
                    { 10, "Grocerie", "descripci�n10", "caracter�sticas10", -3, "product10", 20f },
                    { 11, "Grocerie", "descripci�n11", "caracter�sticas11", 24, "product11", 21f },
                    { 12, "Grocerie", "descripci�n12", "caracter�sticas12", 37, "product12", 22f },
                    { 13, "Grocerie", "descripci�n13", "caracter�sticas13", 45, "product13", 23f },
                    { 14, "Grocerie", "descripci�n14", "caracter�sticas14", 39, "product14", 24f },
                    { 15, "Grocerie", "descripci�n15", "caracter�sticas15", 5, "product15", 25f }
                });

            migrationBuilder.InsertData(
                table: "SportProduct",
                columns: new[] { "Product_code", "Category", "Description", "Features", "Huella", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Sports", "descripci�n1", "caracter�sticas1", 21, "product1", 11f },
                    { 2, "Sports", "descripci�n2", "caracter�sticas2", 52, "product2", 12f },
                    { 3, "Sports", "descripci�n3", "caracter�sticas3", 26, "product3", 13f },
                    { 4, "Sports", "descripci�n4", "caracter�sticas4", 19, "product4", 14f },
                    { 5, "Sports", "descripci�n5", "caracter�sticas5", -5, "product5", 15f }
                });

            migrationBuilder.InsertData(
                table: "TechnoProduct",
                columns: new[] { "Product_code", "Category", "Description", "Features", "Huella", "Name", "Price" },
                values: new object[,]
                {
                    { 11, "Techno", "descripci�n11", "caracter�sticas11", 18, "product11", 21f },
                    { 12, "Techno", "descripci�n12", "caracter�sticas12", 43, "product12", 22f },
                    { 13, "Techno", "descripci�n13", "caracter�sticas13", -4, "product13", 23f },
                    { 14, "Techno", "descripci�n14", "caracter�sticas14", 5, "product14", 24f },
                    { 15, "Techno", "descripci�n15", "caracter�sticas15", -17, "product15", 25f },
                    { 16, "Techno", "descripci�n16", "caracter�sticas16", 35, "product16", 26f },
                    { 17, "Techno", "descripci�n17", "caracter�sticas17", 13, "product17", 27f },
                    { 18, "Techno", "descripci�n18", "caracter�sticas18", 8, "product18", 28f },
                    { 19, "Techno", "descripci�n19", "caracter�sticas19", 6, "product19", 29f },
                    { 20, "Techno", "descripci�n20", "caracter�sticas20", 12, "product20", 30f },
                    { 21, "Techno", "descripci�n21", "caracter�sticas21", 38, "product21", 31f },
                    { 22, "Techno", "descripci�n22", "caracter�sticas22", -15, "product22", 32f },
                    { 23, "Techno", "descripci�n23", "caracter�sticas23", -12, "product23", 33f },
                    { 24, "Techno", "descripci�n24", "caracter�sticas24", 2, "product24", 34f },
                    { 25, "Techno", "descripci�n25", "caracter�sticas25", 4, "product25", 35f }
                });

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 31, 11, 54, 31, 379, DateTimeKind.Utc).AddTicks(2754), null, 53 },
                    { 2, new DateTime(2024, 4, 1, 11, 54, 31, 379, DateTimeKind.Utc).AddTicks(2787), null, -19 },
                    { 3, new DateTime(2024, 4, 2, 11, 54, 31, 379, DateTimeKind.Utc).AddTicks(2802), null, -18 },
                    { 4, new DateTime(2024, 4, 3, 11, 54, 31, 379, DateTimeKind.Utc).AddTicks(2811), null, 30 },
                    { 5, new DateTime(2024, 4, 4, 11, 54, 31, 379, DateTimeKind.Utc).AddTicks(2825), null, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gallery");

            migrationBuilder.DropTable(
                name: "GroceryProduct");

            migrationBuilder.DropTable(
                name: "SportProduct");

            migrationBuilder.DropTable(
                name: "TechnoProduct");

            migrationBuilder.DropTable(
                name: "WeatherForecasts");
        }
    }
}
