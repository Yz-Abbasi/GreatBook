using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Users.Edit;

public class EditUserCommandValidator : AbstractValidator<EditUserCommand>
{
    public EditUserCommandValidator()
    {
        RuleFor(r => r.Name)
            .NotEmpty().WithMessage(ValidationMessages.required("Name"))
            .NotNull().WithMessage(ValidationMessages.required("Name"));
            
        RuleFor(r => r.LastName)
            .NotEmpty().WithMessage(ValidationMessages.required("Last name"))
            .NotNull().WithMessage(ValidationMessages.required("Last name"));
            
        RuleFor(r => r.PhoneNumber)
            .ValidPhoneNumber("Phone number is not valid!");
        
    }
}