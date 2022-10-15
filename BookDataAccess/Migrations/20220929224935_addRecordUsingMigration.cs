using Microsoft.EntityFrameworkCore.Migrations;

namespace BookDataAccess.Migrations
{
    public partial class addRecordUsingMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("  INSERT into Schools     ([SchoolName]) Values ('sameh') ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
