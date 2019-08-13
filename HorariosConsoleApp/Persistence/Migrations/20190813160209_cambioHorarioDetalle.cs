using Microsoft.EntityFrameworkCore.Migrations;

namespace HorariosConsoleApp.Migrations
{
    public partial class cambioHorarioDetalle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HoraId",
                table: "HorarioDetalles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_HorarioDetalles_HoraId",
                table: "HorarioDetalles",
                column: "HoraId");

            migrationBuilder.AddForeignKey(
                name: "FK_HorarioDetalles_Horas_HoraId",
                table: "HorarioDetalles",
                column: "HoraId",
                principalTable: "Horas",
                principalColumn: "HoraId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HorarioDetalles_Horas_HoraId",
                table: "HorarioDetalles");

            migrationBuilder.DropIndex(
                name: "IX_HorarioDetalles_HoraId",
                table: "HorarioDetalles");

            migrationBuilder.DropColumn(
                name: "HoraId",
                table: "HorarioDetalles");
        }
    }
}
