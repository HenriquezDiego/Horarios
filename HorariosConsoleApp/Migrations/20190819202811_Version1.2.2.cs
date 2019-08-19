using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HorariosConsoleApp.Migrations
{
    public partial class Version122 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Porcentaje",
                table: "DetallePagoEmpleados",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaInicio",
                table: "CambioHorarios",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Porcentaje",
                table: "DetallePagoEmpleados",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaInicio",
                table: "CambioHorarios",
                nullable: true,
                oldClrType: typeof(DateTime));
        }
    }
}
