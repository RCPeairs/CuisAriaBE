using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CuisAriaBE.Migrations
{
    public partial class StepIngredientJoin2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Steps_Recipes_RecipeId",
                table: "Steps");

            migrationBuilder.AddColumn<int>(
                name: "RecipeId1",
                table: "Steps",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StepIngredient",
                columns: table => new
                {
                    StepId = table.Column<int>(nullable: false),
                    IngredientId = table.Column<int>(nullable: false),
                    IngredQty = table.Column<int>(nullable: false),
                    IngredUnit = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StepIngredient", x => new { x.StepId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_StepIngredient_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StepIngredient_Steps_StepId",
                        column: x => x.StepId,
                        principalTable: "Steps",
                        principalColumn: "StepId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Steps_RecipeId1",
                table: "Steps",
                column: "RecipeId1");

            migrationBuilder.CreateIndex(
                name: "IX_StepIngredient_IngredientId",
                table: "StepIngredient",
                column: "IngredientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Steps_Recipes_RecipeId",
                table: "Steps",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Steps_Recipes_RecipeId1",
                table: "Steps",
                column: "RecipeId1",
                principalTable: "Recipes",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Steps_Recipes_RecipeId",
                table: "Steps");

            migrationBuilder.DropForeignKey(
                name: "FK_Steps_Recipes_RecipeId1",
                table: "Steps");

            migrationBuilder.DropTable(
                name: "StepIngredient");

            migrationBuilder.DropIndex(
                name: "IX_Steps_RecipeId1",
                table: "Steps");

            migrationBuilder.DropColumn(
                name: "RecipeId1",
                table: "Steps");

            migrationBuilder.AddForeignKey(
                name: "FK_Steps_Recipes_RecipeId",
                table: "Steps",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
