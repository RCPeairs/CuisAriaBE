using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuisAriaBE.Models
{
    public class MenuRecipe
    {
        public int MenuId { get; set; }
        public int RecipeId { get; set; }
        public int MenuServings { get; set; }

        public Menu Menu { get; set; }
        public Recipe Recipe { get; set; }
    }
}
