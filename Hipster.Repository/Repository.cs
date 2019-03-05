using System;
using System.Collections.Generic;
using System.Linq;
using Hipster.Domain;
using Microsoft.EntityFrameworkCore;

namespace Hipster.Repository
{
    public class Repository<T> : IRepository<T> where T : Aggregate
    {
        private readonly HipsterContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;

        public Repository(HipsterContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public T Get(Guid id)
        {
            return entities.SingleOrDefault(s => s.ID == id);
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.SaveChanges();
        }
    }
}