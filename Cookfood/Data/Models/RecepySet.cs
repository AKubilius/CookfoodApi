using System.ComponentModel.DataAnnotations;

namespace Cookfood.Data.Models
{
    public class RecepySet
    {
        public string Name { get; set; } = null!;
        public string Type { get; set; } = null!;
        public int Id { get; set; }
        public int UserId{ get; set; }
        public User User { get; set; }
        

    }
}
