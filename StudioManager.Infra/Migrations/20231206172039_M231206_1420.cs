using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudioManager.Infra.Migrations
{
    public partial class M231206_1420 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativa",
                schema: "reservas",
                table: "Reservas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCancelamento",
                schema: "reservas",
                table: "Reservas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataReserva",
                schema: "reservas",
                table: "Reservas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativa",
                schema: "reservas",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "DataCancelamento",
                schema: "reservas",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "DataReserva",
                schema: "reservas",
                table: "Reservas");
        }
    }
}
