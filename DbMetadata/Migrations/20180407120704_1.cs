using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbMetadata.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DocumentFiles",
                columns: table => new
                {
                    DocumentFileId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Data = table.Column<byte[]>(nullable: true),
                    ModifiedTime = table.Column<DateTime>(nullable: false),
                    PrevVersionDocumentFileId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentFiles", x => x.DocumentFileId);
                    table.ForeignKey(
                        name: "FK_DocumentFiles_DocumentFiles_PrevVersionDocumentFileId",
                        column: x => x.PrevVersionDocumentFileId,
                        principalTable: "DocumentFiles",
                        principalColumn: "DocumentFileId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    OrganizationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.OrganizationId);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    OwnerOrganizationOrganizationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                    table.ForeignKey(
                        name: "FK_Departments_Organizations_OwnerOrganizationOrganizationId",
                        column: x => x.OwnerOrganizationOrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationProperties",
                columns: table => new
                {
                    Title = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    OrganizationPropertyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OwnerOrganizationOrganizationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationProperties", x => x.OrganizationPropertyId);
                    table.ForeignKey(
                        name: "FK_OrganizationProperties_Organizations_OwnerOrganizationOrganizationId",
                        column: x => x.OwnerOrganizationOrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentProperties",
                columns: table => new
                {
                    Title = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    DepartmentPropertyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OwnerDepartmentDepartmentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentProperties", x => x.DepartmentPropertyId);
                    table.ForeignKey(
                        name: "FK_DepartmentProperties_Departments_OwnerDepartmentDepartmentId",
                        column: x => x.OwnerDepartmentDepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OwnerDepartmentDepartmentId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_Projects_Departments_OwnerDepartmentDepartmentId",
                        column: x => x.OwnerDepartmentDepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    DocumentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FileDocumentFileId = table.Column<int>(nullable: true),
                    ProjectId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.DocumentId);
                    table.ForeignKey(
                        name: "FK_Documents_DocumentFiles_FileDocumentFileId",
                        column: x => x.FileDocumentFileId,
                        principalTable: "DocumentFiles",
                        principalColumn: "DocumentFileId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Documents_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectProperties",
                columns: table => new
                {
                    Title = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    ProjectPropertyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OwnerProjectProjectId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectProperties", x => x.ProjectPropertyId);
                    table.ForeignKey(
                        name: "FK_ProjectProperties_Projects_OwnerProjectProjectId",
                        column: x => x.OwnerProjectProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    TaskId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    OwnerProjectProjectId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_Task_Projects_OwnerProjectProjectId",
                        column: x => x.OwnerProjectProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentProperties_OwnerDepartmentDepartmentId",
                table: "DepartmentProperties",
                column: "OwnerDepartmentDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_OwnerOrganizationOrganizationId",
                table: "Departments",
                column: "OwnerOrganizationOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentFiles_PrevVersionDocumentFileId",
                table: "DocumentFiles",
                column: "PrevVersionDocumentFileId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_FileDocumentFileId",
                table: "Documents",
                column: "FileDocumentFileId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ProjectId",
                table: "Documents",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationProperties_OwnerOrganizationOrganizationId",
                table: "OrganizationProperties",
                column: "OwnerOrganizationOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectProperties_OwnerProjectProjectId",
                table: "ProjectProperties",
                column: "OwnerProjectProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_OwnerDepartmentDepartmentId",
                table: "Projects",
                column: "OwnerDepartmentDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_OwnerProjectProjectId",
                table: "Task",
                column: "OwnerProjectProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentProperties");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "OrganizationProperties");

            migrationBuilder.DropTable(
                name: "ProjectProperties");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "DocumentFiles");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Organizations");
        }
    }
}
