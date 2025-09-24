using System.ComponentModel.DataAnnotations;

namespace StudentAccountManagment.Shared
{
    public class LoginUser
    {
        [Required]
        [EmailAddress(ErrorMessage = "Write a correct email.")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
