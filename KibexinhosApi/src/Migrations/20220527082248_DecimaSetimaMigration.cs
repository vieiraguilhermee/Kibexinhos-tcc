using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kibexinhos.Migrations
{
    public partial class DecimaSetimaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                table: "Pedido");

            migrationBuilder.AddColumn<double>(
                name: "Total",
                table: "Pedido",
                type: "float",
                nullable: true,
                computedColumnSql: "[dbo].[Total]([Id])");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                table: "Pedido");

            migrationBuilder.Sql(@"ALTER TABLE [dbo].[Pedido]
                                   ADD [Total] as ([dbo].[Total]([Id]))");
        }
    }
}
