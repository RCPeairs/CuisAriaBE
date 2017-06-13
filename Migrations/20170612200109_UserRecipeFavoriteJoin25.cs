using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CuisAriaBE.Migrations
{
    public partial class UserRecipeFavoriteJoin25 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "UserRecipeFavorite",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRecipeFavorite_UserId1",
                table: "UserRecipeFavorite",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRecipeFavorite_Users_UserId1",
                table: "UserRecipeFavorite",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRecipeFavorite_Users_UserId1",
                table: "UserRecipeFavorite");

            migrationBuilder.DropIndex(
                name: "IX_UserRecipeFavorite_UserId1",
                table: "UserRecipeFavorite");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserRecipeFavorite");
        }
    }
}
