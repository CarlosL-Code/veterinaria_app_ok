using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace veterinaria_app_ok.Data.Migrations
{
    /// <inheritdoc />
    public partial class cuarta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atencion_AspNetUsers_UsuarioId",
                table: "Atencion");

            migrationBuilder.DropIndex(
                name: "IX_Atencion_UsuarioId",
                table: "Atencion");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Atencion");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Atencion",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Atencion_UserId",
                table: "Atencion",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Atencion_AspNetUsers_UserId",
                table: "Atencion",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atencion_AspNetUsers_UserId",
                table: "Atencion");

            migrationBuilder.DropIndex(
                name: "IX_Atencion_UserId",
                table: "Atencion");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Atencion",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "Atencion",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Atencion_UsuarioId",
                table: "Atencion",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Atencion_AspNetUsers_UsuarioId",
                table: "Atencion",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
