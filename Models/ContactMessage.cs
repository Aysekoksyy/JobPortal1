using System.ComponentModel.DataAnnotations;

namespace JobPortal1.Models
{
    public class ContactMessage
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Company { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        public string Phone { get; set; }

        [Required]
        public string Message { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
