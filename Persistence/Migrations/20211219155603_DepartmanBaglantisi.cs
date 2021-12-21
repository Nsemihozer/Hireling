using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class DepartmanBaglantisi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SorumluId",
                table: "Departmanlar",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departmanlar_SorumluId",
                table: "Departmanlar",
                column: "SorumluId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departmanlar_AspNetUsers_SorumluId",
                table: "Departmanlar",
                column: "SorumluId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departmanlar_AspNetUsers_SorumluId",
                table: "Departmanlar");

            migrationBuilder.DropIndex(
                name: "IX_Departmanlar_SorumluId",
                table: "Departmanlar");

            migrationBuilder.AlterColumn<int>(
                name: "SorumluId",
                table: "Departmanlar",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
