using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuisAriaBE.Models
{
    public class RecipeKeyword
    {
        public int RecipeId { get; set; }
        public int KeyWordId { get; set; }

        public Recipe Recipe { get; set; }
        public Keyword KeyWord { get; set; }
    }
}
