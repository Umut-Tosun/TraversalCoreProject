using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class SubAboutNameChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Su",
                table: "Su");

            migrationBuilder.RenameTable(
                name: "Su",
                newName: "SubAbout");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubAbout",
                table: "SubAbout",
                column: "SubAboutId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SubAbout",
                table: "SubAbout");

            migrationBuilder.RenameTable(
                name: "SubAbout",
                newName: "Su");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Su",
                table: "Su",
                column: "SubAboutId");
        }
    }
}
