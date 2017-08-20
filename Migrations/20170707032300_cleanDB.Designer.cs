using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CuisAriaBE.Models;

namespace CuisAriaBE.Migrations
{
    [DbContext(typeof(CuisAriaBEContext))]
    [Migration("20170707032300_cleanDB")]
    partial class cleanDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CuisAriaBE.Models.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("IngredName");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("CuisAriaBE.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ItemName");

                    b.Property<decimal>("ItemQty");

                    b.Property<string>("ItemUnit");

                    b.Property<int>("ShoppingListId");

                    b.HasKey("Id");

                    b.HasIndex("ShoppingListId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("CuisAriaBE.Models.Keyword", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("SearchWord");

                    b.HasKey("Id");

                    b.ToTable("Keywords");
                });

            modelBuilder.Entity("CuisAriaBE.Models.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("CurrentMenu");

                    b.Property<string>("MenuName");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("CuisAriaBE.Models.MenuRecipe", b =>
                {
                    b.Property<int>("MenuId");

                    b.Property<int>("RecipeId");

                    b.Property<decimal>("MenuServings");

                    b.HasKey("MenuId", "RecipeId");

                    b.HasIndex("RecipeId");

                    b.ToTable("MenuRecipe");
                });

            modelBuilder.Entity("CuisAriaBE.Models.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("CookTime");

                    b.Property<string>("Description");

                    b.Property<int>("MyRating");

                    b.Property<string>("Notes");

                    b.Property<decimal>("NumShareRatings");

                    b.Property<int>("OwnerId");

                    b.Property<decimal>("PrepTime");

                    b.Property<string>("RecipeName");

                    b.Property<string>("RecipePic");

                    b.Property<decimal>("RecipeServings");

                    b.Property<string>("ServingSize");

                    b.Property<decimal>("ShareRating");

                    b.Property<bool>("Shared");

                    b.HasKey("Id");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("CuisAriaBE.Models.RecipeKeyword", b =>
                {
                    b.Property<int>("RecipeId");

                    b.Property<int>("KeywordId");

                    b.HasKey("RecipeId", "KeywordId");

                    b.HasIndex("KeywordId");

                    b.ToTable("RecipeKeyword");
                });

            modelBuilder.Entity("CuisAriaBE.Models.ShoppingList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ListName");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ShoppingLists");
                });

            modelBuilder.Entity("CuisAriaBE.Models.Step", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Instruction");

                    b.Property<int>("RecipeId");

                    b.Property<int>("StepNumber");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("Steps");
                });

            modelBuilder.Entity("CuisAriaBE.Models.StepIngredient", b =>
                {
                    b.Property<int>("StepId");

                    b.Property<int>("IngredientId");

                    b.Property<decimal>("IngredQty");

                    b.Property<string>("IngredUnit");

                    b.HasKey("StepId", "IngredientId");

                    b.HasIndex("IngredientId");

                    b.ToTable("StepIngredient");
                });

            modelBuilder.Entity("CuisAriaBE.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Avatar");

                    b.Property<string>("Email");

                    b.Property<string>("Password");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CuisAriaBE.Models.UserRecipeFavorite", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RecipeId");

                    b.Property<bool>("Favorite");

                    b.HasKey("UserId", "RecipeId");

                    b.HasIndex("RecipeId");

                    b.ToTable("UserRecipeFavorite");
                });

            modelBuilder.Entity("CuisAriaBE.Models.Item", b =>
                {
                    b.HasOne("CuisAriaBE.Models.ShoppingList", "ShoppingLists")
                        .WithMany("Items")
                        .HasForeignKey("ShoppingListId");
                });

            modelBuilder.Entity("CuisAriaBE.Models.Menu", b =>
                {
                    b.HasOne("CuisAriaBE.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("CuisAriaBE.Models.MenuRecipe", b =>
                {
                    b.HasOne("CuisAriaBE.Models.Menu", "Menu")
                        .WithMany("MenuRecipes")
                        .HasForeignKey("MenuId");

                    b.HasOne("CuisAriaBE.Models.Recipe", "Recipe")
                        .WithMany()
                        .HasForeignKey("RecipeId");
                });

            modelBuilder.Entity("CuisAriaBE.Models.RecipeKeyword", b =>
                {
                    b.HasOne("CuisAriaBE.Models.Keyword", "Keyword")
                        .WithMany("RecipeKeywords")
                        .HasForeignKey("KeywordId");

                    b.HasOne("CuisAriaBE.Models.Recipe", "Recipe")
                        .WithMany("RecipeKeywords")
                        .HasForeignKey("RecipeId");
                });

            modelBuilder.Entity("CuisAriaBE.Models.ShoppingList", b =>
                {
                    b.HasOne("CuisAriaBE.Models.User", "User")
                        .WithMany("ShoppingLists")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("CuisAriaBE.Models.Step", b =>
                {
                    b.HasOne("CuisAriaBE.Models.Recipe", "Recipe")
                        .WithMany("Steps")
                        .HasForeignKey("RecipeId");
                });

            modelBuilder.Entity("CuisAriaBE.Models.StepIngredient", b =>
                {
                    b.HasOne("CuisAriaBE.Models.Ingredient", "Ingredient")
                        .WithMany("StepIngredients")
                        .HasForeignKey("IngredientId");

                    b.HasOne("CuisAriaBE.Models.Step", "Step")
                        .WithMany("StepIngredients")
                        .HasForeignKey("StepId");
                });

            modelBuilder.Entity("CuisAriaBE.Models.UserRecipeFavorite", b =>
                {
                    b.HasOne("CuisAriaBE.Models.Recipe", "Recipe")
                        .WithMany("UserRecipeFavorites")
                        .HasForeignKey("RecipeId");

                    b.HasOne("CuisAriaBE.Models.User", "User")
                        .WithMany("UserRecipeFavorites")
                        .HasForeignKey("UserId");
                });
        }
    }
}
