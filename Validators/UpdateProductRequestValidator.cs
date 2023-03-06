using FluentValidation;
using SoapLush.InputModels;

namespace SoapLush.Validators
{
    public class UpdateProductRequestValidator: AbstractValidator<UpdateProductInputModel>
    {
        public UpdateProductRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Price).NotNull();
            RuleFor(x => x.Image).NotEmpty();
            RuleFor(x => x.CategoryId).NotNull();
        }
    }
}
