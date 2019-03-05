using System;
using Hipster.ApplicationService.Dto.Request;
using Hipster.ApplicationService.Dto.Response;

namespace Hipster.ApplicationService.Service
{
    public interface IMemberService
    {
         CreateMemberResponse CreateMember(CreateMemberRequest request);
         CreateMemberResponse GetMember(string memberId);

         ResponseBase  UpdateMember(long memberId);

         ResponseBase   ActivateMember(Guid memberId);
    }
}