using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudioManager.Infra.Migrations
{
    public partial class M231207_2115 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataCancelamento",
                schema: "reservas",
                table: "Reservas",
                newName: "CanceladaEm");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CanceladaEm",
                schema: "reservas",
                table: "Reservas",
                newName: "DataCancelamento");
        }
    }
}
