using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConfSys.Data.Migrations
{
    public partial class ChangeProjectName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProjectName",
                schema: "Base",
                table: "Project",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "Base",
                table: "Project",
                newName: "ProjectName");
        }
    }
}
