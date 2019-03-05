using System;
using Hipster.ApplicationService.Dto.Request;

namespace Hipster.ApplicationService.Validation
{
    public class MemberValidation : IMemberValidation
    {
        public void Validate(CreateMemberRequest request)
        {
            if (string.IsNullOrEmpty(request.Name)){
                throw new Exception("MemberName is empty");
            }
            if (string.IsNullOrEmpty(request.Surname)){
                throw new Exception("Surname is empty");
            }
            if (string.IsNullOrEmpty(request.Email)){
                throw new Exception("Email is empty");
            }
        }
    }
}