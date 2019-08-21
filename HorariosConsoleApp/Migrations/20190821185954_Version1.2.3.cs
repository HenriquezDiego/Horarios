using Microsoft.EntityFrameworkCore.Migrations;

namespace HorariosConsoleApp.Migrations
{
    public partial class Version123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HorasEfectivas",
                table: "Horarios");

            migrationBuilder.RenameColumn(
                name: "SalarioHora",
                table: "PagoEmpleados",
                newName: "SalarioBase");

            migrationBuilder.AddColumn<bool>(
                name: "EsNocturna",
                table: "TipoHoras",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "TipoHoras",
                keyColumn: "TipoHoraId",
                keyValue: 2,
                column: "EsNocturna",
                value: true);

            migrationBuilder.UpdateData(
                table: "TipoHoras",
                keyColumn: "TipoHoraId",
                keyValue: 4,
                column: "EsNocturna",
                value: true);

            migrationBuilder.UpdateData(
                table: "TipoHoras",
                keyColumn: "TipoHoraId",
                keyValue: 6,
                column: "EsNocturna",
                value: true);

            migrationBuilder.UpdateData(
                table: "TipoHoras",
                keyColumn: "TipoHoraId",
                keyValue: 8,
                column: "EsNocturna",
                value: true);

            migrationBuilder.UpdateData(
                table: "TipoHoras",
                keyColumn: "TipoHoraId",
                keyValue: 10,
                column: "EsNocturna",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EsNocturna",
                table: "TipoHoras");

            migrationBuilder.RenameColumn(
                name: "SalarioBase",
                table: "PagoEmpleados",
                newName: "SalarioHora");

            migrationBuilder.AddColumn<decimal>(
                name: "HorasEfectivas",
                table: "Horarios",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
