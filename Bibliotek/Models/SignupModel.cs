using System.ComponentModel.DataAnnotations;

namespace Bibliotek.Models
{
    public class SignupModel
    {
        [Required(ErrorMessage = "This field is required")]
        [MaxLength(10, ErrorMessage = "Username cannot be longer than 10 symbols")]
        [MinLength(3, ErrorMessage = "Username cannot be shorter than 3 symbols")]
        public string Username { get; set; } = String.Empty;
        //-----------------------------------------------------------------------------------
        [Required(ErrorMessage = "This field is required")]
        public string Email { get; set; } = String.Empty;
        //-----------------------------------------------------------------------------------
        [Required(ErrorMessage = "This field is required")]
        public string Password { get; set; } = String.Empty;
        //-----------------------------------------------------------------------------------
        [Required(ErrorMessage = "This field is required")]
        [Compare(nameof(Password), ErrorMessage = "Password verification required")]
        public string VerifiedPassword { get; set; } = String.Empty;
    }
}
