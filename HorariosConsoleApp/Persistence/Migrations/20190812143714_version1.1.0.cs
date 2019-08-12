using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HorariosConsoleApp.Migrations
{
    public partial class version110 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Porcentaje",
                table: "TipoHoras",
                newName: "PorcentajeExtra");

            migrationBuilder.RenameColumn(
                name: "Remuneracion",
                table: "Dias",
                newName: "PorcentajeExtra");

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
                    { 1, "Zebra" },
                    { 2, "Bravo" },
                    { 3, "Ranger" }
                });

            migrationBuilder.InsertData(
                table: "Horas",
                columns: new[] { "HoraId", "Horaspan" },
                values: new object[,]
                {
                    { 15, new TimeSpan(0, 14, 0, 0, 0) },
                    { 16, new TimeSpan(0, 15, 0, 0, 0) },
                    { 17, new TimeSpan(0, 16, 0, 0, 0) },
                    { 18, new TimeSpan(0, 17, 0, 0, 0) },
                    { 22, new TimeSpan(0, 21, 0, 0, 0) },
                    { 20, new TimeSpan(0, 19, 0, 0, 0) },
                    { 21, new TimeSpan(0, 20, 0, 0, 0) },
                    { 14, new TimeSpan(0, 13, 0, 0, 0) },
                    { 23, new TimeSpan(0, 22, 0, 0, 0) },
                    { 19, new TimeSpan(0, 18, 0, 0, 0) },
                    { 13, new TimeSpan(0, 12, 0, 0, 0) },
                    { 11, new TimeSpan(0, 10, 0, 0, 0) },
                    { 10, new TimeSpan(0, 9, 0, 0, 0) },
                    { 9, new TimeSpan(0, 8, 0, 0, 0) },
                    { 8, new TimeSpan(0, 7, 0, 0, 0) },
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DeleteData(
                table: "Horas",
                keyColumn: "HoraId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Horas",
                keyColumn: "HoraId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Horas",
                keyColumn: "HoraId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Horas",
                keyColumn: "HoraId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Horas",
                keyColumn: "HoraId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Horas",
                keyColumn: "HoraId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Horas",
                keyColumn: "HoraId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Horas",
                keyColumn: "HoraId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Horas",
                keyColumn: "HoraId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Horas",
                keyColumn: "HoraId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Horas",
                keyColumn: "HoraId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Horas",
                keyColumn: "HoraId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Horas",
                keyColumn: "HoraId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Horas",
                keyColumn: "HoraId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Horas",
                keyColumn: "HoraId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Horas",
                keyColumn: "HoraId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Horas",
                keyColumn: "HoraId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Horas",
                keyColumn: "HoraId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Horas",
                keyColumn: "HoraId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Horas",
                keyColumn: "HoraId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Horas",
                keyColumn: "HoraId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Horas",
                keyColumn: "HoraId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Horas",
                keyColumn: "HoraId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "TipoHoras",
                keyColumn: "TipoHoraId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TipoHoras",
                keyColumn: "TipoHoraId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TipoHoras",
                keyColumn: "TipoHoraId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TipoHoras",
                keyColumn: "TipoHoraId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TipoHoras",
                keyColumn: "TipoHoraId",
                keyValue: 5);

            migrationBuilder.RenameColumn(
                name: "PorcentajeExtra",
                table: "TipoHoras",
                newName: "Porcentaje");

            migrationBuilder.RenameColumn(
                name: "PorcentajeExtra",
                table: "Dias",
                newName: "Remuneracion");
        }
    }
}
