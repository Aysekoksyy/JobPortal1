namespace JobPortal1.Models
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterViewModel
    {
        [Required]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        public string Username { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, DataType(DataType.Password), Compare("Password")]
        public string RePassword { get; set; }
    }
}
