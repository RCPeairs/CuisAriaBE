using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CuisAriaBE.Migrations
{
    public partial class StepIngredients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_ShoppingLists_ShoppingListsId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_ShoppingListsId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ShoppingListsId",
                table: "Items");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ShoppingLists",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Menus",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShoppingListId",
                table: "Items",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Items_ShoppingListId",
                table: "Items",
                column: "ShoppingListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_ShoppingLists_ShoppingListId",
                table: "Items",
                column: "ShoppingListId",
                principalTable: "ShoppingLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_ShoppingLists_ShoppingListId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_ShoppingListId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ShoppingListId",
                table: "Items");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ShoppingLists",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Menus",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ShoppingListsId",
                table: "Items",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_ShoppingListsId",
                table: "Items",
                column: "ShoppingListsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_ShoppingLists_ShoppingListsId",
                table: "Items",
                column: "ShoppingListsId",
                principalTable: "ShoppingLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
