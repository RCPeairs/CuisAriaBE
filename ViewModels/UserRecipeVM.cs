﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CuisAriaBE.Models;

namespace CuisAriaBE.ViewModels
{
    public class UserRecipeVM
    {
        //public User User { get; set; }
        //public ICollection<Recipe> Recipes { get; set; }
        //public UserRecipeFavorite UserRecipeFavorite { get; set; }

        //public string UserName { get; set; }
        public int UserId { get; set; }

        public bool Favorite { get; set; }

        public int RecipeId { get; set; }
        public string RecipeName { get; set; }
        public string Description { get; set; }
        public int OwnerId { get; set; }
        public bool Shared { get; set; }
        public string Notes { get; set; }
        public int MyRating { get; set; }
        public decimal ShareRating { get; set; }
        public decimal NumShareRatings { get; set; }
        public string RecipePic { get; set; }
        public decimal PrepTime { get; set; }
        public decimal CookTime { get; set; }
        public decimal RecipeServings { get; set; }
        public string ServingSize { get; set; }
    }
}
