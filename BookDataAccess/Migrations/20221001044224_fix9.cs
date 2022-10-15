using Microsoft.EntityFrameworkCore.Migrations;

namespace BookDataAccess.Migrations
{
    public partial class fix9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE OR ALTER VIEW dbo.GetOnlyBookDetails
                AS
                SELECT 
      [title]
      ,[BookDetail_Id]
      ,[Publishers_Id]
      ,[NumberOfchapters]   FROM [EnitityExample].[dbo].[Books]
            ");

            migrationBuilder.Sql(@"CREATE PROCEDURE dbo.getAllBookDetails   
                    @bookId int
                AS   

                    SET NOCOUNT ON;  
                    SELECT  *  FROM dbo.Books b
	                WHERE b.Book_Id=@bookId
                GO  
            ");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
