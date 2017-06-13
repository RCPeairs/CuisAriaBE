using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CuisAriaBE.Migrations
{
    public partial class ShoppingList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShoppingListId",
                table: "ShoppingLists",
                newName: "ItemId");

            migrationBuilder.AddColumn<string>(
                name: "ItemName",
                table: "ShoppingLists",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemQty",
                table: "ShoppingLists",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ItemUnit",
                table: "ShoppingLists",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ListName",
                table: "ShoppingLists",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ShoppingLists",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "ShoppingLists",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingLists_UserId",
                table: "ShoppingLists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingLists_UserId1",
                table: "ShoppingLists",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingLists_Users_UserId",
                table: "ShoppingLists",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingLists_Users_UserId1",
                table: "ShoppingLists",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingLists_Users_UserId",
                table: "ShoppingLists");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingLists_Users_UserId1",
                table: "ShoppingLists");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingLists_UserId",
                table: "ShoppingLists");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingLists_UserId1",
                table: "ShoppingLists");

            migrationBuilder.DropColumn(
                name: "ItemName",
                table: "ShoppingLists");

            migrationBuilder.DropColumn(
                name: "ItemQty",
                table: "ShoppingLists");

            migrationBuilder.DropColumn(
                name: "ItemUnit",
                table: "ShoppingLists");

            migrationBuilder.DropColumn(
                name: "ListName",
                table: "ShoppingLists");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ShoppingLists");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "ShoppingLists");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "ShoppingLists",
                newName: "ShoppingListId");
        }
    }
}
