using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CuisAriaBE.Migrations
{
    public partial class MoreSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeKeyword_Keywords_KeyWordId",
                table: "RecipeKeyword");

            migrationBuilder.RenameColumn(
                name: "KeyWordId",
                table: "RecipeKeyword",
                newName: "KeywordId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeKeyword_KeyWordId",
                table: "RecipeKeyword",
                newName: "IX_RecipeKeyword_KeywordId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeKeyword_Keywords_KeywordId",
                table: "RecipeKeyword",
                column: "KeywordId",
                principalTable: "Keywords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeKeyword_Keywords_KeywordId",
                table: "RecipeKeyword");

            migrationBuilder.RenameColumn(
                name: "KeywordId",
                table: "RecipeKeyword",
                newName: "KeyWordId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeKeyword_KeywordId",
                table: "RecipeKeyword",
                newName: "IX_RecipeKeyword_KeyWordId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeKeyword_Keywords_KeyWordId",
                table: "RecipeKeyword",
                column: "KeyWordId",
                principalTable: "Keywords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
