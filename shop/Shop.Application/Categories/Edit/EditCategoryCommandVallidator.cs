using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Categories.Edit
{
    public class EditCategoryCommandVallidator : AbstractValidator<EditCategoryCommand>
    {        
        public EditCategoryCommandVallidator()
        {
            RuleFor(r => r.Title)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.required("Title"));
                
            RuleFor(r => r.Slug)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.required("Slug"));
        }
        
    }
}