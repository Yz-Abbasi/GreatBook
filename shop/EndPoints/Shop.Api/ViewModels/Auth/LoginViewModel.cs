

using System.ComponentModel.DataAnnotations;
using Common.Application.Validation;

namespace Shop.Api.ViewModels.Auth
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Enter the phone number!")]
        [MaxLength(11, ErrorMessage = ValidationMessages.InvalidPhoneNumber)]
        [MinLength(11, ErrorMessage = ValidationMessages.InvalidPhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Enter Password!")]
        public string Password { get; set; }
    }
    
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Enter the phone number!")]
        [MaxLength(11, ErrorMessage = ValidationMessages.InvalidPhoneNumber)]
        [MinLength(11, ErrorMessage = ValidationMessages.InvalidPhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Enter Password!")]
        [MinLength(8, ErrorMessage = "Password can't be less than 8 characters")]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "Enter Password again!")]
        [MinLength(8, ErrorMessage = "Password can't be less than 8 characters")]
        [Compare(nameof(Password), ErrorMessage = "Passwords are not the same!")]
        public string ConfirmPassword { get; set; }
    }
}