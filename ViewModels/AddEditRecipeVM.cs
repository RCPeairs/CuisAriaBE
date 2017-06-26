using CuisAriaBE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuisAriaBE.ViewModels
{
    public class AddEditRecipeVM
    {
        //public int UserId { get; set; }
        //public int RecipeId { get; set; }
        //public bool Favorite { get; set; }

        //public string RecipeName { get; set; }
        //public string Description { get; set; }
        //public int OwnerId { get; set; }
        //public bool Shared { get; set; }
        //public string Notes { get; set; }
        //public int MyRating { get; set; }
        //public int ShareRating { get; set; }
        //public int NumShareRatings { get; set; }
        //public string RecipePic { get; set; }
        //public int PrepTime { get; set; }
        //public int CookTime { get; set; }
        //public int RecipeServings { get; set; }
        //public string ServingSize { get; set; }

        //public int StepId { get; set; }
        //public int StepNumber { get; set; }
        //public string Instruction { get; set; }

        //public int IngredientId { get; set; }
        //public decimal? IngredQty { get; set; }
        //public string IngredUnit { get; set; }

        //public string IngredName { get; set; }

        //public int KeywordId { get; set; }
        //public string SearchWord { get; set; }

        public UserRecipeFavorite userRecipeFavorite { get; set; }
        public RecipeVM recipe { get; set; }
        public List<RecipeStepIngredientVM> RecipeStepIngredients { get; set; }
        public List<IngredientListVM> IngredientList { get; set; }
        public List<Keyword> Keywords { get; set; }
    }
}
