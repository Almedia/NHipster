using System;
using Hipster.ApplicationService.Dto.Request;
using Hipster.ApplicationService.Dto.Response;
using Hipster.ApplicationService.Validation;
using Hipster.Domain;
using Hipster.Domain.MemberAggregate;

namespace Hipster.ApplicationService.Service
{
    public class MemberService : IMemberService
    {
        private readonly ICreateMemberValidation _validator;
        private readonly IMemberManager _memberManager;
        private readonly IMessageProducer _messageProducer ; 
        public MemberService(ICreateMemberValidation validator, IMemberManager memberManager,IMessageProducer messageProducer)
        {
            _validator = validator;
            _memberManager = memberManager;
            _messageProducer=messageProducer;
        }
        public CreateMemberResponse GetMember(string id)
        {
            var memberId = Guid.Parse(id);
            var member=_memberManager.GetMember(memberId);

            return new CreateMemberResponse()
            {
                UserMessage = "İşlem Başarılı",
                Code = 0000,
                Message = "Success",
                Name=member.Name,
                Surname=member.Surname,
                MemberId=member.ID,
                Email=member.Email,
                RecordStatus=member.RecordStatus
                
            };
        }

        public ResponseBase UpdateMember(long memberId)
        {
            if (memberId != 1234)
            {
                throw new Exception("MemberId Not Found");
            }
            //
            //produce message to kafka
            return new ResponseBase();
        }

        public CreateMemberResponse CreateMember(CreateMemberRequest request)
        {
            _validator.ValidateRequest(request);

            var member = Member.New();
            member.SetMemberInformation(request.Name, request.Surname, request.Email);
            _memberManager.Save(member);
            _messageProducer.Produce("member-event",member.ID.ToString());
            return new CreateMemberResponse()
            {
                MemberId = member.ID,
                Name = member.Name,
                Surname = member.Surname,
                Email = member.Email
            };
        }

        public ResponseBase ActivateMember(Guid memberId)
        {
            var member=_memberManager.GetMember(memberId);
            member.Activate();
            _memberManager.Update(member);
            return new ResponseBase();
        }
    }
}