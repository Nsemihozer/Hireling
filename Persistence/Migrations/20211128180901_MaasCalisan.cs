using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class MaasCalisan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Calisanlars",
                table: "Calisanlars");

            migrationBuilder.RenameTable(
                name: "Calisanlars",
                newName: "Calisanlar");

            migrationBuilder.AddColumn<decimal>(
                name: "BrutMaas",
                table: "Calisanlar",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "IzinGun",
                table: "Calisanlar",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "IzinSaat",
                table: "Calisanlar",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "KullanilanIzinGun",
                table: "Calisanlar",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "KullanilanIzinSaat",
                table: "Calisanlar",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "NetMaas",
                table: "Calisanlar",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Calisanlar",
                table: "Calisanlar",
                column: "CalisanID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Calisanlar",
                table: "Calisanlar");

            migrationBuilder.DropColumn(
                name: "BrutMaas",
                table: "Calisanlar");

            migrationBuilder.DropColumn(
                name: "IzinGun",
                table: "Calisanlar");

            migrationBuilder.DropColumn(
                name: "IzinSaat",
                table: "Calisanlar");

            migrationBuilder.DropColumn(
                name: "KullanilanIzinGun",
                table: "Calisanlar");

            migrationBuilder.DropColumn(
                name: "KullanilanIzinSaat",
                table: "Calisanlar");

            migrationBuilder.DropColumn(
                name: "NetMaas",
                table: "Calisanlar");

            migrationBuilder.RenameTable(
                name: "Calisanlar",
                newName: "Calisanlars");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Calisanlars",
                table: "Calisanlars",
                column: "CalisanID");
        }
    }
}
