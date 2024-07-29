using app.Domain;
using Microsoft.EntityFrameworkCore;

namespace app.Data;
public class BlogDbContext(DbContextOptions<BlogDbContext> options) : DbContext(options)
{
    public DbSet<Article> Articles { get; set; }
    public DbSet<Tag> Tags { get; set; }
}
