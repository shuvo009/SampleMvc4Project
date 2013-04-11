using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SampleMvc4Project.Entitys;

namespace SampleMvc4Project.Interfaces
{
    public interface IBlogUnitOfWork :IDisposable
    {
        IBlogRepository<Blog> Blog { get; }
        IBlogRepository<Comment> Comment { get; }
        IBlogRepository<Post> Post { get; }
        void Save();
    }
}
