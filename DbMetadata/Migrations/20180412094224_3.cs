using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbMetadata.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Projects_ProjectId",
                table: "Tasks");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Tasks",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Links",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Links_ProjectId",
                table: "Links",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Links_Projects_ProjectId",
                table: "Links",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Projects_ProjectId",
                table: "Tasks",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Links_Projects_ProjectId",
                table: "Links");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Projects_ProjectId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Links_ProjectId",
                table: "Links");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Links");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Tasks",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Projects_ProjectId",
                table: "Tasks",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
