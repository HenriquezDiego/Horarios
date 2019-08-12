using Microsoft.EntityFrameworkCore.Migrations;

namespace HorariosConsoleApp.Migrations
{
    public partial class version112 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Abreviatura",
                table: "Horarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Alias",
                table: "Horarios",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Abreviatura",
                table: "Horarios");

            migrationBuilder.DropColumn(
                name: "Alias",
                table: "Horarios");
        }
    }
}
