using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Products.AddImage
{
    public class AddProductImageCommandValidator : AbstractValidator<AddProductImageCommand>
    {
        public AddProductImageCommandValidator()
        {
            RuleFor(r => r.ImageFile)
                .NotNull().WithMessage(ValidationMessages.required("Image")).JustImageFile();

            RuleFor(r => r.Sequence)
                .GreaterThanOrEqualTo(1);
        }
    }
}