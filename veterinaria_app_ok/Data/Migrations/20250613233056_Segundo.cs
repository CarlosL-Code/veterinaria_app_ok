using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace veterinaria_app_ok.Data.Migrations
{
    /// <inheritdoc />
    public partial class Segundo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atencion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    Total = table.Column<int>(type: "int", nullable: false),
                    MascotaId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atencion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atencion_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Atencion_Mascota_MascotaId",
                        column: x => x.MascotaId,
                        principalTable: "Mascota",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AtencionServicio",
                columns: table => new
                {
                    atencionId = table.Column<int>(type: "int", nullable: false),
                    servicioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtencionServicio", x => new { x.atencionId, x.servicioId });
                    table.ForeignKey(
                        name: "FK_AtencionServicio_Atencion_atencionId",
                        column: x => x.atencionId,
                        principalTable: "Atencion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AtencionServicio_Servicio_servicioId",
                        column: x => x.servicioId,
                        principalTable: "Servicio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atencion_MascotaId",
                table: "Atencion",
                column: "MascotaId");

            migrationBuilder.CreateIndex(
                name: "IX_Atencion_UsuarioId",
                table: "Atencion",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_AtencionServicio_servicioId",
                table: "AtencionServicio",
                column: "servicioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtencionServicio");

            migrationBuilder.DropTable(
                name: "Atencion");
        }
    }
}
