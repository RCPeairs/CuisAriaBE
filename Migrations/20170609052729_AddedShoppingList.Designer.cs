﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CuisAriaBE.Models;

namespace CuisAriaBE.Migrations
{
    [DbContext(typeof(CuisAriaBEContext))]
    [Migration("20170609052729_AddedShoppingList")]
    partial class AddedShoppingList
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.Property<int>("UserId");

                    b.HasKey("MenuId");

                    b.HasIndex("UserId");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("CuisAriaBE.Models.Recipe", b =>
                {
                    b.Property<int>("RecipeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("MyRating");

                    b.Property<string>("Name");

                    b.Property<string>("Notes");

                    b.Property<int>("NumShareRatings");

                    b.Property<int>("OwnerId");

                    b.Property<int>("ShareRating");

                    b.Property<bool>("Shared");

                    b.Property<int>("UserId");

                    b.HasKey("RecipeId");

                    b.HasIndex("UserId");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("CuisAriaBE.Models.ShoppingList", b =>
                {
                    b.Property<int>("ShoppingListId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("UserId");

                    b.HasKey("ShoppingListId");

                    b.HasIndex("UserId");

                    b.ToTable("ShoppingLists");
                });

            modelBuilder.Entity("CuisAriaBE.Models.Step", b =>
                {
                    b.Property<int>("StepId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Instruction");

                    b.Property<int>("RecipeId");

                    b.Property<int>("StepNumber");

                    b.HasKey("StepId");

                    b.HasIndex("RecipeId");

                    b.ToTable("Steps");
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

            modelBuilder.Entity("CuisAriaBE.Models.Menu", b =>
                {
                    b.HasOne("CuisAriaBE.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CuisAriaBE.Models.Recipe", b =>
                {
                    b.HasOne("CuisAriaBE.Models.User", "User")
                        .WithMany("Recipes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CuisAriaBE.Models.ShoppingList", b =>
                {
                    b.HasOne("CuisAriaBE.Models.User", "User")
                        .WithMany("ShoppingLists")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CuisAriaBE.Models.Step", b =>
                {
                    b.HasOne("CuisAriaBE.Models.Recipe", "Recipe")
                        .WithMany("Steps")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}