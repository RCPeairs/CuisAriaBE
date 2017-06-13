using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CuisAriaBE.Migrations
{
    public partial class MenuRecipeJoin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Menus",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MenuRecipe",
                columns: table => new
                {
                    MenuId = table.Column<int>(nullable: false),
                    RecipeId = table.Column<int>(nullable: false),
                    Servings = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuRecipe", x => new { x.MenuId, x.RecipeId });
                    table.ForeignKey(
                        name: "FK_MenuRecipe_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "MenuId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuRecipe_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Menus_UserId",
                table: "Menus",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuRecipe_RecipeId",
                table: "MenuRecipe",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Users_UserId",
                table: "Menus",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Users_UserId",
                table: "Menus");

            migrationBuilder.DropTable(
                name: "MenuRecipe");

            migrationBuilder.DropIndex(
                name: "IX_Menus_UserId",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Menus");
        }
    }
}
