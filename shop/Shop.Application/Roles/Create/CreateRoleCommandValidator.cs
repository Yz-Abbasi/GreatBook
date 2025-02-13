using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Roles.Create
{
    public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleCommandValidator()
        {
            RuleFor(r => r.Title)
                .NotEmpty().WithMessage(ValidationMessages.required("Title"));
        }
    }
}