using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CuisAriaBE.Models
{
    public class ShoppingList
    {
        [Key]
        public int ItemId { get; set; }
        public int UserId { get; set; }
        public string ListName { get; set; }  //ListName included for future use in case we want to supprt multiple shopping lists per user in the future. 
        public string ItemName { get; set; }
        public int ItemQty { get; set; }
        public string ItemUnit { get; set; }

        public User User { get; set; }
    }
}
