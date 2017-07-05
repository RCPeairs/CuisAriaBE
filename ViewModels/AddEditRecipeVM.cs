using CuisAriaBE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuisAriaBE.ViewModels
{
    public class AddEditRecipeVM
    {
        public UserRecipeFavorite userRecipeFavorite { get; set; }
        public RecipeVM recipe { get; set; }
        public List<RecipeStepIngredientVM> RecipeStepIngredients { get; set; }
        public List<IngredientListVM> IngredientList { get; set; }
        public List<Keyword> Keywords { get; set; }
    }
}
