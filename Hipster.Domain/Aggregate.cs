using System;
using System.Collections.Generic;

namespace Hipster.Domain
{
    public class Aggregate
    {
        public List<IDomainEvent> DomainEvents{get;protected set;}
        public Guid ID { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? ModifyDate { get; set; }

        public void AddDomainEvent(IDomainEvent domainEvent){
            this.DomainEvents=this.DomainEvents?? new List<IDomainEvent>();
            this.DomainEvents.Add(domainEvent);
        }

        public void RemoveDomainEvent(IDomainEvent domainEvent){
            DomainEvents.Remove(domainEvent);
        }

        // public void AddDomainEvent(IDomainEvent event){
        //     this.DomainEvents=DomainEvents?? new List<IDomainEvent>();
            
        // }
    }
}