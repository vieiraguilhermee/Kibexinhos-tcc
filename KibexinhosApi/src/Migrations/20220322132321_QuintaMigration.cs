using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kibexinhos.Migrations
{
    public partial class QuintaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NomeProdutos",
                table: "Produto",
                newName: "NomeProduto");

            migrationBuilder.AlterColumn<int>(
                name: "Avaliacao",
                table: "AvaliacaoProduto",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NomeProduto",
                table: "Produto",
                newName: "NomeProdutos");

            migrationBuilder.AlterColumn<float>(
                name: "Avaliacao",
                table: "AvaliacaoProduto",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
