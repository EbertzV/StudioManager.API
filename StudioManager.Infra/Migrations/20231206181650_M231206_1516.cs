using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudioManager.Infra.Migrations
{
    public partial class M231206_1516 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataReserva",
                schema: "reservas",
                table: "Reservas",
                newName: "CriadaEm");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CriadaEm",
                schema: "reservas",
                table: "Reservas",
                newName: "DataReserva");
        }
    }
}
