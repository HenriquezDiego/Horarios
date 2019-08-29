using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HorariosConsoleApp.Migrations
{
    public partial class Version201 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Asuetos",
                columns: table => new
                {
                    AsuetoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asuetos", x => x.AsuetoId);
                });

            migrationBuilder.InsertData(
                table: "Asuetos",
                columns: new[] { "AsuetoId", "Descripcion", "Fecha" },
                values: new object[,]
                {
                    { 1, "Primero de enero", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Dos de enero", new DateTime(2019, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Dia del trabajo", new DateTime(2019, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Dia de la Madre", new DateTime(2019, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Fiesta patronal Santa Ana", new DateTime(2019, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "Fiesta titular nacional", new DateTime(2019, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "Fiesta titular nacional", new DateTime(2019, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "Dia de la independencia", new DateTime(2019, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "Dia de los fieles difuntos", new DateTime(2019, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "Noche buena", new DateTime(2019, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, "Navidad", new DateTime(2019, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, "Fin de año", new DateTime(2019, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asuetos");
        }
    }
}
