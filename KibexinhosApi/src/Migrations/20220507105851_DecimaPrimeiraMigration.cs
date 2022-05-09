using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kibexinhos.Migrations
{
    public partial class DecimaPrimeiraMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Total",
                table: "Pedido",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                table: "Pedido");
        }
    }
}
