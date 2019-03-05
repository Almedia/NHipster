using System;

namespace Hipster.Domain.MemberAggregate.Events
{
    public class MemberStatusChangedEvent:DomainEventBase, IDomainEvent
    {
        public Guid MemberId {get;set;}

        public string RecordStatus {get;set;}
    }
}