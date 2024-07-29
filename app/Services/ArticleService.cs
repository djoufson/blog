using app.Data.Repositories.Base;
using app.Domain;
using Microsoft.EntityFrameworkCore;

namespace app.Services;
public class ArticleService(IRepository<Article, Guid> repository)
{
    private readonly IRepository<Article,Guid> _repository = repository;
    public async Task<Article?> GetArticleByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _repository.GetAsync(id, cancellationToken);
    }

    public async Task<Article?> GetArticleBySlugAsync(string slug, CancellationToken cancellationToken = default)
    {
        return await _repository.GetAsync(a => a.Slug == slug, cancellationToken);
    }

    public async Task<Article[]> GetLatestsAsync(CancellationToken cancellationToken = default)
    {
        return await _repository.Query()
            .OrderByDescending(a => a.PublishedDate)
            .Take(3)
            .Include(a => a.Tags)
            .ToArrayAsync(cancellationToken);
    }

    public async Task<Article[]> SearchAsync(string? searchTerm, string[] tags, int page = 1, int size = 10, CancellationToken cancellationToken = default)
    {
        var query = _repository.Query();
        if(!string.IsNullOrEmpty(searchTerm))
        {
            query = _repository.Query().Where(a => a.Title.Contains(searchTerm));
        }
        if(tags.Length > 0)
        {
            query = query.Where(a => a.Tags.Any(t => tags.Contains(t.Name)));
        }

        return await query
            .OrderByDescending(a => a.PublishedDate)
            .Skip((page - 1) * size)
            .Take(size)
            .Include(a => a.Tags)
            .ToArrayAsync(cancellationToken);
    }
}
