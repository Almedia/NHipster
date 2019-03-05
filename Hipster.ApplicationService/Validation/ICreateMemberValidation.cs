using Hipster.ApplicationService.Dto.Request;

namespace Hipster.ApplicationService.Validation
{
    public interface ICreateMemberValidation
    {
         void ValidateRequest(CreateMemberRequest request);
    }
}