using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HorariosConsoleApp.Migrations
{
    public partial class Version114 : Migration
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
                    Abreviatura = table.Column<string>(nullable: true)
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
                    Alias = table.Column<string>(nullable: true),
                    Abreviatura = table.Column<string>(nullable: true),
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
                    PorcentajeExtra = table.Column<decimal>(nullable: false)
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmpleadosEquipos_Equipos_EquipoId",
                        column: x => x.EquipoId,
                        principalTable: "Equipos",
                        principalColumn: "EquipoId",
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EquipoHorarios_Horarios_HorarioId",
                        column: x => x.HorarioId,
                        principalTable: "Horarios",
                        principalColumn: "HorarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HorarioFraccion",
                columns: table => new
                {
                    HorarioFraccionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DiaId = table.Column<int>(nullable: false),
                    HoraInicio = table.Column<TimeSpan>(nullable: false),
                    HoraFin = table.Column<TimeSpan>(nullable: false),
                    HorarioId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorarioFraccion", x => x.HorarioFraccionId);
                    table.ForeignKey(
                        name: "FK_HorarioFraccion_Dias_DiaId",
                        column: x => x.DiaId,
                        principalTable: "Dias",
                        principalColumn: "DiaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HorarioFraccion_Horarios_HorarioId",
                        column: x => x.HorarioId,
                        principalTable: "Horarios",
                        principalColumn: "HorarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HoraDetalles",
                columns: table => new
                {
                    HoraDetalleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HorarioFraccionId = table.Column<int>(nullable: false),
                    Hora = table.Column<TimeSpan>(nullable: false),
                    TipoHoraId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoraDetalles", x => x.HoraDetalleId);
                    table.ForeignKey(
                        name: "FK_HoraDetalles_HorarioFraccion_HorarioFraccionId",
                        column: x => x.HorarioFraccionId,
                        principalTable: "HorarioFraccion",
                        principalColumn: "HorarioFraccionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HoraDetalles_TipoHoras_TipoHoraId",
                        column: x => x.TipoHoraId,
                        principalTable: "TipoHoras",
                        principalColumn: "TipoHoraId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Dias",
                columns: new[] { "DiaId", "Abreviatura", "Nombre" },
                values: new object[,]
                {
                    { 1, "L", "Lunes" },
                    { 2, "M", "Martes" },
                    { 3, "X", "Miércoles" },
                    { 4, "J", "Jueves" },
                    { 5, "V", "Viernes" },
                    { 6, "S", "Sábado" },
                    { 7, "D", "Domingo" }
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

            migrationBuilder.InsertData(
                table: "Equipos",
                columns: new[] { "EquipoId", "Nombre" },
                values: new object[,]
                {
                    { 3, "Ranger" },
                    { 1, "Zebra" },
                    { 2, "Bravo" }
                });

            migrationBuilder.InsertData(
                table: "TipoHoras",
                columns: new[] { "TipoHoraId", "Nombre", "PorcentajeExtra" },
                values: new object[,]
                {
                    { 9, "Hora Extra Diurna Domingo", 300m },
                    { 1, "Hora Ordinaria Diura", 0m },
                    { 2, "Hora Ordinaria Nocturna", 25m },
                    { 3, "Hora Extra Diura", 200m },
                    { 4, "Hora Extra Nocturna", 250m },
                    { 5, "Hora Ordinaria Diurna Sabado", 0m },
                    { 6, "Hora Ordinaria Nocturna Sabado", 25m },
                    { 7, "Hora Ordinaria Diurna Domingo", 150m },
                    { 8, "Hora Ordinaria Nocturna Domingo", 175m },
                    { 10, "Hora Extra Nocturna Domingo", 350m }
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
                name: "IX_HoraDetalles_HorarioFraccionId",
                table: "HoraDetalles",
                column: "HorarioFraccionId");

            migrationBuilder.CreateIndex(
                name: "IX_HoraDetalles_TipoHoraId",
                table: "HoraDetalles",
                column: "TipoHoraId");

            migrationBuilder.CreateIndex(
                name: "IX_HorarioFraccion_DiaId",
                table: "HorarioFraccion",
                column: "DiaId");

            migrationBuilder.CreateIndex(
                name: "IX_HorarioFraccion_HorarioId",
                table: "HorarioFraccion",
                column: "HorarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpleadosEquipos");

            migrationBuilder.DropTable(
                name: "EquipoHorarios");

            migrationBuilder.DropTable(
                name: "HoraDetalles");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Equipos");

            migrationBuilder.DropTable(
                name: "HorarioFraccion");

            migrationBuilder.DropTable(
                name: "TipoHoras");

            migrationBuilder.DropTable(
                name: "Dias");

            migrationBuilder.DropTable(
                name: "Horarios");
        }
    }
}
