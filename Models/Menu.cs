using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuisAriaBE.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public String Name { get; set; }

        public User User { get; set; }
        public ICollection<MenuRecipe> MenuRecipes { get; set; }
    }
}
