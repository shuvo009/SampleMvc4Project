using System;
using System.Linq;
using System.Linq.Expressions;

namespace SampleMvc4Project.Interfaces
{
    public interface IBlogRepository<T>
    {
        void Add(T entity);
        void Remove(Int64 id);
        void Update(T entity);
        IQueryable<T> GetAll();
        T GetById(Int64 id);
        IQueryable<T> Search(Expression<Func<T, bool>> expression);
    }
}