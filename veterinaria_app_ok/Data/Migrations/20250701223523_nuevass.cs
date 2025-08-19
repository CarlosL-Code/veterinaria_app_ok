using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace veterinaria_app_ok.Data.Migrations
{
    /// <inheritdoc />
    public partial class nuevass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AtencionServicio_Atencion_atencionId",
                table: "AtencionServicio");

            migrationBuilder.DropForeignKey(
                name: "FK_AtencionServicio_Servicio_servicioId",
                table: "AtencionServicio");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoriaServicio_Categorias_CategoriaId",
                table: "CategoriaServicio");

            migrationBuilder.RenameColumn(
                name: "CategoriaId",
                table: "CategoriaServicio",
                newName: "CategoriasId");

            migrationBuilder.RenameColumn(
                name: "servicioId",
                table: "AtencionServicio",
                newName: "ServiciosId");

            migrationBuilder.RenameColumn(
                name: "atencionId",
                table: "AtencionServicio",
                newName: "AtencionesId");

            migrationBuilder.RenameIndex(
                name: "IX_AtencionServicio_servicioId",
                table: "AtencionServicio",
                newName: "IX_AtencionServicio_ServiciosId");

            migrationBuilder.AddForeignKey(
                name: "FK_AtencionServicio_Atencion_AtencionesId",
                table: "AtencionServicio",
                column: "AtencionesId",
                principalTable: "Atencion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AtencionServicio_Servicio_ServiciosId",
                table: "AtencionServicio",
                column: "ServiciosId",
                principalTable: "Servicio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriaServicio_Categorias_CategoriasId",
                table: "CategoriaServicio",
                column: "CategoriasId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AtencionServicio_Atencion_AtencionesId",
                table: "AtencionServicio");

            migrationBuilder.DropForeignKey(
                name: "FK_AtencionServicio_Servicio_ServiciosId",
                table: "AtencionServicio");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoriaServicio_Categorias_CategoriasId",
                table: "CategoriaServicio");

            migrationBuilder.RenameColumn(
                name: "CategoriasId",
                table: "CategoriaServicio",
                newName: "CategoriaId");

            migrationBuilder.RenameColumn(
                name: "ServiciosId",
                table: "AtencionServicio",
                newName: "servicioId");

            migrationBuilder.RenameColumn(
                name: "AtencionesId",
                table: "AtencionServicio",
                newName: "atencionId");

            migrationBuilder.RenameIndex(
                name: "IX_AtencionServicio_ServiciosId",
                table: "AtencionServicio",
                newName: "IX_AtencionServicio_servicioId");

            migrationBuilder.AddForeignKey(
                name: "FK_AtencionServicio_Atencion_atencionId",
                table: "AtencionServicio",
                column: "atencionId",
                principalTable: "Atencion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AtencionServicio_Servicio_servicioId",
                table: "AtencionServicio",
                column: "servicioId",
                principalTable: "Servicio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriaServicio_Categorias_CategoriaId",
                table: "CategoriaServicio",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
