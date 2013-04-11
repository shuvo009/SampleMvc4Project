using System.Data.Entity;

namespace SampleMvc4Project.Entitys
{
    public class BlogContext : DbContext
    {
        public BlogContext()
            : base("DbConnection")
        {
            
        }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}