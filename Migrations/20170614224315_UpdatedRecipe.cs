using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CuisAriaBE.Migrations
{
    public partial class UpdatedRecipe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CookTime",
                table: "Recipes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PrepTime",
                table: "Recipes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Servings",
                table: "Recipes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CookTime",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "PrepTime",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "Servings",
                table: "Recipes");
        }
    }
}
