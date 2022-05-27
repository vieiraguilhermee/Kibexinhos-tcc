using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kibexinhos.Migrations
{
    public partial class DecimaSextaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MediaAvaliacao",
                table: "Produto");
            migrationBuilder.Sql(@"ALTER TABLE [dbo].[Produto]
                                   ADD [MediaAvaliacao] as ([dbo].[AvgAvaliacoes]([Id]))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MediaAvaliacao",
                table: "Produto");
            migrationBuilder.AddColumn<double>(
                name: "MediaAvaliacao",
                table: "Produto",
                type: "float",
                nullable: true,
                defaultValue: 0.0);
        }
    }
}
