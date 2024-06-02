using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoomerChallenger.Infra.Migrations
{
    /// <inheritdoc />
    public partial class PrimeiraMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DescricaoPromocao",
                schema: "GoomerContext",
                table: "Produto",
                type: "Varchar(40)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(40)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DescricaoPromocao",
                schema: "GoomerContext",
                table: "Produto",
                type: "Varchar(40)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(40)");
        }
    }
}
