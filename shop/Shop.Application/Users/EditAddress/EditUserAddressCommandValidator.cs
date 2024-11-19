using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Users.EditAddress
{
    public class EditUserAddressCommandValidator : AbstractValidator<EditUserAddressCommand>
    {
        public EditUserAddressCommandValidator()
        {
            RuleFor(r => r.Name)
                .NotEmpty().WithMessage(ValidationMessages.required("Name"));

            RuleFor(r => r.City)
                .NotEmpty().WithMessage(ValidationMessages.required("City"));

            RuleFor(r => r.Province)
                .NotEmpty().WithMessage(ValidationMessages.required("Province"));

            RuleFor(r => r.Family)
                .NotEmpty().WithMessage(ValidationMessages.required("Family"));

            RuleFor(r => r.PostalCode)
                .NotEmpty().WithMessage(ValidationMessages.required("PostalCode"));

            RuleFor(r => r.PostalAddress)
                .NotEmpty().WithMessage(ValidationMessages.required("PostalAddress"));

            RuleFor(r => r.NationalCode)
                .NotEmpty().WithMessage(ValidationMessages.required("NationalCode"));
        }
    }
}