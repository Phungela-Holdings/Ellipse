using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ellipse.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contractors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentificationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResponsibleManager = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessJustification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Branch = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contractors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmailAddress = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Branch = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActiveDirectortyUsername = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmailAddress);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RequestedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EllipseUserId = table.Column<long>(type: "bigint", nullable: false),
                    EllipsePosition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MenuAccess = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessJustification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Environment = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserAccessType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AdditionalUserAccess = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    userId = table.Column<long>(type: "bigint", nullable: false),
                    UserType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ContractId = table.Column<int>(type: "int", nullable: true),
                    EmployeeEmail = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TemporaryPosition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemporaryPostId = table.Column<int>(type: "int", nullable: true),
                    MissingDocuments = table.Column<bool>(type: "bit", nullable: true),
                    LineManagerApproved = table.Column<bool>(type: "bit", nullable: true),
                    TrainingVerified = table.Column<bool>(type: "bit", nullable: true),
                    ICTManagerApproved = table.Column<bool>(type: "bit", nullable: true),
                    HCSystemsAdminApproved = table.Column<bool>(type: "bit", nullable: true),
                    TrainingCompletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RequestClosed = table.Column<bool>(type: "bit", nullable: true),
                    HcAdminApprovalId = table.Column<int>(type: "int", nullable: true),
                    LineManagerApprovalId = table.Column<int>(type: "int", nullable: true),
                    TrainingApprovalId = table.Column<int>(type: "int", nullable: true),
                    ICTManagerApprovalId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_Contractors_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contractors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Requests_Employees_EmployeeEmail",
                        column: x => x.EmployeeEmail,
                        principalTable: "Employees",
                        principalColumn: "EmailAddress");
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    DateUplouded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DocumentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    ArchivedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestApprovals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostId = table.Column<long>(type: "bigint", nullable: false),
                    ServiceNumber = table.Column<long>(type: "bigint", nullable: false),
                    ApprovalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    ApprovalType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestApprovals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestApprovals_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentAccesses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentId = table.Column<int>(type: "int", nullable: false),
                    DateAccessed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccessedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentAccesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentAccesses_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentAudits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuditType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentData = table.Column<byte>(type: "tinyint", nullable: false),
                    OldDocumentData = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentAudits_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentAccesses_DocumentId",
                table: "DocumentAccesses",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentAudits_DocumentId",
                table: "DocumentAudits",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_RequestId",
                table: "Documents",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestApprovals_RequestId",
                table: "RequestApprovals",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ContractId",
                table: "Requests",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_EmployeeEmail",
                table: "Requests",
                column: "EmployeeEmail");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentAccesses");

            migrationBuilder.DropTable(
                name: "DocumentAudits");

            migrationBuilder.DropTable(
                name: "RequestApprovals");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Contractors");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
