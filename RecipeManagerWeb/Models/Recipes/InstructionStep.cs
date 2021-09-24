using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeManagerWeb.Models.Recipes
{
    public class InstructionStep
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public Recipe Recipe { get; set; }
    }
}
