using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class UnvanBaglantisi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BirimID",
                table: "AspNetUsers",
                column: "BirimID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UnvanID",
                table: "AspNetUsers",
                column: "UnvanID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Departmanlar_BirimID",
                table: "AspNetUsers",
                column: "BirimID",
                principalTable: "Departmanlar",
                principalColumn: "DepartmanID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Unvanlar_UnvanID",
                table: "AspNetUsers",
                column: "UnvanID",
                principalTable: "Unvanlar",
                principalColumn: "UnvanID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Departmanlar_BirimID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Unvanlar_UnvanID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_BirimID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UnvanID",
                table: "AspNetUsers");
        }
    }
}
