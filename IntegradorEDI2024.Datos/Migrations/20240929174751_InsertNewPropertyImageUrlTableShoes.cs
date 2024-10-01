using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntegradorEDI2024.Datos.Migrations
{
    /// <inheritdoc />
    public partial class InsertNewPropertyImageUrlTableShoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Shoes",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Shoes");
        }
    }
}
