using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ellipse.Data.Migrations
{
    public partial class SyncExistingColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "EllipseUserId",
                table: "Requests",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "EllipsePosition",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MenuAccess",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BusinessJustification",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RequestType",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Environment",
                table: "Requests",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserAccessType",
                table: "Requests",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AdditionalUserAccess",
                table: "Requests",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "userId",
                table: "Requests",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "UserType",
                table: "Requests",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "EllipseUserId", table: "Requests");
            migrationBuilder.DropColumn(name: "EllipsePosition", table: "Requests");
            migrationBuilder.DropColumn(name: "MenuAccess", table: "Requests");
            migrationBuilder.DropColumn(name: "BusinessJustification", table: "Requests");
            migrationBuilder.DropColumn(name: "RequestType", table: "Requests");
            migrationBuilder.DropColumn(name: "Environment", table: "Requests");
            migrationBuilder.DropColumn(name: "UserAccessType", table: "Requests");
            migrationBuilder.DropColumn(name: "AdditionalUserAccess", table: "Requests");
            migrationBuilder.DropColumn(name: "userId", table: "Requests");
            migrationBuilder.DropColumn(name: "UserType", table: "Requests");
        }
    }
}