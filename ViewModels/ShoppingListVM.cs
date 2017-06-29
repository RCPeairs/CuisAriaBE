using CuisAriaBE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuisAriaBE.ViewModels
{
    public class ShoppingListVM
    {
        public int ShoppingListId { get; set; }
        public int UserId { get; set; }
        public string ListName { get; set; }

        public List<ItemVM> Items { get; set; }
    }
}
