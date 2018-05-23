using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PDM.Data.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentFiles_DocumentFiles_PrevVersionDocumentFileId",
                table: "DocumentFiles");

            migrationBuilder.DropIndex(
                name: "IX_Documents_FileDocumentFileId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_DocumentFiles_PrevVersionDocumentFileId",
                table: "DocumentFiles");

            migrationBuilder.DropColumn(
                name: "PrevVersionDocumentFileId",
                table: "DocumentFiles");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_FileDocumentFileId",
                table: "Documents",
                column: "FileDocumentFileId",
                unique: true,
                filter: "[FileDocumentFileId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Documents_FileDocumentFileId",
                table: "Documents");

            migrationBuilder.AddColumn<int>(
                name: "PrevVersionDocumentFileId",
                table: "DocumentFiles",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documents_FileDocumentFileId",
                table: "Documents",
                column: "FileDocumentFileId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentFiles_PrevVersionDocumentFileId",
                table: "DocumentFiles",
                column: "PrevVersionDocumentFileId");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentFiles_DocumentFiles_PrevVersionDocumentFileId",
                table: "DocumentFiles",
                column: "PrevVersionDocumentFileId",
                principalTable: "DocumentFiles",
                principalColumn: "DocumentFileId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
