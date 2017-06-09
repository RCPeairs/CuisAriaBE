using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuisAriaBE.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        //public ICollection<UserFavorite> UserFavorites { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }
        public virtual ICollection<ShoppingList> ShoppingLists { get; set; }
    }
}
