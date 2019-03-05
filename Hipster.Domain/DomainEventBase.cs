using System;

namespace Hipster.Domain
{
    public class DomainEventBase
    {
        public DomainEventBase(){
            EventDate=DateTime.Now;
        }
        public DateTime EventDate {get;set;}
    }
}