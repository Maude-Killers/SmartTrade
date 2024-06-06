using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class productosDescriptivos : Migration
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
                    { 1, 2, "Zapatillas Nike Court Vision color blanco y verde, inspirado en el baloncesto de los 80Nike Court Vision Mid reúne el rétro del parquet y la comodidad moderna, con materiales reciclados para al menos el 20% de su peso. La suela tiene piezas en Nike Grind, mientras que el Tomaia testurizado en cuero sintético mantiene el aspecto clásico que le gusta tanto.", "SportProductEntity", "Dimensiones del producto : 34 x 23 x 12 cm; 500 g\nMaterial de la suelaCaucho\nAltura de ejeAnkle Strap\nMaterial exteriorSintético\nMaterial internoSynthetic", 23, "Zapatillas Nike", 90m },
                    { 2, 2, "Raqueta de espuma suave con protector integrado para mayor durabilidad, mayor potencia y menos vibraciones. La raqueta tiene un cuadro de carbono. Es la elección perfecta para los jóvenes", "SportProductEntity", "Dimensiones del producto : 45 x 22 x 4 cm; 200 g\nMaterial : Grafito\nMaterial del marco : Carbono\nMaterial de la varilla : Fibra de carbono\n", -16, "Raqueta pádel", 80m },
                    { 3, 2, "con la bolsa de FITGRIFF puede esperar una bolsa multiusos moderna y bien pensada: súper adecuada como bolsa de entrenamiento, bolsa de viaje, bolsa de baño", "SportProductEntity", "Dimensiones del producto : 48 x 26 x 25 cm; 700 g\nFabricante : Fitgriff\nMaterial: 100% poliéster\n", -6, "Bolsa de gimnasio", 23m },
                    { 4, 2, " el balón de fútbol está hecho de cuero de PVC suave y cosido con máquinas exquisitas para proporcionar una sensación de mano suave y equilibrada,resistente al desgaste y duradero. Revestimiento a prueba de explosiones", "SportProductEntity", "Dimensiones del producto : 27 x 13,7 x 12 cm; 540 g\nMaterial : Cuero\nMarca : Aipwerer\n", -20, "Balón fútbol", 30m },
                    { 5, 2, "Tejido de malla suave y confortable, cómodo y transpirable la camiseta deportiva tiene un corte holgado y es cómoda de llevar. Confeccionada con un tejido transpirable y que absorbe la humedad, absorbe el sudor y se seca rápidamente", "SportProductEntity", "Dimensiones del producto : 15 x 10 x 1 cm; 300 g\nMaterial : dry-fit 100% poliéster \nMarca : Herbalife\n", -14, "Camiseta de deporte", 25m },
                    { 6, 1, "Tomate de rama de gran calidad, proveniente de Almería", "GroceryProductEntity", "Dimensiones del producto : 7 x 8 x 7 cm; 250 g\nFabricante : MERCOPHAL, S.L\n", -17, "Tomates", 1m },
                    { 7, 1, "Lechuga trocadero de gran calidad, proveniente de Francia", "GroceryProductEntity", "Dimensiones del producto : 24,5 x 17 x 9,5 cm; 380 g\nFabricante : Felixia\nInstrucciones de almacenaje : 6° C -8° C\n", 47, "Lechuga trocadero", 2m },
                    { 8, 1, "Calabacín de gran calidad, proveniente de España", "GroceryProductEntity", "Dimensiones del producto : 18,01 x 5 x 3,99 cm; 500 g\nFabricante : Eurobanan\nInstrucciones de almacenaje : 6° C -8° C\n", 11, "Calabacín", 1m },
                    { 9, 1, "Platanos de gran calidad, provenientes de Canarias", "GroceryProductEntity", "Dimensiones del producto : 24 x 20 x 8 cm; 1,2 kg\nFabricante : ARC-EUROBANAN, S.L.\nConsumir preferiblemente en 2-3 días\n", 41, "Plátano de canarias", 2m },
                    { 10, 1, "Melón de gran calidad, proveniente de Canarias", "GroceryProductEntity", "Dimensiones del producto : 5,99 x 5 x 3,99 cm; 1,25 kg\nFabricante : Felixia\nInstrucciones de almacenaje : 10° C -12° C\n", 23, "Melón Cantaloup", 7m },
                    { 11, 0, "De tamaño mediano, fácil de agarrar para la mayoría de las personas, el peso ultraligero es de solo 75 gramos, diseño de panal ergonómico, fácil de agarrar y operar en juegos y oficinas", "TechnoProductEntity", "Dimensiones del producto : 12,6 x 6,3 x 4 cm; 105 g\nFabricante : DIERYA\nSistema operativo: Windows 7/10\n", 25, "Ratón gaming", 32m },
                    { 12, 0, "Teclado ultra responsivo + silencioso. disfrute de tiempos de respuesta rapidísimos con la tecnología inalámbrica de 2,4 ghz. el keyz tungsten ofrece una respuesta mucho más rápida y precisa que la mayoría de los teclados inalámbricos para juegos del mercado", "TechnoProductEntity", "Dimensiones del producto : 25,4 x 5,08 x 6,86 cm; 800 g\nFabricante : AXS\nSistema operativo: Windows\n", -15, "Teclado gaming", 42m },
                    { 13, 0, "el monitor de 24 pulgadas adopta una nueva generación de pantalla VA, que cubre el 99 % de la gama de colores SRGB. Por lo tanto, el monitor de la computadora puede restaurar al 100% los colores reales y presentar detalles vívidos. Además, el amplio ángulo de visión de 178° de este monitor de PC le permite disfrutar de imágenes claras, nítidas y delicadas desde cualquier ángulo.", "TechnoProductEntity", "Dimensiones del producto : 42,32 x 54,2 x 18,11 cm; 3,63 kg\nFabricante : KOORUI\nInterfaz del hardware: VGA, HDMI\n", 10, "Monitor", 202m },
                    { 14, 0, "El ventilador Aura II ha sido fabricado con el exclusivo y reconocido sistema de rodamientos de alta tecnología Tacens Fluxus II (10-12-12dB). Equipado a su vez con un cableado negro de alta calidad, que aumenta la protección y mejora la apariencia de este ventilador", "TechnoProductEntity", "Dimensiones del producto : 35 x 3 x 15,01 cm; 98,5 g\nFabricante : ‎Tacens Spain\nDescripción de la batería: 12VDC\n", -10, "Ventilador ordenador", 7m },
                    { 15, 0, "hecho de telas de felpa de alta calidad. Relleno de plumas de algodón PP en este peluche de pingüino totalmente vestido. El interior de alta calidad es realmente cómodo de sostener y soporta cualquier posición del cuerpo descansada a su alrededor.", "TechnoProductEntity", "Dimensiones del producto : ‎6 x 5 x 12 cm; 140 g\nMaterial : ‎Nailon\nMarca: Generic\n", 41, "Peluche pingüino", 12m }
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
