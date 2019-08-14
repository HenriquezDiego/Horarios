using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HorariosConsoleApp.Migrations
{
    public partial class Version117 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpleadosEquipos");

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

            migrationBuilder.DeleteData(
                table: "Empleados",
                keyColumn: "EmpleadoId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Empleados",
                keyColumn: "EmpleadoId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Empleados",
                keyColumn: "EmpleadoId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Empleados",
                keyColumn: "EmpleadoId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Equipos",
                keyColumn: "EquipoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Equipos",
                keyColumn: "EquipoId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Equipos",
                keyColumn: "EquipoId",
                keyValue: 3);

            migrationBuilder.AddColumn<int>(
                name: "EquipoId",
                table: "Empleados",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_EquipoId",
                table: "Empleados",
                column: "EquipoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Equipos_EquipoId",
                table: "Empleados",
                column: "EquipoId",
                principalTable: "Equipos",
                principalColumn: "EquipoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Equipos_EquipoId",
                table: "Empleados");

            migrationBuilder.DropIndex(
                name: "IX_Empleados_EquipoId",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "EquipoId",
                table: "Empleados");

            migrationBuilder.CreateTable(
                name: "EmpleadosEquipos",
                columns: table => new
                {
                    EmpleadoEquipoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmpleadoId = table.Column<int>(nullable: false),
                    EquipoId = table.Column<int>(nullable: false)
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

            migrationBuilder.InsertData(
                table: "Empleados",
                columns: new[] { "EmpleadoId", "Apellido", "Nombre", "SalarioBase" },
                values: new object[,]
                {
                    { 1, "Perez", "Juan", 100m },
                    { 2, "Mitnick", "Kevin", 100m },
                    { 3, "Quezada", "Jose", 700m },
                    { 4, "Rulfo", "Juan", 700m },
                    { 5, "García", "Francisco", 100m },
                    { 6, "Hernandez", "Tito", 700m },
                    { 7, "Rendon", "Pedro", 700m },
                    { 8, "Gonzales", "Elmer", 700m }
                });

            migrationBuilder.InsertData(
                table: "Equipos",
                columns: new[] { "EquipoId", "HorarioId", "Nombre" },
                values: new object[,]
                {
                    { 1, null, "Bravo" },
                    { 2, null, "Cobra" },
                    { 3, null, "Zebra" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmpleadosEquipos_EmpleadoId",
                table: "EmpleadosEquipos",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpleadosEquipos_EquipoId",
                table: "EmpleadosEquipos",
                column: "EquipoId");
        }
    }
}
