using EFCore.MigrationExtensions.SqlObjects;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestSqlServer.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                });

            migrationBuilder.CreateOrUpdateSqlObject(
                name: "test.sql",
                sqlCode: "select 1;",
                order: 2147483647);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSqlObject(
                name: "test.sql",
                sqlCode: "", //DROP test.sql, // write code to drop object
                order: 2147483647);

            migrationBuilder.DropTable(
                name: "Classes");
        }
    }
}
