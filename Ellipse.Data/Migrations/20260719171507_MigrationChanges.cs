using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ellipse.Data.Migrations
{
    /// <inheritdoc />
    public partial class MigrationChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Documents",
                newName: "Active");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Documents",
                newName: "IsActive");
        }
    }
}
