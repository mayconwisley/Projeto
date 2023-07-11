using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto.API.Migrations
{
    /// <inheritdoc />
    public partial class AjusteTabelaUsuario1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nivel",
                table: "Usuarios");

            migrationBuilder.AddColumn<int>(
                name: "Autorizacao",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Autorizacao",
                table: "Usuarios");

            migrationBuilder.AddColumn<string>(
                name: "Nivel",
                table: "Usuarios",
                type: "VARCHAR(100)",
                nullable: false,
                defaultValue: "");
        }
    }
}
