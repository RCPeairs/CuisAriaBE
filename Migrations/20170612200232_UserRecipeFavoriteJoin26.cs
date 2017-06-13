using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CuisAriaBE.Migrations
{
    public partial class UserRecipeFavoriteJoin26 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecipeId1",
                table: "UserRecipeFavorite",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRecipeFavorite_RecipeId1",
                table: "UserRecipeFavorite",
                column: "RecipeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRecipeFavorite_Recipes_RecipeId1",
                table: "UserRecipeFavorite",
                column: "RecipeId1",
                principalTable: "Recipes",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRecipeFavorite_Recipes_RecipeId1",
                table: "UserRecipeFavorite");

            migrationBuilder.DropIndex(
                name: "IX_UserRecipeFavorite_RecipeId1",
                table: "UserRecipeFavorite");

            migrationBuilder.DropColumn(
                name: "RecipeId1",
                table: "UserRecipeFavorite");
        }
    }
}
