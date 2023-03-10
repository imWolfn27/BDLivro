using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BDLivro.Migrations
{
    /// <inheritdoc />
    public partial class LivroUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Livros",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Livros",
                newName: "ID");
        }
    }
}
