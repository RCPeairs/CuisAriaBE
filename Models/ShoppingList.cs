using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuisAriaBE.Models
{
    public class ShoppingList
    {
        public ShoppingList()
        {
            Items = new List<Item>();
        }

        public int Id { get; set; }
        public string ListName { get; set; }  //ListName included for future use in case we want to supprt multiple shopping lists per user in the future.

        public ICollection<Item> Items { get; set; }
        public User User { get; set; }
    }
}
