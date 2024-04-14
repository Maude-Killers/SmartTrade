using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class DbContextMigration : Migration
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
                name: "Person",
                columns: table => new
                {
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<int>(type: "integer", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    Company = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Product_code = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Features = table.Column<string>(type: "text", nullable: true),
                    Huella = table.Column<int>(type: "integer", nullable: true),
                    Category = table.Column<string>(type: "text", nullable: true),
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

            migrationBuilder.CreateTable(
                name: "List",
                columns: table => new
                {
                    List_code = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    ClientEmail = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_List", x => x.List_code);
                    table.ForeignKey(
                        name: "FK_List_Person_ClientEmail",
                        column: x => x.ClientEmail,
                        principalTable: "Person",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListProducts",
                columns: table => new
                {
                    List_code = table.Column<int>(type: "integer", nullable: false),
                    Product_code = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListProducts", x => new { x.Product_code, x.List_code });
                    table.ForeignKey(
                        name: "FK_ListProducts_List_List_code",
                        column: x => x.List_code,
                        principalTable: "List",
                        principalColumn: "List_code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListProducts_Products_Product_code",
                        column: x => x.Product_code,
                        principalTable: "Products",
                        principalColumn: "Product_code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Email", "Discriminator", "FullName", "Password", "PhoneNumber" },
                values: new object[,]
                {
                    { "prueba1@prueba.com", "Client", "Cliente 1", "cliente1", 654654655 },
                    { "prueba2@prueba.com", "Client", "Cliente 2", "cliente2", 654654656 },
                    { "prueba3@prueba.com", "Client", "Cliente 3", "cliente3", 654654657 },
                    { "prueba4@prueba.com", "Client", "Cliente 4", "cliente4", 654654658 },
                    { "prueba5@prueba.com", "Client", "Cliente 5", "cliente5", 654654659 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Product_code", "Category", "Description", "Discriminator", "Features", "Huella", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Sports", "descripcion1", "SportProduct", "caracteristicas1", 12, "product1", 11m },
                    { 2, "Sports", "descripcion2", "SportProduct", "caracteristicas2", 33, "product2", 12m },
                    { 3, "Sports", "descripcion3", "SportProduct", "caracteristicas3", 24, "product3", 13m },
                    { 4, "Sports", "descripcion4", "SportProduct", "caracteristicas4", 4, "product4", 14m },
                    { 5, "Sports", "descripcion5", "SportProduct", "caracteristicas5", 45, "product5", 15m },
                    { 6, "Grocery", "descripcion6", "GroceryProduct", "caracteristicas6", 35, "product6", 16m },
                    { 7, "Grocery", "descripcion7", "GroceryProduct", "caracteristicas7", -3, "product7", 17m },
                    { 8, "Grocery", "descripcion8", "GroceryProduct", "caracteristicas8", -17, "product8", 18m },
                    { 9, "Grocery", "descripcion9", "GroceryProduct", "caracteristicas9", 18, "product9", 19m },
                    { 10, "Grocery", "descripcion10", "GroceryProduct", "caracteristicas10", 28, "product10", 20m },
                    { 11, "Techno", "descripcion11", "TechnoProduct", "caracteristicas11", 22, "product11", 21m },
                    { 12, "Techno", "descripcion12", "TechnoProduct", "caracteristicas12", -2, "product12", 22m },
                    { 13, "Techno", "descripcion13", "TechnoProduct", "caracteristicas13", 11, "product13", 23m },
                    { 14, "Techno", "descripcion14", "TechnoProduct", "caracteristicas14", -6, "product14", 24m },
                    { 15, "Techno", "descripcion15", "TechnoProduct", "caracteristicas15", 26, "product15", 25m }
                });

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 15, 8, 5, 43, 50, DateTimeKind.Utc).AddTicks(16), null, 17 },
                    { 2, new DateTime(2024, 4, 16, 8, 5, 43, 50, DateTimeKind.Utc).AddTicks(39), null, 27 },
                    { 3, new DateTime(2024, 4, 17, 8, 5, 43, 50, DateTimeKind.Utc).AddTicks(40), null, -4 },
                    { 4, new DateTime(2024, 4, 18, 8, 5, 43, 50, DateTimeKind.Utc).AddTicks(41), null, 27 },
                    { 5, new DateTime(2024, 4, 19, 8, 5, 43, 50, DateTimeKind.Utc).AddTicks(42), null, -7 }
                });

            migrationBuilder.InsertData(
                table: "List",
                columns: new[] { "List_code", "ClientEmail", "Discriminator", "Name" },
                values: new object[,]
                {
                    { 1, "prueba1@prueba.com", "WishList", "WishList" },
                    { 2, "prueba2@prueba.com", "WishList", "WishList" },
                    { 3, "prueba3@prueba.com", "WishList", "WishList" },
                    { 4, "prueba4@prueba.com", "WishList", "WishList" },
                    { 5, "prueba5@prueba.com", "WishList", "WishList" }
                });

            migrationBuilder.InsertData(
                table: "ListProducts",
                columns: new[] { "List_code", "Product_code" },
                values: new object[,]
                {
                    { 1, 11 },
                    { 2, 12 },
                    { 3, 13 },
                    { 4, 14 },
                    { 5, 15 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_List_ClientEmail",
                table: "List",
                column: "ClientEmail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ListProducts_List_code",
                table: "ListProducts",
                column: "List_code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gallery");

            migrationBuilder.DropTable(
                name: "ListProducts");

            migrationBuilder.DropTable(
                name: "WeatherForecasts");

            migrationBuilder.DropTable(
                name: "List");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
