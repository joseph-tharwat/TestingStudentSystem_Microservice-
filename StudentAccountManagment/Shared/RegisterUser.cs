using System.ComponentModel.DataAnnotations;

namespace StudentAccountManagment.Shared
{
    public class RegisterUser
    {
        [Required(ErrorMessage ="Name is required")]
        public string? Name { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="Write a correct email.")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
