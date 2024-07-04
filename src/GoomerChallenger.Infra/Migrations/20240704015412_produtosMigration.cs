using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoomerChallenger.Infra.Migrations
{
    /// <inheritdoc />
    public partial class produtosMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DtValidade",
                schema: "GoomerContext",
                table: "Produto",
                type: "VarChar(8)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date");

            migrationBuilder.AlterColumn<string>(
                name: "DtAquisicao",
                schema: "GoomerContext",
                table: "Produto",
                type: "VarChar(8)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DtValidade",
                schema: "GoomerContext",
                table: "Produto",
                type: "Date",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VarChar(8)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DtAquisicao",
                schema: "GoomerContext",
                table: "Produto",
                type: "Date",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VarChar(8)");
        }
    }
}
