using FluentValidation;
using SoapLush.InputModels;

namespace SoapLush.Validators
{
    public class CreateCategoryRequestValidator: AbstractValidator<CreateCategoryInputModel>
    {
        public CreateCategoryRequestValidator()
        {
            RuleFor(x=> x.Name).NotEmpty();
            RuleFor(x=>x.Image).NotEmpty();
        }
    }
}
