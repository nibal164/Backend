using FluentValidation;
using SoapLush.InputModels;

namespace SoapLush.Validators
{
    public class UpdateCategoryRequestValidator: AbstractValidator<UpdateCategoryInputModel>
    {
        public UpdateCategoryRequestValidator() {

            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Image).NotEmpty();
        }
    }
}
