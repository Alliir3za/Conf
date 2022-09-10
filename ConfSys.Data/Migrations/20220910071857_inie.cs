using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConfSys.Data.Migrations
{
    public partial class inie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "Base",
                table: "Project",
                newName: "ProjectName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProjectName",
                schema: "Base",
                table: "Project",
                newName: "Name");
        }
    }
}
