using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuisAriaBE.Models
{
    public class RecipeKeyword
    {
        public int RecipeId { get; set; }
        public int KeywordId { get; set; }

        public Recipe Recipe { get; set; }
        public Keyword Keyword { get; set; }
    }
}
