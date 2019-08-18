using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HorariosConsoleApp.Migrations
{
    public partial class Version121 : Migration
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
                name: "Equipos",
                columns: table => new
                {
                    EquipoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    HorarioId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipos", x => x.EquipoId);
                    table.ForeignKey(
                        name: "FK_Equipos_Horarios_HorarioId",
                        column: x => x.HorarioId,
                        principalTable: "Horarios",
                        principalColumn: "HorarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HorariosFragmentos",
                columns: table => new
                {
                    HorarioFragmentoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DiaId = table.Column<int>(nullable: false),
                    HoraInicio = table.Column<TimeSpan>(nullable: false),
                    HoraFin = table.Column<TimeSpan>(nullable: false),
                    HorarioId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorariosFragmentos", x => x.HorarioFragmentoId);
                    table.ForeignKey(
                        name: "FK_HorariosFragmentos_Dias_DiaId",
                        column: x => x.DiaId,
                        principalTable: "Dias",
                        principalColumn: "DiaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HorariosFragmentos_Horarios_HorarioId",
                        column: x => x.HorarioId,
                        principalTable: "Horarios",
                        principalColumn: "HorarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    EmpleadoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    SalarioBase = table.Column<decimal>(nullable: false),
                    EquipoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.EmpleadoId);
                    table.ForeignKey(
                        name: "FK_Empleados_Equipos_EquipoId",
                        column: x => x.EquipoId,
                        principalTable: "Equipos",
                        principalColumn: "EquipoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HoraDetalles",
                columns: table => new
                {
                    HoraDetalleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HorarioFragmentoId = table.Column<int>(nullable: false),
                    Hora = table.Column<TimeSpan>(nullable: false),
                    TipoHoraId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoraDetalles", x => x.HoraDetalleId);
                    table.ForeignKey(
                        name: "FK_HoraDetalles_HorariosFragmentos_HorarioFragmentoId",
                        column: x => x.HorarioFragmentoId,
                        principalTable: "HorariosFragmentos",
                        principalColumn: "HorarioFragmentoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HoraDetalles_TipoHoras_TipoHoraId",
                        column: x => x.TipoHoraId,
                        principalTable: "TipoHoras",
                        principalColumn: "TipoHoraId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CambioHorarios",
                columns: table => new
                {
                    CambioHorarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmpleadoId = table.Column<int>(nullable: true),
                    Equipo = table.Column<string>(nullable: true),
                    Horario = table.Column<string>(nullable: true),
                    TotalAsueto = table.Column<double>(nullable: false),
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
                });

            migrationBuilder.CreateTable(
                name: "PagoEmpleados",
                columns: table => new
                {
                    PagoEmpleadoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmpleadoId = table.Column<int>(nullable: true),
                    SalarioHora = table.Column<decimal>(nullable: false),
                    Equipo = table.Column<string>(nullable: true),
                    Horario = table.Column<string>(nullable: true),
                    Dia = table.Column<string>(nullable: true),
                    FechaPago = table.Column<DateTime>(nullable: false),
                    EsAsueto = table.Column<bool>(nullable: false),
                    TotalAsueto = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagoEmpleados", x => x.PagoEmpleadoId);
                    table.ForeignKey(
                        name: "FK_PagoEmpleados_Empleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleados",
                        principalColumn: "EmpleadoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetallePagoEmpleados",
                columns: table => new
                {
                    DetallePagoEmpleadoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CantidadHoras = table.Column<double>(nullable: false),
                    TipoHora = table.Column<string>(nullable: true),
                    Porcentaje = table.Column<double>(nullable: false),
                    PagoEmpleadoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallePagoEmpleados", x => x.DetallePagoEmpleadoId);
                    table.ForeignKey(
                        name: "FK_DetallePagoEmpleados_PagoEmpleados_PagoEmpleadoId",
                        column: x => x.PagoEmpleadoId,
                        principalTable: "PagoEmpleados",
                        principalColumn: "PagoEmpleadoId",
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
                table: "Horarios",
                columns: new[] { "HorarioId", "Abreviatura", "Alias", "Descripcion" },
                values: new object[,]
                {
                    { 2, "II", "Rojo", "Lunes a viernes de 2:00 am a 10:00 pmSabado de 10:00 am a 2:00 am y Domingo 6:00 am 6:00 pm" },
                    { 3, "III", "Negro", "Lunes a viernes de 10:00 pm a 6:00 amSabado de 2:00 pm a 6:00 am y Domingo 6:00 pm 6:00 am" },
                    { 1, "I", "Azul", "Lunes a viernes de 6:00 am a 2:00 pmSabado de 6:00 am a 10:00 am y 6:00 pm 6:00 am" }
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
                name: "IX_CambioHorarios_EmpleadoId",
                table: "CambioHorarios",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallePagoEmpleados_PagoEmpleadoId",
                table: "DetallePagoEmpleados",
                column: "PagoEmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_EquipoId",
                table: "Empleados",
                column: "EquipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipos_HorarioId",
                table: "Equipos",
                column: "HorarioId");

            migrationBuilder.CreateIndex(
                name: "IX_HoraDetalles_HorarioFragmentoId",
                table: "HoraDetalles",
                column: "HorarioFragmentoId");

            migrationBuilder.CreateIndex(
                name: "IX_HoraDetalles_TipoHoraId",
                table: "HoraDetalles",
                column: "TipoHoraId");

            migrationBuilder.CreateIndex(
                name: "IX_HorariosFragmentos_DiaId",
                table: "HorariosFragmentos",
                column: "DiaId");

            migrationBuilder.CreateIndex(
                name: "IX_HorariosFragmentos_HorarioId",
                table: "HorariosFragmentos",
                column: "HorarioId");

            migrationBuilder.CreateIndex(
                name: "IX_PagoEmpleados_EmpleadoId",
                table: "PagoEmpleados",
                column: "EmpleadoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CambioHorarios");

            migrationBuilder.DropTable(
                name: "DetallePagoEmpleados");

            migrationBuilder.DropTable(
                name: "HoraDetalles");

            migrationBuilder.DropTable(
                name: "PagoEmpleados");

            migrationBuilder.DropTable(
                name: "HorariosFragmentos");

            migrationBuilder.DropTable(
                name: "TipoHoras");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Dias");

            migrationBuilder.DropTable(
                name: "Equipos");

            migrationBuilder.DropTable(
                name: "Horarios");
        }
    }
}
