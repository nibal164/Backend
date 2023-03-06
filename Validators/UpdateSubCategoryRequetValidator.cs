using FluentValidation;
using SoapLush.InputModels;

namespace SoapLush.Validators
{
    public class UpdateSubCategoryRequetValidator: AbstractValidator<UpdateSubCategoryInputModel>
    {
        public UpdateSubCategoryRequetValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.CategoryId).NotNull();
        }
    }
}
