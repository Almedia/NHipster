using Hipster.ApplicationService.Dto.Request;

namespace Hipster.ApplicationService.Validation
{
    public interface IMemberValidation
    {
        void Validate(CreateMemberRequest request);
    }
}