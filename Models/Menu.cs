using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuisAriaBE.Models
{
    public class Menu
    {
        public int MenuId { get; set; }
        public int UserId { get; set; }
        public String Name { get; set; }

        public virtual  User User { get; set; }
    }
}
