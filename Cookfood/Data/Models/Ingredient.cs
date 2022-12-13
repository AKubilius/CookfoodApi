using Cookfood.Auth.Model;
using System.ComponentModel.DataAnnotations;

namespace Cookfood.Data.Models
{
    public class Ingredient : IUserOwnedResource
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public double Quanity { get; set; }
        [Required]
        public string Measurement { get; set; } 
        [Required]
        public int Id { get; set; }
        [Required]
        public int RecepyId { get; set; }
        public string? UserId { get; set; } = null;
        public User? User { get; set; } = null;
    }
}
