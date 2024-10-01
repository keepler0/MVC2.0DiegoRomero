using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IntegradorEDI2024.Datos.Migrations
{
    /// <inheritdoc />
    public partial class AddingShoesListRecords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Shoes",
                columns: new[] { "ShoeId", "BrandId", "ColorId", "Description", "GenreId", "Model", "Price", "SportId" },
                values: new object[,]
                {
                    { 1, 1, 1, "Zapatillas running de tela ultra lijero", 1, "Capitan", 22999.99m, 1 },
                    { 2, 2, 2, "Botas de trekking suela reforzada", 2, "Mamooth", 48999.99m, 2 },
                    { 3, 5, 1, "Botines de football ultra liviano", 1, "Mercurial Vapor", 130789.65m, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Shoes",
                keyColumn: "ShoeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Shoes",
                keyColumn: "ShoeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Shoes",
                keyColumn: "ShoeId",
                keyValue: 3);
        }
    }
}
