using System;

namespace Hipster.Domain.MemberAggregate.Events
{
    public class MemberCreatedDomainEvent :DomainEventBase,IDomainEvent
    {
      public Guid MemberId {get;set;}
    }
}