using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeManagerWeb.Models
{
    public class InstructionStep
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public int RecipeId { get; set; }
        [ForeignKey("RecipeId")]
        public Recipe Recipe { get; set; } = null!;
    }
}
