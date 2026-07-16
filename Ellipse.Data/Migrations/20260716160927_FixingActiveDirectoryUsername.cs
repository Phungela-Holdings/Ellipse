using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ellipse.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixingActiveDirectoryUsername : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ActiveDirectortyUsername",
                table: "Employees",
                newName: "ActiveDirectoryUsername");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ActiveDirectoryUsername",
                table: "Employees",
                newName: "ActiveDirectortyUsername");
        }
    }
}
