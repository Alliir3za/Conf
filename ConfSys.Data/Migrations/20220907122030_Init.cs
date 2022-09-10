using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConfSys.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Base");

            migrationBuilder.CreateTable(
                name: "Origin",
                schema: "Base",
                columns: table => new
                {
                    OriginId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Origin", x => x.OriginId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "Base",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OriginId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Family = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<byte>(type: "tinyint", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_Origin_OriginId",
                        column: x => x.OriginId,
                        principalSchema: "Base",
                        principalTable: "Origin",
                        principalColumn: "OriginId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FamilyMember",
                schema: "Base",
                columns: table => new
                {
                    FamilyMemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Family = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Age = table.Column<byte>(type: "tinyint", nullable: false),
                    Gender = table.Column<byte>(type: "tinyint", nullable: false),
                    NationalCode = table.Column<string>(type: "char(10)", maxLength: 10, nullable: false),
                    Relation = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyMember", x => x.FamilyMemberId);
                    table.ForeignKey(
                        name: "FK_FamilyMember_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Base",
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                schema: "Base",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Website = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_Project_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Base",
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                schema: "Base",
                columns: table => new
                {
                    MembersId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    Engagement = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndOfEngagement = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MembersId);
                    table.ForeignKey(
                        name: "FK_Members_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "Base",
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Members_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Base",
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMember_UserId",
                schema: "Base",
                table: "FamilyMember",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_ProjectId",
                schema: "Base",
                table: "Members",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_UserId",
                schema: "Base",
                table: "Members",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_UserId",
                schema: "Base",
                table: "Project",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_OriginId",
                schema: "Base",
                table: "User",
                column: "OriginId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FamilyMember",
                schema: "Base");

            migrationBuilder.DropTable(
                name: "Members",
                schema: "Base");

            migrationBuilder.DropTable(
                name: "Project",
                schema: "Base");

            migrationBuilder.DropTable(
                name: "User",
                schema: "Base");

            migrationBuilder.DropTable(
                name: "Origin",
                schema: "Base");
        }
    }
}
