using System.ComponentModel.DataAnnotations;

namespace LearningCenterWebsite.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Please enter your email")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm your password")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        public bool ArePasswordsSame()
        {
            return Password == ConfirmPassword;
        }
    }
}
