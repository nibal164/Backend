using FluentValidation;
using SoapLush.InputModels;

namespace SoapLush.Validators
{
    public class CreateSubCategoryRequestValidator: AbstractValidator<CreateSubCategoryInputModel>
    {
        public CreateSubCategoryRequestValidator() {
            RuleFor(x=> x.Name).NotEmpty();
            RuleFor(x=>x.CategoryId).NotNull();
        }
    }
}
