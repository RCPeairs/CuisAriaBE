using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CuisAriaBE.Migrations
{
    public partial class UserRecipeFavoriteJoin24 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRecipeFavorite_Recipes_RecipeId",
                table: "UserRecipeFavorite");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRecipeFavorite_Users_UserId",
                table: "UserRecipeFavorite");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserRecipeFavorite");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRecipeFavorite_Recipes_RecipeId",
                table: "UserRecipeFavorite",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRecipeFavorite_Users_UserId",
                table: "UserRecipeFavorite",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRecipeFavorite_Recipes_RecipeId",
                table: "UserRecipeFavorite");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRecipeFavorite_Users_UserId",
                table: "UserRecipeFavorite");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserRecipeFavorite",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRecipeFavorite_Recipes_RecipeId",
                table: "UserRecipeFavorite",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRecipeFavorite_Users_UserId",
                table: "UserRecipeFavorite",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
