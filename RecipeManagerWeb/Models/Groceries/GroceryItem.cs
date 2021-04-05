using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeManagerWeb.Models.Groceries
{
    public class GroceryItem
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public GroceryCategory GroceryCategory { get; set; }
    }
}
