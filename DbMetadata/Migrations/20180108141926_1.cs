﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DbMetadata.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    OrganizationPropertyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OwnerOrganizationOrganizationId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
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
                    DepartmentPropertyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OwnerDepartmentDepartmentId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
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
                    Name = table.Column<string>(nullable: true),
                    OwnerDepartmentDepartmentId = table.Column<int>(nullable: true)
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
                name: "ProjectProperties",
                columns: table => new
                {
                    ProjectPropertyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OwnerProjectProjectId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentProperties_OwnerDepartmentDepartmentId",
                table: "DepartmentProperties",
                column: "OwnerDepartmentDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_OwnerOrganizationOrganizationId",
                table: "Departments",
                column: "OwnerOrganizationOrganizationId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentProperties");

            migrationBuilder.DropTable(
                name: "OrganizationProperties");

            migrationBuilder.DropTable(
                name: "ProjectProperties");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Organizations");
        }
    }
}