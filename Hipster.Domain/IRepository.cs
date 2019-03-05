using System;
using System.Collections.Generic;

namespace Hipster.Domain
{
      public interface IRepository<T> where T : Aggregate
        {
            IEnumerable<T> GetAll();
            T Get(Guid id);
            void Insert(T entity);
            void Update(T entity);
            void Delete(T entity);
        }
}