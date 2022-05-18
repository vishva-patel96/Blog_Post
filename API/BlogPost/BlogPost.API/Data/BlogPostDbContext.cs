using BlogPost.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogPost.API.Data
{
    public class BlogPostDbContext : DbContext
    {
        public BlogPostDbContext(DbContextOptions options) : base(options)
        {
        }
        //DbSet     
        public DbSet<Post> Posts{ get; set; }
    }
}
