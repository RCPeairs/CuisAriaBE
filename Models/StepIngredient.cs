using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuisAriaBE.Models
{
    public class StepIngredient
    {
        public int StepId { get; set; }
        public int IngredientId { get; set; }
        public decimal IngredQty { get; set; }
        public string IngredUnit { get; set; }

        public Step Step { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
