using app.Domain;
using Microsoft.EntityFrameworkCore;

namespace app.Data;
public class ArticlesDbContext(DbContextOptions<ArticlesDbContext> options) : DbContext(options)
{
    public DbSet<Article> Articles { get; set; }
    public DbSet<Tag> Tags { get; set; }
}
