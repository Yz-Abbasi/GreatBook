using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Users.Create
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(r => r.Name)
                .NotEmpty().WithMessage(ValidationMessages.required("Name"))
                .NotNull().WithMessage(ValidationMessages.required("Name"));
                
            RuleFor(r => r.LastName)
                .NotEmpty().WithMessage(ValidationMessages.required("Last name"))
                .NotNull().WithMessage(ValidationMessages.required("Last name"));
                
            RuleFor(r => r.PhoneNumber)
                .ValidPhoneNumber("Phone number is not valid!");
                
            RuleFor(r => r.Password)
                .NotEmpty().WithMessage(ValidationMessages.required("Password"))
                .NotNull().WithMessage(ValidationMessages.required("Password"))
                .MinimumLength(4).WithMessage("Password can not be less than 4 words!");
        }    
    }
}