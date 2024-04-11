using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class Users : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "WeatherForecasts",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

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
                    Email = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullName = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<int>(type: "integer", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: true),
                    SalesPerson_Password = table.Column<string>(type: "text", nullable: true),
                    Company = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Product_code = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Features = table.Column<string>(type: "text", nullable: true),
                    Huella = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Product_code);
                });

            migrationBuilder.UpdateData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "Summary", "TemperatureC" },
                values: new object[] { new DateTime(2024, 4, 3, 13, 32, 39, 641, DateTimeKind.Utc).AddTicks(9211), null, 37 });

            migrationBuilder.UpdateData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "Summary", "TemperatureC" },
                values: new object[] { new DateTime(2024, 4, 4, 13, 32, 39, 641, DateTimeKind.Utc).AddTicks(9232), null, 35 });

            migrationBuilder.UpdateData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "Summary", "TemperatureC" },
                values: new object[] { new DateTime(2024, 4, 5, 13, 32, 39, 641, DateTimeKind.Utc).AddTicks(9232), null, 14 });

            migrationBuilder.UpdateData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date", "Summary", "TemperatureC" },
                values: new object[] { new DateTime(2024, 4, 6, 13, 32, 39, 641, DateTimeKind.Utc).AddTicks(9233), null, 27 });

            migrationBuilder.UpdateData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date", "Summary", "TemperatureC" },
                values: new object[] { new DateTime(2024, 4, 7, 13, 32, 39, 641, DateTimeKind.Utc).AddTicks(9233), null, 10 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gallery");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Date",
                table: "WeatherForecasts",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.UpdateData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "Summary", "TemperatureC" },
                values: new object[] { new DateOnly(2024, 3, 6), "Warm", 31 });

            migrationBuilder.UpdateData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "Summary", "TemperatureC" },
                values: new object[] { new DateOnly(2024, 3, 7), "Balmy", 50 });

            migrationBuilder.UpdateData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "Summary", "TemperatureC" },
                values: new object[] { new DateOnly(2024, 3, 8), "Freezing", 50 });

            migrationBuilder.UpdateData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date", "Summary", "TemperatureC" },
                values: new object[] { new DateOnly(2024, 3, 9), "Cool", -15 });

            migrationBuilder.UpdateData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date", "Summary", "TemperatureC" },
                values: new object[] { new DateOnly(2024, 3, 10), "Chilly", -14 });
        }
    }
}
