using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ellipse.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRequestTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HCSystemsAdminApproved",
                table: "Requests",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HcAdminApprovalId",
                table: "Requests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ICTManagerApprovalId",
                table: "Requests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ICTManagerApproved",
                table: "Requests",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LineManagerApprovalId",
                table: "Requests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "LineManagerApproved",
                table: "Requests",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "MissingDocuments",
                table: "Requests",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RequestClosed",
                table: "Requests",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TemporaryPosition",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TemporaryPostId",
                table: "Requests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TrainingApprovalId",
                table: "Requests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TrainingCompletionDate",
                table: "Requests",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TrainingVerified",
                table: "Requests",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HCSystemsAdminApproved",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "HcAdminApprovalId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "ICTManagerApprovalId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "ICTManagerApproved",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "LineManagerApprovalId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "LineManagerApproved",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "MissingDocuments",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "RequestClosed",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "TemporaryPosition",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "TemporaryPostId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "TrainingApprovalId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "TrainingCompletionDate",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "TrainingVerified",
                table: "Requests");
        }
    }
}
