using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CuisAriaBE.Migrations
{
    public partial class UpdatedNames_VMs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuRecipe_Menus_MenuId",
                table: "MenuRecipe");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuRecipe_Recipes_RecipeId",
                table: "MenuRecipe");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeKeyword_Recipes_RecipeId1",
                table: "RecipeKeyword");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingLists_Users_UserId1",
                table: "ShoppingLists");

            migrationBuilder.DropForeignKey(
                name: "FK_Steps_Recipes_RecipeId1",
                table: "Steps");

            migrationBuilder.DropForeignKey(
                name: "FK_StepIngredient_Ingredients_IngredientId",
                table: "StepIngredient");

            migrationBuilder.DropForeignKey(
                name: "FK_StepIngredient_Steps_StepId",
                table: "StepIngredient");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRecipeFavorite_Recipes_RecipeId1",
                table: "UserRecipeFavorite");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRecipeFavorite_Users_UserId1",
                table: "UserRecipeFavorite");

            migrationBuilder.DropIndex(
                name: "IX_UserRecipeFavorite_RecipeId1",
                table: "UserRecipeFavorite");

            migrationBuilder.DropIndex(
                name: "IX_UserRecipeFavorite_UserId1",
                table: "UserRecipeFavorite");

            migrationBuilder.DropIndex(
                name: "IX_Steps_RecipeId1",
                table: "Steps");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingLists_UserId1",
                table: "ShoppingLists");

            migrationBuilder.DropIndex(
                name: "IX_RecipeKeyword_RecipeId1",
                table: "RecipeKeyword");

            migrationBuilder.DropColumn(
                name: "RecipeId1",
                table: "UserRecipeFavorite");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserRecipeFavorite");

            migrationBuilder.DropColumn(
                name: "RecipeId1",
                table: "Steps");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "ShoppingLists");

            migrationBuilder.DropColumn(
                name: "RecipeId1",
                table: "RecipeKeyword");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Recipes",
                newName: "RecipeName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Menus",
                newName: "MenuName");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuRecipe_Menus_MenuId",
                table: "MenuRecipe",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuRecipe_Recipes_RecipeId",
                table: "MenuRecipe",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StepIngredient_Ingredients_IngredientId",
                table: "StepIngredient",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StepIngredient_Steps_StepId",
                table: "StepIngredient",
                column: "StepId",
                principalTable: "Steps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuRecipe_Menus_MenuId",
                table: "MenuRecipe");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuRecipe_Recipes_RecipeId",
                table: "MenuRecipe");

            migrationBuilder.DropForeignKey(
                name: "FK_StepIngredient_Ingredients_IngredientId",
                table: "StepIngredient");

            migrationBuilder.DropForeignKey(
                name: "FK_StepIngredient_Steps_StepId",
                table: "StepIngredient");

            migrationBuilder.RenameColumn(
                name: "RecipeName",
                table: "Recipes",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "MenuName",
                table: "Menus",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "RecipeId1",
                table: "UserRecipeFavorite",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "UserRecipeFavorite",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecipeId1",
                table: "Steps",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "ShoppingLists",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecipeId1",
                table: "RecipeKeyword",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRecipeFavorite_RecipeId1",
                table: "UserRecipeFavorite",
                column: "RecipeId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserRecipeFavorite_UserId1",
                table: "UserRecipeFavorite",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Steps_RecipeId1",
                table: "Steps",
                column: "RecipeId1");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingLists_UserId1",
                table: "ShoppingLists",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeKeyword_RecipeId1",
                table: "RecipeKeyword",
                column: "RecipeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuRecipe_Menus_MenuId",
                table: "MenuRecipe",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuRecipe_Recipes_RecipeId",
                table: "MenuRecipe",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeKeyword_Recipes_RecipeId1",
                table: "RecipeKeyword",
                column: "RecipeId1",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingLists_Users_UserId1",
                table: "ShoppingLists",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Steps_Recipes_RecipeId1",
                table: "Steps",
                column: "RecipeId1",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StepIngredient_Ingredients_IngredientId",
                table: "StepIngredient",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StepIngredient_Steps_StepId",
                table: "StepIngredient",
                column: "StepId",
                principalTable: "Steps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRecipeFavorite_Recipes_RecipeId1",
                table: "UserRecipeFavorite",
                column: "RecipeId1",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRecipeFavorite_Users_UserId1",
                table: "UserRecipeFavorite",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
