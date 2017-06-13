using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuisAriaBE.Models
{
    public class CuisAriaBEContext : DbContext
    {
        public CuisAriaBEContext(DbContextOptions<CuisAriaBEContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<Keyword> Keywords { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<ShoppingList> ShoppingLists { get; set; }
        public DbSet<MenuRecipe> MenuRecipe { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<RecipeKeyword> RecipeKeyword { get; set; }
        public DbSet<StepIngredient> StepIngredient { get; set; }
        public DbSet<UserRecipeFavorite> UserRecipeFavorite { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Recipe>().ToTable("Recipes");
            modelBuilder.Entity<Step>().ToTable("Steps");
            modelBuilder.Entity<Keyword>().ToTable("Keywords");
            modelBuilder.Entity<Menu>().ToTable("Menus");
            modelBuilder.Entity<ShoppingList>().ToTable("ShoppingLists");
            modelBuilder.Entity<MenuRecipe>().ToTable("MenuRecipe");
            modelBuilder.Entity<Ingredient>().ToTable("Ingredients");
            modelBuilder.Entity<RecipeKeyword>().ToTable("RecipeKeyword");
            modelBuilder.Entity<StepIngredient>().ToTable("StepIngredient");
            modelBuilder.Entity<UserRecipeFavorite>().ToTable("UserRecipeFavorite");

            //Establish dual keys for join tables
            modelBuilder.Entity<UserRecipeFavorite>()
                .HasKey(u => new { u.UserId, u.RecipeId });

            modelBuilder.Entity<StepIngredient>()
                .HasKey(u => new { u.StepId, u.IngredientId });

            modelBuilder.Entity<RecipeKeyword>()
                .HasKey(u => new { u.RecipeId, u.KeyWordId });

            modelBuilder.Entity<MenuRecipe>()
                .HasKey(u => new { u.MenuId, u.RecipeId });

            //Do not allow cascade deletes to insure there are no circular delete paths. May enable some cascade deletes on future review.
            modelBuilder.Entity<Menu>()
                .HasOne(m => m.User)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ShoppingList>()
                .HasOne(s => s.User)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserRecipeFavorite>()
                  .HasOne(u => u.User)
                  .WithMany()
                  .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserRecipeFavorite>()
                  .HasOne(u => u.Recipe)
                  .WithMany()
                  .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Step>()
                .HasOne(s => s.Recipe)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RecipeKeyword>()
                .HasOne(s => s.Recipe)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RecipeKeyword>()
               .HasOne(s => s.KeyWord)
               .WithMany()
               .OnDelete(DeleteBehavior.Restrict);
        }

    }

}
