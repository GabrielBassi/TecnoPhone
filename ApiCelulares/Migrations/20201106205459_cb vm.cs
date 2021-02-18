using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiCelulares.Migrations
{
    public partial class cbvm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "costoRepuesto",
                table: "OrdenDeReparacions",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "presupuesto",
                table: "OrdenDeReparacions",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "proveedor",
                table: "OrdenDeReparacions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "seña",
                table: "OrdenDeReparacions",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "costoRepuesto",
                table: "OrdenDeReparacions");

            migrationBuilder.DropColumn(
                name: "presupuesto",
                table: "OrdenDeReparacions");

            migrationBuilder.DropColumn(
                name: "proveedor",
                table: "OrdenDeReparacions");

            migrationBuilder.DropColumn(
                name: "seña",
                table: "OrdenDeReparacions");
        }
    }
}
