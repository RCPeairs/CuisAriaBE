using Microsoft.EntityFrameworkCore;
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
        public DbSet<Item> Items { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Qty> Qtys { get; set; }
        public DbSet<Unit> Units { get; set; }
    }
}
