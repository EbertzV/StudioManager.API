using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudioManager.Infra.Migrations
{
    public partial class M231206_0125 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "reservas");

            migrationBuilder.RenameTable(
                name: "Reservas",
                newName: "Reservas",
                newSchema: "reservas");

            migrationBuilder.RenameTable(
                name: "Clientes",
                newName: "Clientes",
                newSchema: "reservas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Reservas",
                schema: "reservas",
                newName: "Reservas");

            migrationBuilder.RenameTable(
                name: "Clientes",
                schema: "reservas",
                newName: "Clientes");
        }
    }
}
