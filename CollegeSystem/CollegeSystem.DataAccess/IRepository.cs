using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeSystem.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        IEnumerable<T> GetByIds(List<int> ids);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
