using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.SiteEntities.Banners.Edit
{
    public class EditBannerCommandValidator : AbstractValidator<EditBannerCommand>
    {
        public EditBannerCommandValidator()
        {
            RuleFor(r => r.ImageFile)
                .JustImageFile("Only images are accepted!");

            RuleFor(r => r.Link)
                .NotNull()
                .NotEmpty().WithMessage(ValidationMessages.required("Image"));
            
        }
    }
}