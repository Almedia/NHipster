using System;

namespace Hipster.ApplicationService.Dto.Response
{
    public class CreateMemberResponse:ResponseBase
    {
        public Guid MemberId {get;set;}
        public string Name {get;set;}

        public string Surname {get;set;}

        public string Email {get;set;}

        public string RecordStatus {get;set;}
    }
}