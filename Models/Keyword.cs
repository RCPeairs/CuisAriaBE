using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuisAriaBE.Models
{
    public class Keyword
    {
        public Keyword()
        {
            RecipeKeywords = new List<RecipeKeyword>();
        }

        public int Id { get; set; }
        public string SearchWord { get; set; }

        public ICollection<RecipeKeyword> RecipeKeywords { get; set; }
    }
}
