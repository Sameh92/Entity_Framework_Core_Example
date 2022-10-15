using Microsoft.EntityFrameworkCore.Migrations;

namespace BookDataAccess.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthor_Author_Author_Id",
                table: "BookAuthor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Author",
                table: "Author");

            migrationBuilder.RenameTable(
                name: "Author",
                newName: "Authors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authors",
                table: "Authors",
                column: "Autor_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthor_Authors_Author_Id",
                table: "BookAuthor",
                column: "Author_Id",
                principalTable: "Authors",
                principalColumn: "Autor_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthor_Authors_Author_Id",
                table: "BookAuthor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authors",
                table: "Authors");

            migrationBuilder.RenameTable(
                name: "Authors",
                newName: "Author");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Author",
                table: "Author",
                column: "Autor_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthor_Author_Author_Id",
                table: "BookAuthor",
                column: "Author_Id",
                principalTable: "Author",
                principalColumn: "Autor_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
