using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PDM.Data.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Documents_FileDocumentFileId",
                table: "Documents");

            migrationBuilder.AddColumn<int>(
                name: "OwnerDocumentId",
                table: "DocumentFiles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Documents_FileDocumentFileId",
                table: "Documents",
                column: "FileDocumentFileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Documents_FileDocumentFileId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "OwnerDocumentId",
                table: "DocumentFiles");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_FileDocumentFileId",
                table: "Documents",
                column: "FileDocumentFileId",
                unique: true,
                filter: "[FileDocumentFileId] IS NOT NULL");
        }
    }
}
