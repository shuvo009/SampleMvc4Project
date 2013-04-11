using System.Data.Entity;
using SampleMvc4Project.Entitys;
using SampleMvc4Project.Interfaces;

namespace SampleMvc4Project.Repositorys
{
    public class BlogUnitOfWork : IBlogUnitOfWork
    {
        private readonly DbContext _dbContext;
        private IBlogRepository<Blog> _blog;
        private IBlogRepository<Comment> _comment;
        private IBlogRepository<Post> _post;

        public BlogUnitOfWork()
            : this(new BlogContext())
        {
        }

        private BlogUnitOfWork(BlogContext blogContext)
        {
            _dbContext = blogContext;
        }

        #region IBlogUnitOfWork Members

        public IBlogRepository<Blog> Blog
        {
            get { return _blog ?? (_blog = new BlogRepository<Blog>(_dbContext)); }
        }

        public IBlogRepository<Comment> Comment
        {
            get { return _comment ?? (_comment = new BlogRepository<Comment>(_dbContext)); }
        }

        public IBlogRepository<Post> Post
        {
            get { return _post ?? (_post = new BlogRepository<Post>(_dbContext)); }
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            if (_dbContext != null)
            {
                _dbContext.Dispose();
            }
        }

        #endregion
    }
}