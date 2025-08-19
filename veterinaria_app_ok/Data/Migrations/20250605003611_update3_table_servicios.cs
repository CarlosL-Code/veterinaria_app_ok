using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace veterinaria_app_ok.Data.Migrations
{
    /// <inheritdoc />
    public partial class update3_table_servicios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servicio_Categorias_CategoriaId",
                table: "Servicio");

            migrationBuilder.DropIndex(
                name: "IX_Servicio_CategoriaId",
                table: "Servicio");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Servicio");

            migrationBuilder.CreateTable(
                name: "CategoriaServicio",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    ServiciosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaServicio", x => new { x.CategoriaId, x.ServiciosId });
                    table.ForeignKey(
                        name: "FK_CategoriaServicio_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoriaServicio_Servicio_ServiciosId",
                        column: x => x.ServiciosId,
                        principalTable: "Servicio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoriaServicio_ServiciosId",
                table: "CategoriaServicio",
                column: "ServiciosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriaServicio");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Servicio",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Servicio_CategoriaId",
                table: "Servicio",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Servicio_Categorias_CategoriaId",
                table: "Servicio",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
