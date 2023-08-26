using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LojaRepositorios.Migrations
{
    public partial class CreateProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(150)", maxLength: 150, nullable: false),
                    PrecoUnitario = table.Column<decimal>(type: "DECIMAL(14,2)", precision: 14, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "Nome", "PrecoUnitario" },
                values: new object[] { 1, "TV QLED Samsung 4k 50", 5949.72m });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "Nome", "PrecoUnitario" },
                values: new object[] { 2, "TV OLED LG 4k 50", 5300.10m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
