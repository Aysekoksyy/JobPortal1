using System;
using System.ComponentModel.DataAnnotations;

namespace JobPortal1.Models
{
    public class JobPost
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public string? Location { get; set; }

        [Required]
        public string WorkplaceType { get; set; }

        public string? Salary { get; set; }

        public string? Tags { get; set; }

        public string? FilePath { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
