using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CuisAriaBE.Models
{
    public class Item
    {
        public int Id { get; set; }
        public int ShoppingListId { get; set; }
        public string ItemName { get; set; }
        public decimal ItemQty { get; set; }
        public string ItemUnit { get; set; }

        public ShoppingList ShoppingLists { get; set; }
    }
}
