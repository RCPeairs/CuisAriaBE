using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuisAriaBE.Models
{
    public class Recipe
    {
        public Recipe()
        {
            UserRecipeFavorites = new List<UserRecipeFavorite>();
            Steps = new List<Step>();
            RecipeKeywords = new List<RecipeKeyword>();
        }

        public int Id { get; set; }
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
        public decimal RecipeServings { get; set; }
        public string ServingSize { get; set; }

        public ICollection<UserRecipeFavorite> UserRecipeFavorites { get; set; }
        public ICollection<Step> Steps { get; set; }
        public ICollection<RecipeKeyword> RecipeKeywords { get; set; }
    }
}
