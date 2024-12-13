

using System.ComponentModel.DataAnnotations;
using Common.Application.Validation;

namespace Shop.Api.ViewModels.Auth;
public class LoginViewModel
{
    [Required(ErrorMessage = "Enter the phone number!")]
    [MaxLength(11, ErrorMessage = ValidationMessages.InvalidPhoneNumber)]
    [MinLength(11, ErrorMessage = ValidationMessages.InvalidPhoneNumber)]
    public string PhoneNumber { get; set; }
    
    [Required(ErrorMessage = "Enter Password!")]
    public string Password { get; set; }
}