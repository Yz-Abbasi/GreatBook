using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Users.ChargeWallet
{
    public class ChargeUserWalletCommandValidator : AbstractValidator<ChargeUserWalletCommand>
    {
        public ChargeUserWalletCommandValidator()
        {
            RuleFor(r => r.Description)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.required("Description"));
                
            RuleFor(r => r.Price)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.required("Price"))
                .GreaterThan(1000);
        }
    }
}