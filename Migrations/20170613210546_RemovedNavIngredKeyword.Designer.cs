using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CuisAriaBE.Models;

namespace CuisAriaBE.Migrations
{
    [DbContext(typeof(CuisAriaBEContext))]
    [Migration("20170613210546_RemovedNavIngredKeyword")]
    partial class RemovedNavIngredKeyword
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

                    b.Property<int>("ItemQty");

                    b.Property<string>("ItemUnit");

                    b.Property<int?>("ShoppingListId");

                    b.HasKey("Id");

                    b.HasIndex("ShoppingListId");

                    b.ToTable("Item");
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

                    b.Property<string>("Name");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("CuisAriaBE.Models.MenuRecipe", b =>
                {
                    b.Property<int>("MenuId");

                    b.Property<int>("RecipeId");

                    b.Property<int>("Servings");

                    b.HasKey("MenuId", "RecipeId");

                    b.HasIndex("RecipeId");

                    b.ToTable("MenuRecipe");
                });

            modelBuilder.Entity("CuisAriaBE.Models.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("MyRating");

                    b.Property<string>("Name");

                    b.Property<string>("Notes");

                    b.Property<int>("NumShareRatings");

                    b.Property<int>("OwnerId");

                    b.Property<string>("RecipePic");

                    b.Property<int>("ShareRating");

                    b.Property<bool>("Shared");

                    b.HasKey("Id");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("CuisAriaBE.Models.RecipeKeyword", b =>
                {
                    b.Property<int>("RecipeId");

                    b.Property<int>("KeyWordId");

                    b.Property<int?>("RecipeId1");

                    b.HasKey("RecipeId", "KeyWordId");

                    b.HasIndex("KeyWordId");

                    b.HasIndex("RecipeId1");

                    b.ToTable("RecipeKeyword");
                });

            modelBuilder.Entity("CuisAriaBE.Models.ShoppingList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ListName");

                    b.Property<int?>("UserId");

                    b.Property<int?>("UserId1");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("UserId1");

                    b.ToTable("ShoppingLists");
                });

            modelBuilder.Entity("CuisAriaBE.Models.Step", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Instruction");

                    b.Property<int?>("RecipeId");

                    b.Property<int?>("RecipeId1");

                    b.Property<int>("StepNumber");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.HasIndex("RecipeId1");

                    b.ToTable("Steps");
                });

            modelBuilder.Entity("CuisAriaBE.Models.StepIngredient", b =>
                {
                    b.Property<int>("StepId");

                    b.Property<int>("IngredientId");

                    b.Property<int>("IngredQty");

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

                    b.Property<int?>("RecipeId1");

                    b.Property<int?>("UserId1");

                    b.HasKey("UserId", "RecipeId");

                    b.HasIndex("RecipeId");

                    b.HasIndex("RecipeId1");

                    b.HasIndex("UserId1");

                    b.ToTable("UserRecipeFavorite");
                });

            modelBuilder.Entity("CuisAriaBE.Models.Item", b =>
                {
                    b.HasOne("CuisAriaBE.Models.ShoppingList")
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
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CuisAriaBE.Models.Recipe", "Recipe")
                        .WithMany()
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CuisAriaBE.Models.RecipeKeyword", b =>
                {
                    b.HasOne("CuisAriaBE.Models.Keyword", "KeyWord")
                        .WithMany()
                        .HasForeignKey("KeyWordId");

                    b.HasOne("CuisAriaBE.Models.Recipe", "Recipe")
                        .WithMany()
                        .HasForeignKey("RecipeId");

                    b.HasOne("CuisAriaBE.Models.Recipe")
                        .WithMany("RecipeKeyWords")
                        .HasForeignKey("RecipeId1");
                });

            modelBuilder.Entity("CuisAriaBE.Models.ShoppingList", b =>
                {
                    b.HasOne("CuisAriaBE.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.HasOne("CuisAriaBE.Models.User")
                        .WithMany("ShoppingLists")
                        .HasForeignKey("UserId1");
                });

            modelBuilder.Entity("CuisAriaBE.Models.Step", b =>
                {
                    b.HasOne("CuisAriaBE.Models.Recipe", "Recipe")
                        .WithMany()
                        .HasForeignKey("RecipeId");

                    b.HasOne("CuisAriaBE.Models.Recipe")
                        .WithMany("Steps")
                        .HasForeignKey("RecipeId1");
                });

            modelBuilder.Entity("CuisAriaBE.Models.StepIngredient", b =>
                {
                    b.HasOne("CuisAriaBE.Models.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CuisAriaBE.Models.Step", "Step")
                        .WithMany("StepIngredients")
                        .HasForeignKey("StepId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CuisAriaBE.Models.UserRecipeFavorite", b =>
                {
                    b.HasOne("CuisAriaBE.Models.Recipe", "Recipe")
                        .WithMany()
                        .HasForeignKey("RecipeId");

                    b.HasOne("CuisAriaBE.Models.Recipe")
                        .WithMany("UserRecipeFavorites")
                        .HasForeignKey("RecipeId1");

                    b.HasOne("CuisAriaBE.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.HasOne("CuisAriaBE.Models.User")
                        .WithMany("UserRecipeFavorites")
                        .HasForeignKey("UserId1");
                });
        }
    }
}
