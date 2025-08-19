using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace veterinaria_app_ok.Data.Migrations
{
    /// <inheritdoc />
    public partial class _003_mascotaactualizar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mascota_Categorias_CategoriaId1",
                table: "Mascota");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Mascota",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CategoriaId1",
                table: "Mascota",
                newName: "CategoriaId");

            migrationBuilder.RenameIndex(
                name: "IX_Mascota_CategoriaId1",
                table: "Mascota",
                newName: "IX_Mascota_CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mascota_Categorias_CategoriaId",
                table: "Mascota",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mascota_Categorias_CategoriaId",
                table: "Mascota");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Mascota",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "CategoriaId",
                table: "Mascota",
                newName: "CategoriaId1");

            migrationBuilder.RenameIndex(
                name: "IX_Mascota_CategoriaId",
                table: "Mascota",
                newName: "IX_Mascota_CategoriaId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Mascota_Categorias_CategoriaId1",
                table: "Mascota",
                column: "CategoriaId1",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
