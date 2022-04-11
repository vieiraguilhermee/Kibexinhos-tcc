using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kibexinhos.Migrations
{
    public partial class TerceiraMigracao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PetId",
                table: "Produto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Pet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoAnimal = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pet", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produto_PetId",
                table: "Produto",
                column: "PetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Pet_PetId",
                table: "Produto",
                column: "PetId",
                principalTable: "Pet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Pet_PetId",
                table: "Produto");

            migrationBuilder.DropTable(
                name: "Pet");

            migrationBuilder.DropIndex(
                name: "IX_Produto_PetId",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "PetId",
                table: "Produto");
        }
    }
}
