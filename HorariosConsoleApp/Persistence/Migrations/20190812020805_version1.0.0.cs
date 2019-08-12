using Microsoft.EntityFrameworkCore.Migrations;

namespace HorariosConsoleApp.Migrations
{
    public partial class version100 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "FK_Horas_TipoHoras_TipoHoraId",
                table: "Horas");

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
                name: "TipoHoraId",
                table: "Horas");

            migrationBuilder.DropColumn(
                name: "HoraFinId",
                table: "HorarioDetalles");

            migrationBuilder.DropColumn(
                name: "HoraInicioId",
                table: "HorarioDetalles");

            migrationBuilder.RenameColumn(
                name: "Remuneracion",
                table: "TipoHoras",
                newName: "Porcentaje");

            migrationBuilder.RenameColumn(
                name: "HoraLSpan",
                table: "Horas",
                newName: "Horaspan");

            migrationBuilder.RenameColumn(
                name: "DiaId",
                table: "HorarioDetalles",
                newName: "TipoHoraId");

            migrationBuilder.RenameIndex(
                name: "IX_HorarioDetalles_DiaId",
                table: "HorarioDetalles",
                newName: "IX_HorarioDetalles_TipoHoraId");

            migrationBuilder.AddColumn<int>(
                name: "DiaId",
                table: "Horarios",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HoraFinId",
                table: "Horarios",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HoraInicioId",
                table: "Horarios",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HoraId",
                table: "HorarioDetalles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Horarios_DiaId",
                table: "Horarios",
                column: "DiaId");

            migrationBuilder.CreateIndex(
                name: "IX_Horarios_HoraFinId",
                table: "Horarios",
                column: "HoraFinId");

            migrationBuilder.CreateIndex(
                name: "IX_Horarios_HoraInicioId",
                table: "Horarios",
                column: "HoraInicioId");

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
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HorarioDetalles_TipoHoras_TipoHoraId",
                table: "HorarioDetalles",
                column: "TipoHoraId",
                principalTable: "TipoHoras",
                principalColumn: "TipoHoraId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Horarios_Dias_DiaId",
                table: "Horarios",
                column: "DiaId",
                principalTable: "Dias",
                principalColumn: "DiaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Horarios_Horas_HoraFinId",
                table: "Horarios",
                column: "HoraFinId",
                principalTable: "Horas",
                principalColumn: "HoraId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Horarios_Horas_HoraInicioId",
                table: "Horarios",
                column: "HoraInicioId",
                principalTable: "Horas",
                principalColumn: "HoraId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HorarioDetalles_Horas_HoraId",
                table: "HorarioDetalles");

            migrationBuilder.DropForeignKey(
                name: "FK_HorarioDetalles_TipoHoras_TipoHoraId",
                table: "HorarioDetalles");

            migrationBuilder.DropForeignKey(
                name: "FK_Horarios_Dias_DiaId",
                table: "Horarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Horarios_Horas_HoraFinId",
                table: "Horarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Horarios_Horas_HoraInicioId",
                table: "Horarios");

            migrationBuilder.DropIndex(
                name: "IX_Horarios_DiaId",
                table: "Horarios");

            migrationBuilder.DropIndex(
                name: "IX_Horarios_HoraFinId",
                table: "Horarios");

            migrationBuilder.DropIndex(
                name: "IX_Horarios_HoraInicioId",
                table: "Horarios");

            migrationBuilder.DropIndex(
                name: "IX_HorarioDetalles_HoraId",
                table: "HorarioDetalles");

            migrationBuilder.DropColumn(
                name: "DiaId",
                table: "Horarios");

            migrationBuilder.DropColumn(
                name: "HoraFinId",
                table: "Horarios");

            migrationBuilder.DropColumn(
                name: "HoraInicioId",
                table: "Horarios");

            migrationBuilder.DropColumn(
                name: "HoraId",
                table: "HorarioDetalles");

            migrationBuilder.RenameColumn(
                name: "Porcentaje",
                table: "TipoHoras",
                newName: "Remuneracion");

            migrationBuilder.RenameColumn(
                name: "Horaspan",
                table: "Horas",
                newName: "HoraLSpan");

            migrationBuilder.RenameColumn(
                name: "TipoHoraId",
                table: "HorarioDetalles",
                newName: "DiaId");

            migrationBuilder.RenameIndex(
                name: "IX_HorarioDetalles_TipoHoraId",
                table: "HorarioDetalles",
                newName: "IX_HorarioDetalles_DiaId");

            migrationBuilder.AddColumn<int>(
                name: "TipoHoraId",
                table: "Horas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HoraFinId",
                table: "HorarioDetalles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HoraInicioId",
                table: "HorarioDetalles",
                nullable: true);

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
                name: "FK_Horas_TipoHoras_TipoHoraId",
                table: "Horas",
                column: "TipoHoraId",
                principalTable: "TipoHoras",
                principalColumn: "TipoHoraId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
