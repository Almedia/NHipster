using System;

namespace Hipster.Domain.MemberAggregate
{
    public class MemberManager : IMemberManager
    {
        private readonly IMemberRepository _memberRepository;

        public MemberManager(IMemberRepository memberRepository){
            _memberRepository=memberRepository;
        }

        public Member GetMember(Guid memberId)
        {
            var member=_memberRepository.Get(memberId);
            return member;
        }

        public void Save(Member member)
        {
            _memberRepository.Insert(member);
        }

        public void Update(Member member)
        {
            _memberRepository.Update(member);
        }
    }
}