using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Users.Register
{
    public class RegisterUserCommandValidaor : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidaor()
        {       
            RuleFor(r => r.Password)
                .NotEmpty().WithMessage(ValidationMessages.required("Password"))
                .NotNull().WithMessage(ValidationMessages.required("Password"))
                .MinimumLength(4).WithMessage("Password can not be less than 4 words!");
        }
    }
}