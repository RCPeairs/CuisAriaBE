using CuisAriaBE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuisAriaBE.ViewModels
{
    public class RecipeStepIngredientVM
    {
        public int RecipeId { get; set; }
       
        public int StepId { get; set; }
        public int StepNumber { get; set; }
        public string Instruction { get; set; }

        public List<IngredientListVM> IngredientList { get; set; }

    }
}
