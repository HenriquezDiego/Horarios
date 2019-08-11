using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HorariosConsoleApp.Migrations
{
    public partial class InitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dias",
                columns: table => new
                {
                    DiaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Abreviatura = table.Column<string>(nullable: true),
                    Remuneracion = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dias", x => x.DiaId);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    EmpleadoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.EmpleadoId);
                });

            migrationBuilder.CreateTable(
                name: "Equipos",
                columns: table => new
                {
                    EquipoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipos", x => x.EquipoId);
                });

            migrationBuilder.CreateTable(
                name: "Horarios",
                columns: table => new
                {
                    HorarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horarios", x => x.HorarioId);
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

            migrationBuilder.CreateTable(
                name: "EmpleadosEquipos",
                columns: table => new
                {
                    EmpleadoEquipoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EquipoId = table.Column<int>(nullable: false),
                    EmpleadoId = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpleadosEquipos", x => x.EmpleadoEquipoId);
                    table.ForeignKey(
                        name: "FK_EmpleadosEquipos_Empleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleados",
                        principalColumn: "EmpleadoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpleadosEquipos_Equipos_EquipoId",
                        column: x => x.EquipoId,
                        principalTable: "Equipos",
                        principalColumn: "EquipoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EquipoHorarios",
                columns: table => new
                {
                    EquipoHorarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EquipoId = table.Column<int>(nullable: false),
                    HorarioId = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false)
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
                name: "Horas",
                columns: table => new
                {
                    HoraId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HoraLSpan = table.Column<TimeSpan>(nullable: false),
                    TipoHoraId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horas", x => x.HoraId);
                    table.ForeignKey(
                        name: "FK_Horas_TipoHoras_TipoHoraId",
                        column: x => x.TipoHoraId,
                        principalTable: "TipoHoras",
                        principalColumn: "TipoHoraId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HorarioDetalles",
                columns: table => new
                {
                    HorarioDetalleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DiaId = table.Column<int>(nullable: false),
                    HorarioId = table.Column<int>(nullable: false),
                    HoraInicioId = table.Column<int>(nullable: true),
                    HoraFinId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorarioDetalles", x => x.HorarioDetalleId);
                    table.ForeignKey(
                        name: "FK_HorarioDetalles_Dias_DiaId",
                        column: x => x.DiaId,
                        principalTable: "Dias",
                        principalColumn: "DiaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HorarioDetalles_Horas_HoraFinId",
                        column: x => x.HoraFinId,
                        principalTable: "Horas",
                        principalColumn: "HoraId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HorarioDetalles_Horas_HoraInicioId",
                        column: x => x.HoraInicioId,
                        principalTable: "Horas",
                        principalColumn: "HoraId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HorarioDetalles_Horarios_HorarioId",
                        column: x => x.HorarioId,
                        principalTable: "Horarios",
                        principalColumn: "HorarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmpleadosEquipos_EmpleadoId",
                table: "EmpleadosEquipos",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpleadosEquipos_EquipoId",
                table: "EmpleadosEquipos",
                column: "EquipoId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipoHorarios_EquipoId",
                table: "EquipoHorarios",
                column: "EquipoId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipoHorarios_HorarioId",
                table: "EquipoHorarios",
                column: "HorarioId");

            migrationBuilder.CreateIndex(
                name: "IX_HorarioDetalles_DiaId",
                table: "HorarioDetalles",
                column: "DiaId");

            migrationBuilder.CreateIndex(
                name: "IX_HorarioDetalles_HoraFinId",
                table: "HorarioDetalles",
                column: "HoraFinId");

            migrationBuilder.CreateIndex(
                name: "IX_HorarioDetalles_HoraInicioId",
                table: "HorarioDetalles",
                column: "HoraInicioId");

            migrationBuilder.CreateIndex(
                name: "IX_HorarioDetalles_HorarioId",
                table: "HorarioDetalles",
                column: "HorarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Horas_TipoHoraId",
                table: "Horas",
                column: "TipoHoraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpleadosEquipos");

            migrationBuilder.DropTable(
                name: "EquipoHorarios");

            migrationBuilder.DropTable(
                name: "HorarioDetalles");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Equipos");

            migrationBuilder.DropTable(
                name: "Dias");

            migrationBuilder.DropTable(
                name: "Horas");

            migrationBuilder.DropTable(
                name: "Horarios");

            migrationBuilder.DropTable(
                name: "TipoHoras");
        }
    }
}
