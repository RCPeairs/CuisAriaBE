using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuisAriaBE.ViewModels
{
    public class StepIngredientVM
    {
        public int StepId { get; set; }
        public int StepNumber { get; set; }
        public string Instruction { get; set; }

        public int IngredientId { get; set; }
        public string IngredName { get; set; }
    }
}
