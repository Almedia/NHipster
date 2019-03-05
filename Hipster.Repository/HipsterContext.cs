using Hipster.Domain.MemberAggregate;
using Microsoft.EntityFrameworkCore;

namespace Hipster.Repository
{
    public class HipsterContext: DbContext
    {
        public HipsterContext (DbContextOptions<HipsterContext> options) :base(options){

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Member>().Ignore(x=>x.DomainEvents);
            modelBuilder.Entity<Member>().Property(b => b.ID).UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);
            modelBuilder.Entity<Member>().Property(b => b.Name).UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);
            modelBuilder.Entity<Member>().Property(b => b.Surname).UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);
            modelBuilder.Entity<Member>().Property(b => b.Email).UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);
            modelBuilder.Entity<Member>().Property(b => b.RecordStatus).UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);
        }

        public override int SaveChanges(){

            //get domain events
            base.SaveChanges();
            return 1;
        }

        public DbSet<Member> Members{get;set;}

        
    }
}