using System.ComponentModel.DataAnnotations;

namespace Cookfood.Data.Models
{
    public class Ingredient
    {
        public string Name { get; set; } = null!;
        public double Quanity { get; set; }
        public string Measurement { get; set; } = null!;
        public int Id { get; set; }

    }
}
