﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CuisAriaBE.Models;

namespace CuisAriaBE.Migrations
{
    [DbContext(typeof(CuisAriaBEContext))]
    [Migration("20170612193348_UserRecipeFavoriteJoin20")]
    partial class UserRecipeFavoriteJoin20
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CuisAriaBE.Models.Ingredient", b =>
                {
                    b.Property<int>("IngredientId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("IngredName");

                    b.HasKey("IngredientId");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("CuisAriaBE.Models.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ItemName");

                    b.Property<int>("ItemQty");

                    b.HasKey("ItemId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("CuisAriaBE.Models.Keyword", b =>
                {
                    b.Property<int>("KeywordId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("SearchWord");

                    b.HasKey("KeywordId");

                    b.ToTable("Keywords");
                });

            modelBuilder.Entity("CuisAriaBE.Models.Menu", b =>
                {
                    b.Property<int>("MenuId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("MenuId");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("CuisAriaBE.Models.Qty", b =>
                {
                    b.Property<int>("QtyId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("IngredQty");

                    b.HasKey("QtyId");

                    b.ToTable("Qtys");
                });

            modelBuilder.Entity("CuisAriaBE.Models.ShoppingList", b =>
                {
                    b.Property<int>("ShoppingListId")
                        .ValueGeneratedOnAdd();

                    b.HasKey("ShoppingListId");

                    b.ToTable("ShoppingLists");
                });

            modelBuilder.Entity("CuisAriaBE.Models.Step", b =>
                {
                    b.Property<int>("StepId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Instruction");

                    b.Property<int>("StepNumber");

                    b.HasKey("StepId");

                    b.ToTable("Steps");
                });

            modelBuilder.Entity("CuisAriaBE.Models.Unit", b =>
                {
                    b.Property<int>("UnitId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("UnitName");

                    b.HasKey("UnitId");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("CuisAriaBE.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Avatar");

                    b.Property<string>("Email");

                    b.Property<string>("Password");

                    b.Property<string>("UserName");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });
        }
    }
}
