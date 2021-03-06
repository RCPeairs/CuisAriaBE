﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuisAriaBE.Models
{
    public class Step
    {
        public Step()
        {
            StepIngredients = new List<StepIngredient>();
        }

        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int StepNumber { get; set; }
        public string Instruction { get; set; }

        public Recipe Recipe { get; set; }
        public ICollection<StepIngredient> StepIngredients { get; set; }
    }
}
