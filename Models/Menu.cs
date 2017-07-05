using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuisAriaBE.Models
{
    public class Menu
    {
        public Menu()
        {
            MenuRecipes = new List<MenuRecipe>();
        }
        public int Id { get; set; }
        public int UserId { get; set; }
        public String MenuName { get; set; }
        public bool CurrentMenu { get; set; }

        public User User { get; set; }
        public ICollection<MenuRecipe> MenuRecipes { get; set; }
    }
}
