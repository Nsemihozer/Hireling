using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class CalisanTabloGuncelleme2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calisanlar_Departmanlar_BirimID",
                table: "Calisanlar");

            migrationBuilder.DropForeignKey(
                name: "FK_Calisanlar_Unvanlar_UnvanID",
                table: "Calisanlar");

            migrationBuilder.DropForeignKey(
                name: "FK_Departmanlar_Calisanlar_SorumluID",
                table: "Departmanlar");

            migrationBuilder.DropIndex(
                name: "IX_Departmanlar_SorumluID",
                table: "Departmanlar");

            migrationBuilder.DropIndex(
                name: "IX_Calisanlar_BirimID",
                table: "Calisanlar");

            migrationBuilder.DropIndex(
                name: "IX_Calisanlar_UnvanID",
                table: "Calisanlar");

            migrationBuilder.RenameColumn(
                name: "SorumluID",
                table: "Departmanlar",
                newName: "SorumluId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SorumluId",
                table: "Departmanlar",
                newName: "SorumluID");

            migrationBuilder.CreateIndex(
                name: "IX_Departmanlar_SorumluID",
                table: "Departmanlar",
                column: "SorumluID");

            migrationBuilder.CreateIndex(
                name: "IX_Calisanlar_BirimID",
                table: "Calisanlar",
                column: "BirimID");

            migrationBuilder.CreateIndex(
                name: "IX_Calisanlar_UnvanID",
                table: "Calisanlar",
                column: "UnvanID");

            migrationBuilder.AddForeignKey(
                name: "FK_Calisanlar_Departmanlar_BirimID",
                table: "Calisanlar",
                column: "BirimID",
                principalTable: "Departmanlar",
                principalColumn: "DepartmanID");

            migrationBuilder.AddForeignKey(
                name: "FK_Calisanlar_Unvanlar_UnvanID",
                table: "Calisanlar",
                column: "UnvanID",
                principalTable: "Unvanlar",
                principalColumn: "UnvanID");

            migrationBuilder.AddForeignKey(
                name: "FK_Departmanlar_Calisanlar_SorumluID",
                table: "Departmanlar",
                column: "SorumluID",
                principalTable: "Calisanlar",
                principalColumn: "CalisanID");
        }
    }
}
