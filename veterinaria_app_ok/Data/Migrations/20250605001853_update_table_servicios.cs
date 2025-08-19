using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace veterinaria_app_ok.Data.Migrations
{
    /// <inheritdoc />
    public partial class update_table_servicios : Migration
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

            migrationBuilder.AlterColumn<string>(
                name: "CategoriaId",
                table: "Servicio",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ServicioId",
                table: "Categorias",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_ServicioId",
                table: "Categorias",
                column: "ServicioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categorias_Servicio_ServicioId",
                table: "Categorias",
                column: "ServicioId",
                principalTable: "Servicio",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorias_Servicio_ServicioId",
                table: "Categorias");

            migrationBuilder.DropIndex(
                name: "IX_Categorias_ServicioId",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "ServicioId",
                table: "Categorias");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "Servicio",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
