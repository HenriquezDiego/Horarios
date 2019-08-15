using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HorariosConsoleApp.Migrations
{
    public partial class Version119 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "HorasExtraDiurnas",
                table: "CambioHorarios",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "HorasExtraDiurnasDomingo",
                table: "CambioHorarios",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "HorasExtraNocturnas",
                table: "CambioHorarios",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "HorasExtraNocturnasDomingo",
                table: "CambioHorarios",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "HorasOrdinariasDiurnas",
                table: "CambioHorarios",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "HorasOrdinariasNocturnas",
                table: "CambioHorarios",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "HorasOrdinarioasNocturnasDomingo",
                table: "CambioHorarios",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalAsueto",
                table: "CambioHorarios",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalHorasExtraDiurnas",
                table: "CambioHorarios",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalHorasExtraDiurnasDomingo",
                table: "CambioHorarios",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalHorasExtraNocturnas",
                table: "CambioHorarios",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalHorasExtraNocturnasDomingo",
                table: "CambioHorarios",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalHorasOrdinariasDiurnas",
                table: "CambioHorarios",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalHorasOrdinariasNocturnas",
                table: "CambioHorarios",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalHorasOrdinariasNocturnasDomingo",
                table: "CambioHorarios",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalHorasOrinariasDiurnasDomingo",
                table: "CambioHorarios",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "PagoEmpleados",
                columns: table => new
                {
                    PagoEmpleadoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmpleadoId = table.Column<int>(nullable: true),
                    EquipoId = table.Column<int>(nullable: true),
                    SalarioHora = table.Column<decimal>(nullable: false),
                    HorarioId = table.Column<int>(nullable: true),
                    DiaId = table.Column<int>(nullable: false),
                    FechaPago = table.Column<DateTime>(nullable: false),
                    EsAsueto = table.Column<bool>(nullable: false),
                    HorasOrdinariasDiurnas = table.Column<double>(nullable: false),
                    TotalHorasOrdinariasDiurnas = table.Column<double>(nullable: false),
                    HorasOrdinariasNocturnas = table.Column<double>(nullable: false),
                    TotalHorasOrdinariasNocturnas = table.Column<double>(nullable: false),
                    HorasExtraDiurnas = table.Column<double>(nullable: false),
                    TotalHorasExtraDiurnas = table.Column<double>(nullable: false),
                    HorasExtraNocturnas = table.Column<double>(nullable: false),
                    TotalHorasExtraNocturnas = table.Column<double>(nullable: false),
                    HorasOrinariasDiurnasDomingo = table.Column<double>(nullable: false),
                    TotalHorasOrinariasDiurnasDomingo = table.Column<double>(nullable: false),
                    HorasOrdinarioasNocturnasDomingo = table.Column<double>(nullable: false),
                    TotalHorasOrdinariasNocturnasDomingo = table.Column<double>(nullable: false),
                    HorasExtraDiurnasDomingo = table.Column<double>(nullable: false),
                    TotalHorasExtraDiurnasDomingo = table.Column<double>(nullable: false),
                    HorasExtraNocturnasDomingo = table.Column<double>(nullable: false),
                    TotalHorasExtraNocturnasDomingo = table.Column<double>(nullable: false),
                    TotalAsueto = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagoEmpleados", x => x.PagoEmpleadoId);
                    table.ForeignKey(
                        name: "FK_PagoEmpleados_Dias_DiaId",
                        column: x => x.DiaId,
                        principalTable: "Dias",
                        principalColumn: "DiaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PagoEmpleados_Empleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleados",
                        principalColumn: "EmpleadoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PagoEmpleados_Equipos_EquipoId",
                        column: x => x.EquipoId,
                        principalTable: "Equipos",
                        principalColumn: "EquipoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PagoEmpleados_Horarios_HorarioId",
                        column: x => x.HorarioId,
                        principalTable: "Horarios",
                        principalColumn: "HorarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PagoEmpleados_DiaId",
                table: "PagoEmpleados",
                column: "DiaId");

            migrationBuilder.CreateIndex(
                name: "IX_PagoEmpleados_EmpleadoId",
                table: "PagoEmpleados",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_PagoEmpleados_EquipoId",
                table: "PagoEmpleados",
                column: "EquipoId");

            migrationBuilder.CreateIndex(
                name: "IX_PagoEmpleados_HorarioId",
                table: "PagoEmpleados",
                column: "HorarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PagoEmpleados");

            migrationBuilder.DropColumn(
                name: "HorasExtraDiurnas",
                table: "CambioHorarios");

            migrationBuilder.DropColumn(
                name: "HorasExtraDiurnasDomingo",
                table: "CambioHorarios");

            migrationBuilder.DropColumn(
                name: "HorasExtraNocturnas",
                table: "CambioHorarios");

            migrationBuilder.DropColumn(
                name: "HorasExtraNocturnasDomingo",
                table: "CambioHorarios");

            migrationBuilder.DropColumn(
                name: "HorasOrdinariasDiurnas",
                table: "CambioHorarios");

            migrationBuilder.DropColumn(
                name: "HorasOrdinariasNocturnas",
                table: "CambioHorarios");

            migrationBuilder.DropColumn(
                name: "HorasOrdinarioasNocturnasDomingo",
                table: "CambioHorarios");

            migrationBuilder.DropColumn(
                name: "TotalAsueto",
                table: "CambioHorarios");

            migrationBuilder.DropColumn(
                name: "TotalHorasExtraDiurnas",
                table: "CambioHorarios");

            migrationBuilder.DropColumn(
                name: "TotalHorasExtraDiurnasDomingo",
                table: "CambioHorarios");

            migrationBuilder.DropColumn(
                name: "TotalHorasExtraNocturnas",
                table: "CambioHorarios");

            migrationBuilder.DropColumn(
                name: "TotalHorasExtraNocturnasDomingo",
                table: "CambioHorarios");

            migrationBuilder.DropColumn(
                name: "TotalHorasOrdinariasDiurnas",
                table: "CambioHorarios");

            migrationBuilder.DropColumn(
                name: "TotalHorasOrdinariasNocturnas",
                table: "CambioHorarios");

            migrationBuilder.DropColumn(
                name: "TotalHorasOrdinariasNocturnasDomingo",
                table: "CambioHorarios");

            migrationBuilder.DropColumn(
                name: "TotalHorasOrinariasDiurnasDomingo",
                table: "CambioHorarios");
        }
    }
}
