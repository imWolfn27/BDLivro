using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BDLivro.Migrations
{
    /// <inheritdoc />
    public partial class InicialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livros_Autor_AutorId",
                table: "Livros");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Autor_TempId",
                table: "Autor");

            migrationBuilder.DropColumn(
                name: "TempId",
                table: "Autor");

            migrationBuilder.AddForeignKey(
                name: "FK_Livros_Autor_AutorId",
                table: "Livros",
                column: "AutorId",
                principalTable: "Autor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livros_Autor_AutorId",
                table: "Livros");

            migrationBuilder.AddColumn<decimal>(
                name: "TempId",
                table: "Autor",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Autor_TempId",
                table: "Autor",
                column: "TempId");

            migrationBuilder.AddForeignKey(
                name: "FK_Livros_Autor_AutorId",
                table: "Livros",
                column: "AutorId",
                principalTable: "Autor",
                principalColumn: "TempId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
