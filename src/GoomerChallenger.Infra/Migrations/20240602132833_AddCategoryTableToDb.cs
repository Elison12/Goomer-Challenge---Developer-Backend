using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GoomerChallenger.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryTableToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "GoomerContext");

            migrationBuilder.CreateTable(
                name: "Produto",
                schema: "GoomerContext",
                columns: table => new
                {
                    IdProduto = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "Varchar(40)", nullable: false),
                    Codigo = table.Column<string>(type: "Varchar(10)", nullable: false),
                    Valro = table.Column<float>(type: "real", nullable: false),
                    Categoria = table.Column<string>(type: "Varchar(20)", nullable: false),
                    DtValidade = table.Column<DateTime>(type: "Date", nullable: false),
                    DtAquisicao = table.Column<DateTime>(type: "Date", nullable: false),
                    Departamento = table.Column<string>(type: "Varchar(20)", nullable: false),
                    Lote = table.Column<int>(type: "integer", nullable: false),
                    IsPromocao = table.Column<bool>(type: "boolean", nullable: false),
                    DescricaoPromocao = table.Column<string>(type: "Varchar(40)", nullable: false),
                    PrecoPromocional = table.Column<float>(type: "real", nullable: false),
                    CaminhoFoto = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.IdProduto);
                });

            migrationBuilder.CreateTable(
                name: "Restaurante",
                schema: "GoomerContext",
                columns: table => new
                {
                    IdRestaurante = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "Varchar(20)", nullable: false),
                    Endereco = table.Column<string>(type: "Varchar(80)", nullable: false),
                    Telefone = table.Column<string>(type: "Varchar(15)", nullable: false),
                    NumFuncionarios = table.Column<int>(type: "integer", nullable: false),
                    Gerente = table.Column<string>(type: "Varchar(20)", nullable: false),
                    CaminhoFoto = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurante", x => x.IdRestaurante);
                });

            migrationBuilder.CreateTable(
                name: "Cardapio",
                schema: "GoomerContext",
                columns: table => new
                {
                    idCardapio = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idRestaurante = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cardapio", x => x.idCardapio);
                    table.ForeignKey(
                        name: "FK_Cardapio_Restaurante_idRestaurante",
                        column: x => x.idRestaurante,
                        principalSchema: "GoomerContext",
                        principalTable: "Restaurante",
                        principalColumn: "IdRestaurante",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prato",
                schema: "GoomerContext",
                columns: table => new
                {
                    IdPrato = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    valor = table.Column<float>(type: "real", nullable: false),
                    Codigo = table.Column<int>(type: "integer", nullable: false),
                    RestauranteId = table.Column<int>(type: "integer", nullable: false),
                    idCardapio = table.Column<int>(type: "integer", nullable: false),
                    CaminhoFoto = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prato", x => x.IdPrato);
                    table.ForeignKey(
                        name: "FK_Prato_Cardapio_idCardapio",
                        column: x => x.idCardapio,
                        principalSchema: "GoomerContext",
                        principalTable: "Cardapio",
                        principalColumn: "idCardapio",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prato_Restaurante_RestauranteId",
                        column: x => x.RestauranteId,
                        principalSchema: "GoomerContext",
                        principalTable: "Restaurante",
                        principalColumn: "IdRestaurante",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cardapio_idRestaurante",
                schema: "GoomerContext",
                table: "Cardapio",
                column: "idRestaurante",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prato_idCardapio",
                schema: "GoomerContext",
                table: "Prato",
                column: "idCardapio");

            migrationBuilder.CreateIndex(
                name: "IX_Prato_RestauranteId",
                schema: "GoomerContext",
                table: "Prato",
                column: "RestauranteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prato",
                schema: "GoomerContext");

            migrationBuilder.DropTable(
                name: "Produto",
                schema: "GoomerContext");

            migrationBuilder.DropTable(
                name: "Cardapio",
                schema: "GoomerContext");

            migrationBuilder.DropTable(
                name: "Restaurante",
                schema: "GoomerContext");
        }
    }
}
