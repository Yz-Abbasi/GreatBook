using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Shop.Application.Orders.AddItem
{
    public class AddOrderItemCommandValidator : AbstractValidator<AddOrderItemCommand>
    {
        public AddOrderItemCommandValidator()
        {
            RuleFor(r => r.Count)
                .GreaterThanOrEqualTo(1).WithMessage("Count should be bigger than 0!");
            RuleFor(r => r.UserId)
                .NotNull().WithMessage("UserId Can't be null");
        }
    }
}