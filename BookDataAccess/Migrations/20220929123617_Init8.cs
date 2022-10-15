using Microsoft.EntityFrameworkCore.Migrations;

namespace BookDataAccess.Migrations
{
    public partial class Init8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_samehTable",
                table: "samehTable");

            migrationBuilder.RenameTable(
                name: "samehTable",
                newName: "Books");

            migrationBuilder.RenameColumn(
                name: "sameh",
                table: "Books",
                newName: "title");

            migrationBuilder.AddColumn<int>(
                name: "BookDetail_Id",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "BookId");

            migrationBuilder.CreateTable(
                name: "BookDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfPage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookDetail", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookDetail_Id",
                table: "Books",
                column: "BookDetail_Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookDetail_BookDetail_Id",
                table: "Books",
                column: "BookDetail_Id",
                principalTable: "BookDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookDetail_BookDetail_Id",
                table: "Books");

            migrationBuilder.DropTable(
                name: "BookDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_BookDetail_Id",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BookDetail_Id",
                table: "Books");

            migrationBuilder.RenameTable(
                name: "Books",
                newName: "samehTable");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "samehTable",
                newName: "sameh");

            migrationBuilder.AddPrimaryKey(
                name: "PK_samehTable",
                table: "samehTable",
                column: "BookId");
        }
    }
}
