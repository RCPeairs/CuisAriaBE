using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuisAriaBE.Models
{
    public class ShoppingList
    {
        public int ShoppingListId { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
