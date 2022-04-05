using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kibexinhos.Migrations
{
    public partial class SextaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Altura",
                table: "Produto",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Comprimento",
                table: "Produto",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "InformacaoNutricional",
                table: "Produto",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Largura",
                table: "Produto",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Peso",
                table: "Produto",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Altura",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "Comprimento",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "InformacaoNutricional",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "Largura",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "Peso",
                table: "Produto");
        }
    }
}
