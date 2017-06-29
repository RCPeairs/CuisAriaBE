using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuisAriaBE.ViewModels
{
    public class RecipeKeywordVM
    {

        public int KeywordId { get; set; }
        public string SearchWord { get; set; }

        public int RecipeId { get; set; }
        public string RecipeName { get; set; }
        public string Description { get; set; }
        public int OwnerId { get; set; }
        public bool Shared { get; set; }
        public string Notes { get; set; }
        public int MyRating { get; set; }
        public decimal ShareRating { get; set; }
        public decimal NumShareRatings { get; set; }
        public string RecipePic { get; set; }
        public decimal PrepTime { get; set; }
        public decimal CookTime { get; set; }
        public decimal Servings { get; set; }
    }
}
