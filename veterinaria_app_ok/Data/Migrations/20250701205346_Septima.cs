using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace veterinaria_app_ok.Data.Migrations
{
    /// <inheritdoc />
    public partial class Septima : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AtencionServicio_Atencion_AtencionId",
                table: "AtencionServicio");

            migrationBuilder.DropForeignKey(
                name: "FK_AtencionServicio_Servicio_ServicioId",
                table: "AtencionServicio");

            migrationBuilder.RenameColumn(
                name: "ServicioId",
                table: "AtencionServicio",
                newName: "servicioId");

            migrationBuilder.RenameColumn(
                name: "AtencionId",
                table: "AtencionServicio",
                newName: "atencionId");

            migrationBuilder.RenameIndex(
                name: "IX_AtencionServicio_ServicioId",
                table: "AtencionServicio",
                newName: "IX_AtencionServicio_servicioId");

            migrationBuilder.AddColumn<string>(
                name: "AvatarPath",
                table: "Mascota",
                type: "nvarchar(max)",
                nullable: true);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AtencionServicio_Atencion_atencionId",
                table: "AtencionServicio");

            migrationBuilder.DropForeignKey(
                name: "FK_AtencionServicio_Servicio_servicioId",
                table: "AtencionServicio");

            migrationBuilder.DropColumn(
                name: "AvatarPath",
                table: "Mascota");

            migrationBuilder.RenameColumn(
                name: "servicioId",
                table: "AtencionServicio",
                newName: "ServicioId");

            migrationBuilder.RenameColumn(
                name: "atencionId",
                table: "AtencionServicio",
                newName: "AtencionId");

            migrationBuilder.RenameIndex(
                name: "IX_AtencionServicio_servicioId",
                table: "AtencionServicio",
                newName: "IX_AtencionServicio_ServicioId");

            migrationBuilder.AddForeignKey(
                name: "FK_AtencionServicio_Atencion_AtencionId",
                table: "AtencionServicio",
                column: "AtencionId",
                principalTable: "Atencion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AtencionServicio_Servicio_ServicioId",
                table: "AtencionServicio",
                column: "ServicioId",
                principalTable: "Servicio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
