using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HorariosConsoleApp.Migrations
{
    public partial class version112 : Migration
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
                name: "Horas",
                columns: table => new
                {
                    HoraId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Horaspan = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horas", x => x.HoraId);
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
                    HoraInicioId = table.Column<int>(nullable: true),
                    HoraFinId = table.Column<int>(nullable: true),
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
                        name: "FK_HorarioFraccion_Horas_HoraFinId",
                        column: x => x.HoraFinId,
                        principalTable: "Horas",
                        principalColumn: "HoraId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HorarioFraccion_Horas_HoraInicioId",
                        column: x => x.HoraInicioId,
                        principalTable: "Horas",
                        principalColumn: "HoraId",
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
                    HoraId = table.Column<int>(nullable: false),
                    TipoHoraId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoraDetalles", x => x.HoraDetalleId);
                    table.ForeignKey(
                        name: "FK_HoraDetalles_Horas_HoraId",
                        column: x => x.HoraId,
                        principalTable: "Horas",
                        principalColumn: "HoraId",
                        onDelete: ReferentialAction.Restrict);
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
                    { 2, "Bravo" },
                    { 1, "Zebra" }
                });

            migrationBuilder.InsertData(
                table: "Horas",
                columns: new[] { "HoraId", "Horaspan" },
                values: new object[,]
                {
                    { 24, new TimeSpan(0, 23, 0, 0, 0) },
                    { 23, new TimeSpan(0, 22, 0, 0, 0) },
                    { 22, new TimeSpan(0, 21, 0, 0, 0) },
                    { 21, new TimeSpan(0, 20, 0, 0, 0) },
                    { 20, new TimeSpan(0, 19, 0, 0, 0) },
                    { 19, new TimeSpan(0, 18, 0, 0, 0) },
                    { 18, new TimeSpan(0, 17, 0, 0, 0) },
                    { 17, new TimeSpan(0, 16, 0, 0, 0) },
                    { 16, new TimeSpan(0, 15, 0, 0, 0) },
                    { 15, new TimeSpan(0, 14, 0, 0, 0) },
                    { 14, new TimeSpan(0, 13, 0, 0, 0) },
                    { 13, new TimeSpan(0, 12, 0, 0, 0) },
                    { 8, new TimeSpan(0, 7, 0, 0, 0) },
                    { 11, new TimeSpan(0, 10, 0, 0, 0) },
                    { 10, new TimeSpan(0, 9, 0, 0, 0) },
                    { 9, new TimeSpan(0, 8, 0, 0, 0) },
                    { 7, new TimeSpan(0, 6, 0, 0, 0) },
                    { 6, new TimeSpan(0, 5, 0, 0, 0) },
                    { 5, new TimeSpan(0, 4, 0, 0, 0) },
                    { 4, new TimeSpan(0, 3, 0, 0, 0) },
                    { 3, new TimeSpan(0, 2, 0, 0, 0) },
                    { 2, new TimeSpan(0, 1, 0, 0, 0) },
                    { 1, new TimeSpan(0, 0, 0, 0, 0) },
                    { 12, new TimeSpan(0, 11, 0, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "TipoHoras",
                columns: new[] { "TipoHoraId", "Nombre", "PorcentajeExtra" },
                values: new object[,]
                {
                    { 4, "Domingo Hora Ordinaria Diurna", 300m },
                    { 1, "Hora Extra Ordinaria Diurna", 100m },
                    { 2, "Hora Extra  Nocturna", 125m },
                    { 3, "Hora Ordinaria Nocturana", 25m },
                    { 5, "Hora Ordinaria Diura", 0m }
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
                name: "IX_HoraDetalles_HoraId",
                table: "HoraDetalles",
                column: "HoraId");

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
                name: "IX_HorarioFraccion_HoraFinId",
                table: "HorarioFraccion",
                column: "HoraFinId");

            migrationBuilder.CreateIndex(
                name: "IX_HorarioFraccion_HoraInicioId",
                table: "HorarioFraccion",
                column: "HoraInicioId");

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
                name: "Horas");

            migrationBuilder.DropTable(
                name: "Horarios");
        }
    }
}
