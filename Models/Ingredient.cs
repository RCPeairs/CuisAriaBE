using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuisAriaBE.Models
{
    public class Ingredient
    {
        public Ingredient()
        {
            StepIngredients = new List<StepIngredient>();
        }

        public int Id { get; set; }
        public string IngredName { get; set; }

       public ICollection<StepIngredient> StepIngredients { get; set; }
    }
}
