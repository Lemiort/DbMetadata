using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbMetadata.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_Projects_OwnerProjectProjectId",
                table: "Task");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Task",
                table: "Task");

            migrationBuilder.RenameTable(
                name: "Task",
                newName: "Tasks");

            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "Tasks",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "OwnerProjectProjectId",
                table: "Tasks",
                newName: "ProjectId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Tasks",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "EndTime",
                table: "Tasks",
                newName: "EndDate");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Tasks",
                newName: "Text");

            migrationBuilder.RenameIndex(
                name: "IX_Task_OwnerProjectProjectId",
                table: "Tasks",
                newName: "IX_Tasks_ProjectId");

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Tasks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Editable",
                table: "Tasks",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Open",
                table: "Tasks",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Tasks",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Progress",
                table: "Tasks",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "Readonly",
                table: "Tasks",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "TaskId");

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    LinkId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: true),
                    SourceTaskId = table.Column<int>(nullable: false),
                    TargetTaskId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.LinkId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Projects_ProjectId",
                table: "Tasks",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Projects_ProjectId",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Editable",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Open",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Progress",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Readonly",
                table: "Tasks");

            migrationBuilder.RenameTable(
                name: "Tasks",
                newName: "Task");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Task",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Task",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Task",
                newName: "StartTime");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "Task",
                newName: "OwnerProjectProjectId");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Task",
                newName: "EndTime");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_ProjectId",
                table: "Task",
                newName: "IX_Task_OwnerProjectProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Task",
                table: "Task",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Projects_OwnerProjectProjectId",
                table: "Task",
                column: "OwnerProjectProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
