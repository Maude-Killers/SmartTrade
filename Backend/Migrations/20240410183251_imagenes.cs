using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class imagenes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gallery",
                columns: table => new
                {
                    Image = table.Column<string>(type: "text", nullable: false),
                    Product_code = table.Column<int>(type: "integer", nullable: true),
                    Category_name = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gallery", x => x.Image);
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
                    Discriminator = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Product_code);
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
                table: "Gallery",
                columns: new[] { "Image", "Category_name", "Product_code" },
                values: new object[,]
                {
                    { "https://hips.hearstapps.com/hmg-prod/images/online-buying-and-delivery-concept-royalty-free-image-1675370119.jpg", 1, null },
                    { "https://i.imgur.com/0kTxfNT.png", null, 3 },
                    { "https://i.imgur.com/9ZpZZfe.png", null, 6 },
                    { "https://i.imgur.com/ADMjfOX.png", null, 10 },
                    { "https://i.imgur.com/ATQsdPb.png", null, 9 },
                    { "https://i.imgur.com/B9UeUnE.png", null, 15 },
                    { "https://i.imgur.com/bRFgYfL.png", null, 2 },
                    { "https://i.imgur.com/icpDfTu.png", null, 14 },
                    { "https://i.imgur.com/IMMlRaG.png", null, 11 },
                    { "https://i.imgur.com/kgj7C77.png", null, 8 },
                    { "https://i.imgur.com/qImnFwc.png", null, 13 },
                    { "https://i.imgur.com/qNLCqrT.png", null, 12 },
                    { "https://i.imgur.com/tewVKu5.png", null, 4 },
                    { "https://i.imgur.com/VcVlhzr.png", null, 5 },
                    { "https://i.imgur.com/WtfQOF3.png", null, 1 },
                    { "https://i.imgur.com/YgKapTz.png", null, 7 },
                    { "https://miro.medium.com/v2/resize:fit:720/format:webp/1*f9N5gbBNXLGqD7NgjzVg5g.jpeg", 0, null },
                    { "https://www.timeshighereducation.com/student/sites/default/files/styles/default/public/different_sports.jpg", 2, null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Product_code", "Category", "Description", "Discriminator", "Features", "Huella", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Sports", "descripcion1", "SportProduct", "caracteristicas1", 34, "product1", 11f },
                    { 2, "Sports", "descripcion2", "SportProduct", "caracteristicas2", 51, "product2", 12f },
                    { 3, "Sports", "descripcion3", "SportProduct", "caracteristicas3", 47, "product3", 13f },
                    { 4, "Sports", "descripcion4", "SportProduct", "caracteristicas4", -5, "product4", 14f },
                    { 5, "Sports", "descripcion5", "SportProduct", "caracteristicas5", 43, "product5", 15f },
                    { 6, "Grocery", "descripcion6", "GroceryProduct", "caracteristicas6", -2, "product6", 16f },
                    { 7, "Grocery", "descripcion7", "GroceryProduct", "caracteristicas7", 52, "product7", 17f },
                    { 8, "Grocery", "descripcion8", "GroceryProduct", "caracteristicas8", -17, "product8", 18f },
                    { 9, "Grocery", "descripcion9", "GroceryProduct", "caracteristicas9", -5, "product9", 19f },
                    { 10, "Grocery", "descripcion10", "GroceryProduct", "caracteristicas10", 54, "product10", 20f },
                    { 11, "Techno", "descripcion11", "TechnoProduct", "caracteristicas11", 19, "product11", 21f },
                    { 12, "Techno", "descripcion12", "TechnoProduct", "caracteristicas12", 13, "product12", 22f },
                    { 13, "Techno", "descripcion13", "TechnoProduct", "caracteristicas13", 42, "product13", 23f },
                    { 14, "Techno", "descripcion14", "TechnoProduct", "caracteristicas14", 53, "product14", 24f },
                    { 15, "Techno", "descripcion15", "TechnoProduct", "caracteristicas15", 0, "product15", 25f }
                });

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 11, 18, 32, 51, 525, DateTimeKind.Utc).AddTicks(6740), null, 40 },
                    { 2, new DateTime(2024, 4, 12, 18, 32, 51, 525, DateTimeKind.Utc).AddTicks(6764), null, 51 },
                    { 3, new DateTime(2024, 4, 13, 18, 32, 51, 525, DateTimeKind.Utc).AddTicks(6765), null, 36 },
                    { 4, new DateTime(2024, 4, 14, 18, 32, 51, 525, DateTimeKind.Utc).AddTicks(6765), null, 18 },
                    { 5, new DateTime(2024, 4, 15, 18, 32, 51, 525, DateTimeKind.Utc).AddTicks(6766), null, 18 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gallery");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "WeatherForecasts");
        }
    }
}
