using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto.API.Migrations
{
    /// <inheritdoc />
    public partial class PopulandoUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Ativo", "Autorizacao", "Login", "Nome", "Senha" },
                values: new object[] { 1, true, 0, "Admin", "Adminstrador", "a60c1f75938be9607b94620c8925defe4d471cab0cab591fb418e89ff04b8ae7" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
