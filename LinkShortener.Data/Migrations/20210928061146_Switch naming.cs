using Microsoft.EntityFrameworkCore.Migrations;

namespace LinkMinfier.Data.Migrations
{
    public partial class Switchnaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MinifiedLink",
                table: "Links",
                newName: "ShortenedLink");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShortenedLink",
                table: "Links",
                newName: "MinifiedLink");
        }
    }
}
