using System;
using Hipster.Domain.MemberAggregate.Events;

namespace Hipster.Domain.MemberAggregate
{
    public class Member:Aggregate
    {
        public Member(){
        }
        public Member(Guid memberId, string name,string surname,string email,string recordStatus){
            this.ID=memberId;
            this.Name=name;
            this.Surname=surname;
            this.Email=email;
            this.RecordStatus=recordStatus;

        }
        ///Database'de dataları okuyup set etmesi için kullanabileceğimiz constructor

        public string Email {get; protected set;}

        public string Name {get; protected set;}

        public  string Surname {get; protected set;}

        public string RecordStatus {get;set;}

        public static Member New(){
                var member=new Member();
                member.ID=Guid.NewGuid();
                member.RecordStatus="P";
                return member;
        }
        
        public void SetMemberInformation(string name,string surname,string email){
            this.Email=email;
            this.Name=name;
            this.Surname=surname;
            AddDomainEvent(new MemberCreatedDomainEvent(){
                MemberId=ID
            });
        }

        public void Activate(){
             this.RecordStatus="A";
            AddDomainEvent(new MemberStatusChangedEvent(){
                MemberId=ID,
                RecordStatus=RecordStatus
            });
           
        }
    }
}