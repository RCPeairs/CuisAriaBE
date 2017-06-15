using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuisAriaBE.Models
{
    public class User
    {

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }

        public ICollection<UserRecipeFavorite> UserRecipeFavorites { get; set; }
        public ICollection<ShoppingList> ShoppingLists { get; set; }
    }
}
