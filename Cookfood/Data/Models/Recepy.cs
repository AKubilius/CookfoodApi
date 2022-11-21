﻿using Cookfood.Auth.Model;
using System.ComponentModel.DataAnnotations;

namespace Cookfood.Data.Models
{
    public class Recepy : IUserOwnedResource
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

        public string? UserId { get; set; } = null;
        public User? User { get; set; } = null;
    }
}
