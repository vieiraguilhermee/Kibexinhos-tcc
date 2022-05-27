using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kibexinhos.Migrations
{
    public partial class DecimaQuintaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrecoDescontado",
                table: "Produto");
            migrationBuilder.Sql(@"ALTER TABLE [dbo].[Produto]
                                   ADD [PrecoDescontado] as ([Preco]-([Preco]*[Desconto])/(100))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrecoDescontado",
                table: "Produto");
            migrationBuilder.AddColumn<double>(
                name: "PrecoDescontado",
                table: "Produto",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
