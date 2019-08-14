using System;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace DBRepository.Interfaces
{
    public interface IRepository<T> where T : BaseModel
    {
        IQueryable<T> GetAll();
        T Get(long id);
        void Insert(T entity);
        void InsertVacancies(IEnumerable<T> entities);
        void Update(T entity);
        void Delete(T entity);
        void Remove(T entity);
        void SaveChanges();
    }
}
