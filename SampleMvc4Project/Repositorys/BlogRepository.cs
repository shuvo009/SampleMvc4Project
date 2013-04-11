using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using SampleMvc4Project.Interfaces;

namespace SampleMvc4Project.Repositorys
{
    public class BlogRepository<T> : IBlogRepository<T> where T : class , IEntity, new()
    {
        private readonly DbSet<T> _dbSet;
        private readonly DbContext _dbContext;

        public BlogRepository(DbContext dbContext)
        {
            _dbSet = dbContext.Set<T>();
            _dbContext = dbContext;
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Remove(long id)
        {
            _dbSet.Remove(_dbSet.Find(id));
        }

        public void Update(T entity)
        {
            //var oldEntity = _dbSet.Find(entity.Id);
            //var updatedEntity = _dbContext.Entry(entity);
            //updatedEntity.CurrentValues.SetValues(oldEntity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public T GetById(long id)
        {
            return _dbSet.Find(id);
        }

        public IQueryable<T> Search(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }
    }
}