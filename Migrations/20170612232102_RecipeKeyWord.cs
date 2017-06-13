using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CuisAriaBE.Migrations
{
    public partial class RecipeKeyWord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RecipeKeyword",
                columns: table => new
                {
                    RecipeId = table.Column<int>(nullable: false),
                    KeyWordId = table.Column<int>(nullable: false),
                    RecipeId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeKeyword", x => new { x.RecipeId, x.KeyWordId });
                    table.ForeignKey(
                        name: "FK_RecipeKeyword_Keywords_KeyWordId",
                        column: x => x.KeyWordId,
                        principalTable: "Keywords",
                        principalColumn: "KeywordId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecipeKeyword_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecipeKeyword_Recipes_RecipeId1",
                        column: x => x.RecipeId1,
                        principalTable: "Recipes",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeKeyword_KeyWordId",
                table: "RecipeKeyword",
                column: "KeyWordId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeKeyword_RecipeId1",
                table: "RecipeKeyword",
                column: "RecipeId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeKeyword");
        }
    }
}
