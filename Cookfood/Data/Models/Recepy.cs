using System.ComponentModel.DataAnnotations;

namespace Cookfood.Data.Models
{
    public class Recepy
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
       
        public int Duration { get; set; }
        public DateTime UploadDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool? Confirmed { get; set; }
        public double? Rating { get; set; }
        public int Id { get; set; }
        public int RecepySetId { get; set; }
    }
}
