using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto.API.Migrations
{
    /// <inheritdoc />
    public partial class CriarTabelasArquivos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoArquivos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "VARCHAR(500)", nullable: false),
                    Guardar = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Tempo = table.Column<int>(type: "int", nullable: false),
                    SuporteItem = table.Column<bool>(type: "bit", nullable: false),
                    SuporteControleCaixa = table.Column<bool>(type: "bit", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoArquivos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    Nivel = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Chave = table.Column<string>(type: "VARCHAR(MAX)", nullable: false),
                    Senha = table.Column<string>(type: "VARCHAR(MAX)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ControleCaixas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroAtual = table.Column<int>(type: "int", nullable: false),
                    TipoArquivoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControleCaixas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ControleCaixas_TipoArquivos_TipoArquivoId",
                        column: x => x.TipoArquivoId,
                        principalTable: "TipoArquivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Arquivos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "VARCHAR(500)", nullable: false),
                    Competencia = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    Arquitetura = table.Column<int>(type: "int", nullable: true),
                    Pratelheira = table.Column<string>(type: "VARCHAR(10)", nullable: true),
                    PratelheiraLinha = table.Column<string>(type: "VARCHAR(10)", nullable: true),
                    PratelheiraColuna = table.Column<string>(type: "VARCHAR(10)", nullable: true),
                    Armario = table.Column<string>(type: "VARCHAR(10)", nullable: true),
                    Gaveta = table.Column<string>(type: "VARCHAR(10)", nullable: true),
                    DataDescarte = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumCaixa = table.Column<int>(type: "int", nullable: false),
                    DataUltimAtualizacao = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    PrimeiroUsuarioCadastro = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    UltimoUsuarioAtualizar = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    TipoArquivoId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arquivos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Arquivos_TipoArquivos_TipoArquivoId",
                        column: x => x.TipoArquivoId,
                        principalTable: "TipoArquivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Arquivos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemArquivos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoItem = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    Descricao = table.Column<string>(type: "VARCHAR(500)", nullable: false),
                    NoArquivo = table.Column<bool>(type: "bit", nullable: false),
                    ArquivoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemArquivos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemArquivos_Arquivos_ArquivoId",
                        column: x => x.ArquivoId,
                        principalTable: "Arquivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Processos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataEnvio = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    ParaQuem = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    Status = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    ItemArquivoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Processos_ItemArquivos_ItemArquivoId",
                        column: x => x.ItemArquivoId,
                        principalTable: "ItemArquivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Arquivos_TipoArquivoId",
                table: "Arquivos",
                column: "TipoArquivoId");

            migrationBuilder.CreateIndex(
                name: "IX_Arquivos_UsuarioId",
                table: "Arquivos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ControleCaixas_TipoArquivoId",
                table: "ControleCaixas",
                column: "TipoArquivoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemArquivos_ArquivoId",
                table: "ItemArquivos",
                column: "ArquivoId");

            migrationBuilder.CreateIndex(
                name: "IX_Processos_ItemArquivoId",
                table: "Processos",
                column: "ItemArquivoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ControleCaixas");

            migrationBuilder.DropTable(
                name: "Processos");

            migrationBuilder.DropTable(
                name: "ItemArquivos");

            migrationBuilder.DropTable(
                name: "Arquivos");

            migrationBuilder.DropTable(
                name: "TipoArquivos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
