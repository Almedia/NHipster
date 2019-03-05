using Hipster.Domain.MemberAggregate.Events;

namespace Hipster.EventBus.Handlers
{
    public class MemberCreatedDomainEventHandler : IHandler<MemberCreatedDomainEvent>
    {
        
     

        public void Handle(MemberCreatedDomainEvent domainEvent)
        {
            //to do send message to kafka 
        }
    }
}