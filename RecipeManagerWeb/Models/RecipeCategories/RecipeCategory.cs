using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeManagerWeb.Models.RecipeCategories
{
    public class RecipeCategory
    {
        [Key]
        public int Id { get; set; }
        public string Abbreviation { get; set; }
        public string Name { get; set; }
    }
}
