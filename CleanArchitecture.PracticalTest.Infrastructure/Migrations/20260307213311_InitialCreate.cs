using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.PracticalTest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "rutas",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    origen = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    destino = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    distancia_en_km = table.Column<decimal>(type: "numeric", nullable: false),
                    horas_estimadas = table.Column<decimal>(type: "numeric", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_rutas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "paquetes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    peso = table.Column<decimal>(type: "numeric", nullable: false),
                    longitud = table.Column<decimal>(type: "numeric", nullable: false),
                    ancho = table.Column<decimal>(type: "numeric", nullable: false),
                    altura = table.Column<decimal>(type: "numeric", nullable: false),
                    estatus = table.Column<int>(type: "integer", nullable: false),
                    ruta_id = table.Column<Guid>(type: "uuid", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_paquetes", x => x.id);
                    table.ForeignKey(
                        name: "fk_paquetes_ruta_ruta_id",
                        column: x => x.ruta_id,
                        principalTable: "rutas",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "historial_paquete_estatus",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    estatus = table.Column<int>(type: "integer", nullable: false),
                    fecha_de_cambio_estado = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    motivo = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    paquete_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_historial_paquete_estatus", x => x.id);
                    table.ForeignKey(
                        name: "fk_historial_paquete_estatus_paquete_paquete_id",
                        column: x => x.paquete_id,
                        principalTable: "paquetes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_historial_paquete_estatus_paquete_id",
                table: "historial_paquete_estatus",
                column: "paquete_id");

            migrationBuilder.CreateIndex(
                name: "ix_paquetes_ruta_id",
                table: "paquetes",
                column: "ruta_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "historial_paquete_estatus");

            migrationBuilder.DropTable(
                name: "paquetes");

            migrationBuilder.DropTable(
                name: "rutas");
        }
    }
}
