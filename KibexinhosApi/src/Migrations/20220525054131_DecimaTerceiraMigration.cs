using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kibexinhos.Migrations
{
    public partial class DecimaTerceiraMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Cupom_CupomId",
                table: "Pedido");

            migrationBuilder.AlterColumn<int>(
                name: "CupomId",
                table: "Pedido",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Cupom_CupomId",
                table: "Pedido",
                column: "CupomId",
                principalTable: "Cupom",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Cupom_CupomId",
                table: "Pedido");

            migrationBuilder.AlterColumn<int>(
                name: "CupomId",
                table: "Pedido",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Cupom_CupomId",
                table: "Pedido",
                column: "CupomId",
                principalTable: "Cupom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
