using System;
using FluentValidation;
using Hipster.ApplicationService.Dto.Request;
using Hipster.ApplicationService.Validation;

namespace Hipster.Validator
{
    public class CreateMemberValidation : AbstractValidator<CreateMemberRequest>,ICreateMemberValidation
    {
        public void ValidateRequest(CreateMemberRequest request)
        {
            RuleFor(x=>x.Name).NotNull().NotEmpty().WithMessage("Name is empty");
            RuleFor(x=>x.Surname).NotNull().NotEmpty().WithMessage("Surname is empty");
            RuleFor(x=>x.Email).NotNull().NotEmpty().WithMessage("Email is empty");

            var validationResponse=this.Validate(request);

            if(!validationResponse.IsValid){
                throw new Exception(validationResponse.Errors[0].ErrorMessage);
            }
        }
    }
}
