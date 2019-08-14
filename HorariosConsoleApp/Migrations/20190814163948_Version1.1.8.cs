using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HorariosConsoleApp.Migrations
{
    public partial class Version118 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipoHorarios");

            migrationBuilder.CreateTable(
                name: "CambioHorarios",
                columns: table => new
                {
                    CambioHorarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmpleadoId = table.Column<int>(nullable: true),
                    EquipoId = table.Column<int>(nullable: true),
                    HorarioId = table.Column<int>(nullable: true),
                    FechaInicio = table.Column<DateTime>(nullable: false),
                    FechaFin = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CambioHorarios", x => x.CambioHorarioId);
                    table.ForeignKey(
                        name: "FK_CambioHorarios_Empleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleados",
                        principalColumn: "EmpleadoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CambioHorarios_Equipos_EquipoId",
                        column: x => x.EquipoId,
                        principalTable: "Equipos",
                        principalColumn: "EquipoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CambioHorarios_Horarios_HorarioId",
                        column: x => x.HorarioId,
                        principalTable: "Horarios",
                        principalColumn: "HorarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CambioHorarios_EmpleadoId",
                table: "CambioHorarios",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_CambioHorarios_EquipoId",
                table: "CambioHorarios",
                column: "EquipoId");

            migrationBuilder.CreateIndex(
                name: "IX_CambioHorarios_HorarioId",
                table: "CambioHorarios",
                column: "HorarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CambioHorarios");

            migrationBuilder.CreateTable(
                name: "EquipoHorarios",
                columns: table => new
                {
                    EquipoHorarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EquipoId = table.Column<int>(nullable: false),
                    HorarioId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipoHorarios", x => x.EquipoHorarioId);
                    table.ForeignKey(
                        name: "FK_EquipoHorarios_Equipos_EquipoId",
                        column: x => x.EquipoId,
                        principalTable: "Equipos",
                        principalColumn: "EquipoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EquipoHorarios_Horarios_HorarioId",
                        column: x => x.HorarioId,
                        principalTable: "Horarios",
                        principalColumn: "HorarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipoHorarios_EquipoId",
                table: "EquipoHorarios",
                column: "EquipoId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipoHorarios_HorarioId",
                table: "EquipoHorarios",
                column: "HorarioId");
        }
    }
}
