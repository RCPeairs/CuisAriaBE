using CuisAriaBE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuisAriaBE.ViewModels
{
    public class AddEditMenuVM
    {
        public int MenuId { get; set; }
        public int UserId { get; set; }
        public String MenuName { get; set; }

        public List<MenuRecipe> menuRecipes { get; set; }

    }
}
