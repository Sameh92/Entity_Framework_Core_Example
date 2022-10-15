using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookDataAccess.Migrations
{
    public partial class Init11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "Books",
                newName: "Book_Id");

            migrationBuilder.CreateTable(
                name: "AuthorFlunet",
                columns: table => new
                {
                    Autor_Id_flunet = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorFlunet", x => x.Autor_Id_flunet);
                });

            migrationBuilder.CreateTable(
                name: "BookDetailFluent",
                columns: table => new
                {
                    Id_BookDetailFluent = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfPage = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookDetailFluent", x => x.Id_BookDetailFluent);
                });

            migrationBuilder.CreateTable(
                name: "PublisherFluent",
                columns: table => new
                {
                    Id_Pubisher = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublisherFluent", x => x.Id_Pubisher);
                });

            migrationBuilder.CreateTable(
                name: "BookFluent",
                columns: table => new
                {
                    Book_Id_Flent = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    BookDetail_Id = table.Column<int>(type: "int", nullable: false),
                    Publishers_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookFluent", x => x.Book_Id_Flent);
                    table.ForeignKey(
                        name: "FK_BookFluent_BookDetailFluent_BookDetail_Id",
                        column: x => x.BookDetail_Id,
                        principalTable: "BookDetailFluent",
                        principalColumn: "Id_BookDetailFluent",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookFluent_PublisherFluent_Publishers_Id",
                        column: x => x.Publishers_Id,
                        principalTable: "PublisherFluent",
                        principalColumn: "Id_Pubisher",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookAuthorFluent",
                columns: table => new
                {
                    Book_Id = table.Column<int>(type: "int", nullable: false),
                    Author_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthorFluent", x => new { x.Book_Id, x.Author_Id });
                    table.ForeignKey(
                        name: "FK_BookAuthorFluent_AuthorFlunet_Author_Id",
                        column: x => x.Author_Id,
                        principalTable: "AuthorFlunet",
                        principalColumn: "Autor_Id_flunet",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookAuthorFluent_BookFluent_Book_Id",
                        column: x => x.Book_Id,
                        principalTable: "BookFluent",
                        principalColumn: "Book_Id_Flent",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthorFluent_Author_Id",
                table: "BookAuthorFluent",
                column: "Author_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BookFluent_BookDetail_Id",
                table: "BookFluent",
                column: "BookDetail_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookFluent_Publishers_Id",
                table: "BookFluent",
                column: "Publishers_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookAuthorFluent");

            migrationBuilder.DropTable(
                name: "AuthorFlunet");

            migrationBuilder.DropTable(
                name: "BookFluent");

            migrationBuilder.DropTable(
                name: "BookDetailFluent");

            migrationBuilder.DropTable(
                name: "PublisherFluent");

            migrationBuilder.RenameColumn(
                name: "Book_Id",
                table: "Books",
                newName: "BookId");
        }
    }
}
