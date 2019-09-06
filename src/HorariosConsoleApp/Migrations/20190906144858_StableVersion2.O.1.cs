using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HorariosConsoleApp.Migrations
{
    public partial class StableVersion2O1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HoraDetalles");

            migrationBuilder.CreateTable(
                name: "HorarioFragmentoDetalle",
                columns: table => new
                {
                    HorarioFragmentoDetalleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HorarioFragmentoId = table.Column<int>(nullable: false),
                    Hora = table.Column<TimeSpan>(nullable: false),
                    TipoHoraId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorarioFragmentoDetalle", x => x.HorarioFragmentoDetalleId);
                    table.ForeignKey(
                        name: "FK_HorarioFragmentoDetalle_HorariosFragmentos_HorarioFragmentoId",
                        column: x => x.HorarioFragmentoId,
                        principalTable: "HorariosFragmentos",
                        principalColumn: "HorarioFragmentoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HorarioFragmentoDetalle_TipoHoras_TipoHoraId",
                        column: x => x.TipoHoraId,
                        principalTable: "TipoHoras",
                        principalColumn: "TipoHoraId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HorarioFragmentoDetalle_HorarioFragmentoId",
                table: "HorarioFragmentoDetalle",
                column: "HorarioFragmentoId");

            migrationBuilder.CreateIndex(
                name: "IX_HorarioFragmentoDetalle_TipoHoraId",
                table: "HorarioFragmentoDetalle",
                column: "TipoHoraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HorarioFragmentoDetalle");

            migrationBuilder.CreateTable(
                name: "HoraDetalles",
                columns: table => new
                {
                    HoraDetalleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Hora = table.Column<TimeSpan>(nullable: false),
                    HorarioFragmentoId = table.Column<int>(nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_HoraDetalles_HorarioFragmentoId",
                table: "HoraDetalles",
                column: "HorarioFragmentoId");

            migrationBuilder.CreateIndex(
                name: "IX_HoraDetalles_TipoHoraId",
                table: "HoraDetalles",
                column: "TipoHoraId");
        }
    }
}
