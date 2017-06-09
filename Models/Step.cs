using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuisAriaBE.Models
{
    public class Step
    {
        public int StepId { get; set; }
        public int RecipeId { get; set; }
        public int StepNumber { get; set; }
        public string Instruction { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}
