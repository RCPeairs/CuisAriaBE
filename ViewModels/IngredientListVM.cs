using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuisAriaBE.Models
{
    public class IngredientListVM
    {
        public int? IngredientId { get; set; }
        public string IngredName { get; set; }
        public decimal? IngredQty { get; set; }
        public string IngredUnit { get; set; }
    }
}
