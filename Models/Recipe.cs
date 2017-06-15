using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuisAriaBE.Models
{
    public class Recipe
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int OwnerId { get; set; }
        public bool Shared { get; set; }
        public string Notes { get; set; }
        public int MyRating { get; set; }
        public int ShareRating { get; set; }
        public int NumShareRatings { get; set; }
        public string RecipePic { get; set; }
        public int PrepTime { get; set; }
        public int CookTime { get; set; }
        public int Servings { get; set; }

        public ICollection<UserRecipeFavorite> UserRecipeFavorites { get; set; }
        public ICollection<Step> Steps { get; set; }
        public ICollection<RecipeKeyword> RecipeKeyWords { get; set; }
    }
}
