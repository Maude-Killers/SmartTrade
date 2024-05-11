using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class OOP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Features = table.Column<string>(type: "text", nullable: true),
                    FingerPrint = table.Column<int>(type: "integer", nullable: false),
                    Category = table.Column<int>(type: "integer", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Product_code);
                });

            migrationBuilder.CreateTable(
                name: "List",
                columns: table => new
                {
                    List_code = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    GiftListEntity_ClientEmail = table.Column<string>(type: "text", nullable: true),
                    ClientEmail = table.Column<string>(type: "text", nullable: true),
                    ShoppingCartEntity_ClientEmail = table.Column<string>(type: "text", nullable: true),
                    WishListEntity_ClientEmail = table.Column<string>(type: "text", nullable: true)
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
                    table.ForeignKey(
                        name: "FK_List_Person_GiftListEntity_ClientEmail",
                        column: x => x.GiftListEntity_ClientEmail,
                        principalTable: "Person",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_List_Person_ShoppingCartEntity_ClientEmail",
                        column: x => x.ShoppingCartEntity_ClientEmail,
                        principalTable: "Person",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_List_Person_WishListEntity_ClientEmail",
                        column: x => x.WishListEntity_ClientEmail,
                        principalTable: "Person",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gallery",
                columns: table => new
                {
                    Image = table.Column<string>(type: "text", nullable: false),
                    Product_code = table.Column<int>(type: "integer", nullable: true),
                    Category = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gallery", x => x.Image);
                    table.ForeignKey(
                        name: "FK_Gallery_Products_Product_code",
                        column: x => x.Product_code,
                        principalTable: "Products",
                        principalColumn: "Product_code");
                });

            migrationBuilder.CreateTable(
                name: "ListProducts",
                columns: table => new
                {
                    List_code = table.Column<int>(type: "integer", nullable: false),
                    Product_code = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
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
                table: "Gallery",
                columns: new[] { "Image", "Category", "Product_code" },
                values: new object[,]
                {
                    { "https://hips.hearstapps.com/hmg-prod/images/online-buying-and-delivery-concept-royalty-free-image-1675370119.jpg", 1, null },
                    { "https://miro.medium.com/v2/resize:fit:720/format:webp/1*f9N5gbBNXLGqD7NgjzVg5g.jpeg", 0, null },
                    { "https://www.timeshighereducation.com/student/sites/default/files/styles/default/public/different_sports.jpg", 2, null }
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Email", "Discriminator", "FullName", "Password", "PhoneNumber" },
                values: new object[,]
                {
                    { "prueba1@prueba.com", "ClientEntity", "Cliente 1", "cliente1", 654654655 },
                    { "prueba2@prueba.com", "ClientEntity", "Cliente 2", "cliente2", 654654656 },
                    { "prueba3@prueba.com", "ClientEntity", "Cliente 3", "cliente3", 654654657 },
                    { "prueba4@prueba.com", "ClientEntity", "Cliente 4", "cliente4", 654654658 },
                    { "prueba5@prueba.com", "ClientEntity", "Cliente 5", "cliente5", 654654659 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Product_code", "Category", "Description", "Discriminator", "Features", "FingerPrint", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 2, "descripcion1", "SportProductEntity", "caracteristicas1", 21, "product1", 11m },
                    { 2, 2, "descripcion2", "SportProductEntity", "caracteristicas2", 0, "product2", 12m },
                    { 3, 2, "descripcion3", "SportProductEntity", "caracteristicas3", 13, "product3", 13m },
                    { 4, 2, "descripcion4", "SportProductEntity", "caracteristicas4", 49, "product4", 14m },
                    { 5, 2, "descripcion5", "SportProductEntity", "caracteristicas5", 24, "product5", 15m },
                    { 6, 1, "descripcion6", "GroceryProductEntity", "caracteristicas6", 28, "product6", 16m },
                    { 7, 1, "descripcion7", "GroceryProductEntity", "caracteristicas7", 36, "product7", 17m },
                    { 8, 1, "descripcion8", "GroceryProductEntity", "caracteristicas8", -6, "product8", 18m },
                    { 9, 1, "descripcion9", "GroceryProductEntity", "caracteristicas9", 16, "product9", 19m },
                    { 10, 1, "descripcion10", "GroceryProductEntity", "caracteristicas10", -4, "product10", 20m },
                    { 11, 0, "descripcion11", "TechnoProductEntity", "caracteristicas11", 38, "product11", 21m },
                    { 12, 0, "descripcion12", "TechnoProductEntity", "caracteristicas12", 10, "product12", 22m },
                    { 13, 0, "descripcion13", "TechnoProductEntity", "caracteristicas13", 27, "product13", 23m },
                    { 14, 0, "descripcion14", "TechnoProductEntity", "caracteristicas14", 23, "product14", 24m },
                    { 15, 0, "descripcion15", "TechnoProductEntity", "caracteristicas15", -14, "product15", 25m }
                });

            migrationBuilder.InsertData(
                table: "Gallery",
                columns: new[] { "Image", "Category", "Product_code" },
                values: new object[,]
                {
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
                    { "https://i.imgur.com/YgKapTz.png", null, 7 }
                });

            migrationBuilder.InsertData(
                table: "List",
                columns: new[] { "List_code", "WishListEntity_ClientEmail", "Discriminator", "Name" },
                values: new object[,]
                {
                    { 1, "prueba1@prueba.com", "WishListEntity", "WishList" },
                    { 2, "prueba2@prueba.com", "WishListEntity", "WishList" },
                    { 3, "prueba3@prueba.com", "WishListEntity", "WishList" },
                    { 4, "prueba4@prueba.com", "WishListEntity", "WishList" },
                    { 5, "prueba5@prueba.com", "WishListEntity", "WishList" }
                });

            migrationBuilder.InsertData(
                table: "List",
                columns: new[] { "List_code", "GiftListEntity_ClientEmail", "Discriminator", "Name" },
                values: new object[,]
                {
                    { 6, "prueba1@prueba.com", "GiftListEntity", "GiftList" },
                    { 7, "prueba2@prueba.com", "GiftListEntity", "GiftList" },
                    { 8, "prueba3@prueba.com", "GiftListEntity", "GiftList" },
                    { 9, "prueba4@prueba.com", "GiftListEntity", "GiftList" },
                    { 10, "prueba5@prueba.com", "GiftListEntity", "GiftList" }
                });

            migrationBuilder.InsertData(
                table: "List",
                columns: new[] { "List_code", "ShoppingCartEntity_ClientEmail", "Discriminator", "Name" },
                values: new object[,]
                {
                    { 11, "prueba1@prueba.com", "ShoppingCartEntity", "ShoppingCart" },
                    { 12, "prueba2@prueba.com", "ShoppingCartEntity", "ShoppingCart" },
                    { 13, "prueba3@prueba.com", "ShoppingCartEntity", "ShoppingCart" },
                    { 14, "prueba4@prueba.com", "ShoppingCartEntity", "ShoppingCart" },
                    { 15, "prueba5@prueba.com", "ShoppingCartEntity", "ShoppingCart" }
                });

            migrationBuilder.InsertData(
                table: "List",
                columns: new[] { "List_code", "ClientEmail", "Discriminator", "Name" },
                values: new object[,]
                {
                    { 16, "prueba1@prueba.com", "LaterListEntity", "LaterList" },
                    { 17, "prueba2@prueba.com", "LaterListEntity", "LaterList" },
                    { 18, "prueba3@prueba.com", "LaterListEntity", "LaterList" },
                    { 19, "prueba4@prueba.com", "LaterListEntity", "LaterList" },
                    { 20, "prueba5@prueba.com", "LaterListEntity", "LaterList" }
                });

            migrationBuilder.InsertData(
                table: "ListProducts",
                columns: new[] { "List_code", "Product_code", "Quantity" },
                values: new object[,]
                {
                    { 6, 6, 1 },
                    { 7, 7, 1 },
                    { 8, 8, 1 },
                    { 9, 9, 1 },
                    { 10, 10, 1 },
                    { 1, 11, 1 },
                    { 2, 12, 1 },
                    { 3, 13, 1 },
                    { 4, 14, 1 },
                    { 5, 15, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gallery_Product_code",
                table: "Gallery",
                column: "Product_code");

            migrationBuilder.CreateIndex(
                name: "IX_List_ClientEmail",
                table: "List",
                column: "ClientEmail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_List_GiftListEntity_ClientEmail",
                table: "List",
                column: "GiftListEntity_ClientEmail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_List_ShoppingCartEntity_ClientEmail",
                table: "List",
                column: "ShoppingCartEntity_ClientEmail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_List_WishListEntity_ClientEmail",
                table: "List",
                column: "WishListEntity_ClientEmail",
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
                name: "List");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
