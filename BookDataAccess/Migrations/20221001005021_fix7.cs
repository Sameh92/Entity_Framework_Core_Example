﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace BookDataAccess.Migrations
{
    public partial class fix7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthor_Authors_Author_Id",
                table: "BookAuthor");

            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthor_Books_Book_Id",
                table: "BookAuthor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookAuthor",
                table: "BookAuthor");

            migrationBuilder.RenameTable(
                name: "BookAuthor",
                newName: "BookAuthors");

            migrationBuilder.RenameIndex(
                name: "IX_BookAuthor_Author_Id",
                table: "BookAuthors",
                newName: "IX_BookAuthors_Author_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookAuthors",
                table: "BookAuthors",
                columns: new[] { "Book_Id", "Author_Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthors_Authors_Author_Id",
                table: "BookAuthors",
                column: "Author_Id",
                principalTable: "Authors",
                principalColumn: "Autor_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthors_Books_Book_Id",
                table: "BookAuthors",
                column: "Book_Id",
                principalTable: "Books",
                principalColumn: "Book_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthors_Authors_Author_Id",
                table: "BookAuthors");

            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthors_Books_Book_Id",
                table: "BookAuthors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookAuthors",
                table: "BookAuthors");

            migrationBuilder.RenameTable(
                name: "BookAuthors",
                newName: "BookAuthor");

            migrationBuilder.RenameIndex(
                name: "IX_BookAuthors_Author_Id",
                table: "BookAuthor",
                newName: "IX_BookAuthor_Author_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookAuthor",
                table: "BookAuthor",
                columns: new[] { "Book_Id", "Author_Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthor_Authors_Author_Id",
                table: "BookAuthor",
                column: "Author_Id",
                principalTable: "Authors",
                principalColumn: "Autor_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthor_Books_Book_Id",
                table: "BookAuthor",
                column: "Book_Id",
                principalTable: "Books",
                principalColumn: "Book_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
