using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CuisAriaBE.Migrations
{
    public partial class FullSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_ShoppingLists_ShoppingListId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "Servings",
                table: "Recipes",
                newName: "RecipeServings");

            migrationBuilder.RenameColumn(
                name: "Servings",
                table: "MenuRecipe",
                newName: "MenuServings");

            migrationBuilder.RenameColumn(
                name: "ShoppingListId",
                table: "Items",
                newName: "ShoppingListsId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_ShoppingListId",
                table: "Items",
                newName: "IX_Items_ShoppingListsId");

            migrationBuilder.AlterColumn<decimal>(
                name: "IngredQty",
                table: "StepIngredient",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "ServingSize",
                table: "Recipes",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ItemQty",
                table: "Items",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Items_ShoppingLists_ShoppingListsId",
                table: "Items",
                column: "ShoppingListsId",
                principalTable: "ShoppingLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_ShoppingLists_ShoppingListsId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ServingSize",
                table: "Recipes");

            migrationBuilder.RenameColumn(
                name: "RecipeServings",
                table: "Recipes",
                newName: "Servings");

            migrationBuilder.RenameColumn(
                name: "MenuServings",
                table: "MenuRecipe",
                newName: "Servings");

            migrationBuilder.RenameColumn(
                name: "ShoppingListsId",
                table: "Items",
                newName: "ShoppingListId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_ShoppingListsId",
                table: "Items",
                newName: "IX_Items_ShoppingListId");

            migrationBuilder.AlterColumn<int>(
                name: "IngredQty",
                table: "StepIngredient",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<int>(
                name: "ItemQty",
                table: "Items",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AddForeignKey(
                name: "FK_Items_ShoppingLists_ShoppingListId",
                table: "Items",
                column: "ShoppingListId",
                principalTable: "ShoppingLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
