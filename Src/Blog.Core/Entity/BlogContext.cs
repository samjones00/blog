using Microsoft.EntityFrameworkCore;

namespace Blog.Core.Entity
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
        }

        public DbSet<ArticleEntity> Articles { get; set; }
    }
}
