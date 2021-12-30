using System.ComponentModel.DataAnnotations;

namespace RecipeManagerWeb.Models
{
    public class InstructionStep
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public Recipe Recipe { get; set; }
    }
}
