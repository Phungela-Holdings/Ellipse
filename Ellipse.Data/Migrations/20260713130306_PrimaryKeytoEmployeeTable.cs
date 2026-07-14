using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ellipse.Data.Migrations
{
    /// <inheritdoc />
    public partial class PrimaryKeytoEmployeeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Contact_Number",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Archived_Date",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "Date_Modified",
                table: "Documents");

            migrationBuilder.RenameColumn(
                name: "Service_Number",
                table: "Employees",
                newName: "ServiceNumber");

            migrationBuilder.RenameColumn(
                name: "First_Name",
                table: "Employees",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "Email_Address",
                table: "Employees",
                newName: "ContactNumber");

            migrationBuilder.RenameColumn(
                name: "Document_Type",
                table: "Documents",
                newName: "DocumentType");

            migrationBuilder.RenameColumn(
                name: "Date_Uplouded",
                table: "Documents",
                newName: "DateUplouded");

            migrationBuilder.RenameColumn(
                name: "DocumentId",
                table: "Documents",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Employees",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Data",
                table: "Documents",
                type: "varbinary(max)",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AddColumn<DateTime>(
                name: "ArchivedDate",
                table: "Documents",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Documents",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "EmailAddress");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ArchivedDate",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Documents");

            migrationBuilder.RenameColumn(
                name: "ServiceNumber",
                table: "Employees",
                newName: "Service_Number");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Employees",
                newName: "First_Name");

            migrationBuilder.RenameColumn(
                name: "ContactNumber",
                table: "Employees",
                newName: "Email_Address");

            migrationBuilder.RenameColumn(
                name: "DocumentType",
                table: "Documents",
                newName: "Document_Type");

            migrationBuilder.RenameColumn(
                name: "DateUplouded",
                table: "Documents",
                newName: "Date_Uplouded");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Documents",
                newName: "DocumentId");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Contact_Number",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<byte>(
                name: "Data",
                table: "Documents",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "Archived_Date",
                table: "Documents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date_Modified",
                table: "Documents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "EmployeeId");
        }
    }
}
