using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CuisAriaBE.Migrations
{
    public partial class ChangedCurrentMenuBit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentMenu",
                table: "MenuRecipe");

            migrationBuilder.AddColumn<bool>(
                name: "CurrentMenu",
                table: "Menus",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentMenu",
                table: "Menus");

            migrationBuilder.AddColumn<bool>(
                name: "CurrentMenu",
                table: "MenuRecipe",
                nullable: false,
                defaultValue: false);
        }
    }
}
