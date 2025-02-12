using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Orders.Checkout
{
    public class CheckoutOrderCommandValidator : AbstractValidator<CheckoutOrderCommand>
    {
        public CheckoutOrderCommandValidator()
        {
            RuleFor(r => r.Name)
                .NotEmpty().NotNull().WithMessage(ValidationMessages.required("Name"));

            RuleFor(r => r.Family)
                .NotEmpty().NotNull().WithMessage(ValidationMessages.required("Last Name"));

            RuleFor(r => r.City)
                .NotEmpty().NotNull().WithMessage(ValidationMessages.required("City"));

            RuleFor(r => r.Province)
                .NotEmpty().NotNull().WithMessage(ValidationMessages.required("Province"));

            RuleFor(r => r.PhoneNumber)
                .NotEmpty().NotNull().WithMessage(ValidationMessages.required("PhoneNumber")).MaximumLength(11).WithMessage("Phone number is invalid!")
                .MinimumLength(11).WithMessage("Phone number is invalid!");

            RuleFor(r => r.NationalCode)
                .NotEmpty().NotNull().WithMessage(ValidationMessages.required("NationalCode")).MaximumLength(10).WithMessage("National Code is invalid!")
                .MinimumLength(9).WithMessage("National Code is invalid!");

            RuleFor(r => r.PostalAddress)
                .NotEmpty().NotNull().WithMessage(ValidationMessages.required("PostalAddress"));
                
            RuleFor(r => r.PostalCode)
                .NotEmpty().NotNull().WithMessage(ValidationMessages.required("PostalCode"));
        }
    }
}