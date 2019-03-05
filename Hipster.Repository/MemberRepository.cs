using System;
using Hipster.Domain.MemberAggregate;

namespace Hipster.Repository
{
    public class MemberRepository : Repository<Member>,IMemberRepository
    {
        public MemberRepository(HipsterContext context) : base(context)
        {
        }
    }
}
