using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto.API.Migrations
{
    /// <inheritdoc />
    public partial class AjusteTabelaUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Chave",
                table: "Usuarios");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Login",
                table: "Usuarios",
                column: "Login",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Usuarios_Login",
                table: "Usuarios");

            migrationBuilder.AddColumn<string>(
                name: "Chave",
                table: "Usuarios",
                type: "VARCHAR(MAX)",
                nullable: false,
                defaultValue: "");
        }
    }
}
