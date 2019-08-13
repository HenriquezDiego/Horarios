using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HorariosConsoleApp.Migrations
{
    public partial class v200 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmpleadosEquipos_Empleados_EmpleadoId",
                table: "EmpleadosEquipos");

            migrationBuilder.DropForeignKey(
                name: "FK_EmpleadosEquipos_Equipos_EquipoId",
                table: "EmpleadosEquipos");

            migrationBuilder.DropForeignKey(
                name: "FK_HorarioDetalles_Dias_DiaId",
                table: "HorarioDetalles");

            migrationBuilder.DropForeignKey(
                name: "FK_HorarioDetalles_Horas_HoraFinId",
                table: "HorarioDetalles");

            migrationBuilder.DropForeignKey(
                name: "FK_HorarioDetalles_Horas_HoraInicioId",
                table: "HorarioDetalles");

            migrationBuilder.DropForeignKey(
                name: "FK_HorarioDetalles_Horarios_HorarioId",
                table: "HorarioDetalles");

            migrationBuilder.DropForeignKey(
                name: "FK_Horas_TipoHoras_TipoHoraId",
                table: "Horas");

            migrationBuilder.DropTable(
                name: "EquipoHorarios");

            migrationBuilder.DropTable(
                name: "TipoHoras");

            migrationBuilder.DropIndex(
                name: "IX_Horas_TipoHoraId",
                table: "Horas");

            migrationBuilder.DropIndex(
                name: "IX_HorarioDetalles_HoraFinId",
                table: "HorarioDetalles");

            migrationBuilder.DropIndex(
                name: "IX_HorarioDetalles_HoraInicioId",
                table: "HorarioDetalles");

            migrationBuilder.DropColumn(
                name: "HoraLSpan",
                table: "Horas");

            migrationBuilder.DropColumn(
                name: "TipoHoraId",
                table: "Horas");

            migrationBuilder.DropColumn(
                name: "HoraFinId",
                table: "HorarioDetalles");

            migrationBuilder.DropColumn(
                name: "HoraInicioId",
                table: "HorarioDetalles");

            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "EmpleadosEquipos");

            migrationBuilder.DropColumn(
                name: "Remuneracion",
                table: "Dias");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Equipos",
                newName: "Descripcion");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Dias",
                newName: "Descripcion");

            migrationBuilder.AddColumn<string>(
                name: "Abreviatura",
                table: "Horas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Horas",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PorcetajeExtra",
                table: "Horas",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<int>(
                name: "HorarioId",
                table: "HorarioDetalles",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<decimal>(
                name: "Cantidad",
                table: "HorarioDetalles",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "HorarioId",
                table: "Equipos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "LogCambios",
                columns: table => new
                {
                    LogCambiosId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmpleadoId = table.Column<int>(nullable: false),
                    EquipoId = table.Column<int>(nullable: false),
                    HorarioId = table.Column<int>(nullable: true),
                    FechaInicio = table.Column<DateTime>(nullable: false),
                    FechaFin = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogCambios", x => x.LogCambiosId);
                    table.ForeignKey(
                        name: "FK_LogCambios_Empleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleados",
                        principalColumn: "EmpleadoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LogCambios_Equipos_EquipoId",
                        column: x => x.EquipoId,
                        principalTable: "Equipos",
                        principalColumn: "EquipoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LogCambios_Horarios_HorarioId",
                        column: x => x.HorarioId,
                        principalTable: "Horarios",
                        principalColumn: "HorarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Empleados",
                columns: new[] { "EmpleadoId", "Apellido", "Nombre" },
                values: new object[,]
                {
                    { 1, "Perez", "Juan" },
                    { 2, "Mitnick", "Kevin" },
                    { 3, "Quezada", "Jose" },
                    { 4, "Rulfo", "Juan" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipos_HorarioId",
                table: "Equipos",
                column: "HorarioId");

            migrationBuilder.CreateIndex(
                name: "IX_LogCambios_EmpleadoId",
                table: "LogCambios",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_LogCambios_EquipoId",
                table: "LogCambios",
                column: "EquipoId");

            migrationBuilder.CreateIndex(
                name: "IX_LogCambios_HorarioId",
                table: "LogCambios",
                column: "HorarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmpleadosEquipos_Empleados_EmpleadoId",
                table: "EmpleadosEquipos",
                column: "EmpleadoId",
                principalTable: "Empleados",
                principalColumn: "EmpleadoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmpleadosEquipos_Equipos_EquipoId",
                table: "EmpleadosEquipos",
                column: "EquipoId",
                principalTable: "Equipos",
                principalColumn: "EquipoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipos_Horarios_HorarioId",
                table: "Equipos",
                column: "HorarioId",
                principalTable: "Horarios",
                principalColumn: "HorarioId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HorarioDetalles_Dias_DiaId",
                table: "HorarioDetalles",
                column: "DiaId",
                principalTable: "Dias",
                principalColumn: "DiaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HorarioDetalles_Horarios_HorarioId",
                table: "HorarioDetalles",
                column: "HorarioId",
                principalTable: "Horarios",
                principalColumn: "HorarioId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmpleadosEquipos_Empleados_EmpleadoId",
                table: "EmpleadosEquipos");

            migrationBuilder.DropForeignKey(
                name: "FK_EmpleadosEquipos_Equipos_EquipoId",
                table: "EmpleadosEquipos");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipos_Horarios_HorarioId",
                table: "Equipos");

            migrationBuilder.DropForeignKey(
                name: "FK_HorarioDetalles_Dias_DiaId",
                table: "HorarioDetalles");

            migrationBuilder.DropForeignKey(
                name: "FK_HorarioDetalles_Horarios_HorarioId",
                table: "HorarioDetalles");

            migrationBuilder.DropTable(
                name: "LogCambios");

            migrationBuilder.DropIndex(
                name: "IX_Equipos_HorarioId",
                table: "Equipos");

            migrationBuilder.DeleteData(
                table: "Empleados",
                keyColumn: "EmpleadoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Empleados",
                keyColumn: "EmpleadoId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Empleados",
                keyColumn: "EmpleadoId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Empleados",
                keyColumn: "EmpleadoId",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Abreviatura",
                table: "Horas");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Horas");

            migrationBuilder.DropColumn(
                name: "PorcetajeExtra",
                table: "Horas");

            migrationBuilder.DropColumn(
                name: "Cantidad",
                table: "HorarioDetalles");

            migrationBuilder.DropColumn(
                name: "HorarioId",
                table: "Equipos");

            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Equipos",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Dias",
                newName: "Nombre");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "HoraLSpan",
                table: "Horas",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<int>(
                name: "TipoHoraId",
                table: "Horas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "HorarioId",
                table: "HorarioDetalles",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HoraFinId",
                table: "HorarioDetalles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HoraInicioId",
                table: "HorarioDetalles",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "EmpleadosEquipos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Remuneracion",
                table: "Dias",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "EquipoHorarios",
                columns: table => new
                {
                    EquipoHorarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EquipoId = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    HorarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipoHorarios", x => x.EquipoHorarioId);
                    table.ForeignKey(
                        name: "FK_EquipoHorarios_Equipos_EquipoId",
                        column: x => x.EquipoId,
                        principalTable: "Equipos",
                        principalColumn: "EquipoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipoHorarios_Horarios_HorarioId",
                        column: x => x.HorarioId,
                        principalTable: "Horarios",
                        principalColumn: "HorarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TipoHoras",
                columns: table => new
                {
                    TipoHoraId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Remuneracion = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoHoras", x => x.TipoHoraId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Horas_TipoHoraId",
                table: "Horas",
                column: "TipoHoraId");

            migrationBuilder.CreateIndex(
                name: "IX_HorarioDetalles_HoraFinId",
                table: "HorarioDetalles",
                column: "HoraFinId");

            migrationBuilder.CreateIndex(
                name: "IX_HorarioDetalles_HoraInicioId",
                table: "HorarioDetalles",
                column: "HoraInicioId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipoHorarios_EquipoId",
                table: "EquipoHorarios",
                column: "EquipoId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipoHorarios_HorarioId",
                table: "EquipoHorarios",
                column: "HorarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmpleadosEquipos_Empleados_EmpleadoId",
                table: "EmpleadosEquipos",
                column: "EmpleadoId",
                principalTable: "Empleados",
                principalColumn: "EmpleadoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmpleadosEquipos_Equipos_EquipoId",
                table: "EmpleadosEquipos",
                column: "EquipoId",
                principalTable: "Equipos",
                principalColumn: "EquipoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HorarioDetalles_Dias_DiaId",
                table: "HorarioDetalles",
                column: "DiaId",
                principalTable: "Dias",
                principalColumn: "DiaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HorarioDetalles_Horas_HoraFinId",
                table: "HorarioDetalles",
                column: "HoraFinId",
                principalTable: "Horas",
                principalColumn: "HoraId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HorarioDetalles_Horas_HoraInicioId",
                table: "HorarioDetalles",
                column: "HoraInicioId",
                principalTable: "Horas",
                principalColumn: "HoraId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HorarioDetalles_Horarios_HorarioId",
                table: "HorarioDetalles",
                column: "HorarioId",
                principalTable: "Horarios",
                principalColumn: "HorarioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Horas_TipoHoras_TipoHoraId",
                table: "Horas",
                column: "TipoHoraId",
                principalTable: "TipoHoras",
                principalColumn: "TipoHoraId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
