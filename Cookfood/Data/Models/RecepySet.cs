using Cookfood.Auth.Model;
using System.ComponentModel.DataAnnotations;

namespace Cookfood.Data.Models
{
    public class RecepySet : IUserOwnedResource
    {
        [Required]
        public string Name { get; set; }
        public string Type { get; set; } = null!;
        [Required]
        public int Id { get; set; }
        public string? UserId { get; set; } = null;
        public User? User { get; set; } = null;
        

    }
}
