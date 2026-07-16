using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ellipse.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixDateUploadedSpelling : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateUploaded",
                table: "Documents",
                newName: "DateUplouded");

            migrationBuilder.AlterColumn<byte>(
                name: "OldDocumentData",
                table: "DocumentAudits",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AlterColumn<byte>(
                name: "DocumentData",
                table: "DocumentAudits",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");
        }
    }
}
