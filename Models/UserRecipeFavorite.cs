using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuisAriaBE.Models
{
    public class UserRecipeFavorite
    {
        public int UserId { get; set; }
        public int RecipeId { get; set; }
        public bool Favorite { get; set; }

        public User User { get; set; }
        public Recipe Recipe { get; set; }
    }
}
