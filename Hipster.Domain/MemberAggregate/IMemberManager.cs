using System;

namespace Hipster.Domain.MemberAggregate
{
    public interface IMemberManager
    {
        void Save(Member member);

        Member GetMember(Guid memberId);

        void Update(Member member);
    }
}