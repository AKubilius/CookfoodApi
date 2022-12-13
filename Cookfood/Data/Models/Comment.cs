using System.ComponentModel.DataAnnotations;

namespace Cookfood.Data.Models
{
    public class Comment 
    { 
        public string? Commentator { get; set; }
        public string? Text { get; set; }
        public DateTime Date { get; set; }
        public int Id{ get; set; }
        public int FkRecepyid { get; set; }

    }
}
