using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TurnoApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "fecha_cancelacion",
                table: "T_TURNOS",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "motivo_cancelacion",
                table: "T_TURNOS",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fecha_cancelacion",
                table: "T_TURNOS");

            migrationBuilder.DropColumn(
                name: "motivo_cancelacion",
                table: "T_TURNOS");
        }
    }
}
