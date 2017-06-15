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
        public string ItemName { get; set; }
        public int ItemQty { get; set; }
        public string ItemUnit { get; set; }

    }
}
