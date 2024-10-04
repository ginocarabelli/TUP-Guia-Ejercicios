using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TurnoApi.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_DETALLES_TURNO",
                columns: table => new
                {
                    id_turno = table.Column<int>(type: "int", nullable: false),
                    id_servicio = table.Column<int>(type: "int", nullable: false),
                    observaciones = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_DETALLES_TURNO", x => new { x.id_turno, x.id_servicio });
                });

            migrationBuilder.CreateTable(
                name: "T_SERVICIOS",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    costo = table.Column<int>(type: "int", nullable: false),
                    enPromocion = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_SERVICIOS", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "T_TURNOS",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    hora = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    cliente = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_TURNOS", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_DETALLES_TURNO");

            migrationBuilder.DropTable(
                name: "T_SERVICIOS");

            migrationBuilder.DropTable(
                name: "T_TURNOS");
        }
    }
}
