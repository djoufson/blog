using app.Domain.Base;
using app.Domain.Exceptions;
using app.Services;

namespace app.Domain;
public class Article : Entity<Guid>
{
    public string Title { get; private set; }
    public string Content { get; private set; }
    public string Slug { get; private set; }
    public DateTime? PublishedDate { get; private set; }
    public Tag[] Tags { get; private set; }
    public string ImageUrl { get; private set; }
    public PublishedStatus Status { get; private set; } = PublishedStatus.Draft;

    private Article(
        Guid id,
        string title,
        string content,
        string slug,
        Tag[] tags,
        string imageUrl) : base(id)
    {
        Title = title;
        Content = content;
        Slug = slug;
        Tags = tags;
        ImageUrl = imageUrl;
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private Article()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    {
    }

    public static Article Create(
        string title,
        string content,
        Tag[] tags,
        string imageUrl)
    {
        var slug = GenerateSlug(title);
        return new Article(Guid.NewGuid(), title, content, slug, tags, imageUrl);
    }

    private static string GenerateSlug(string title)
    {
        return title.ToLower().Replace(" ", "-");
    }

    public void Publish(IDateTimeProvider dateTimeProvider)
    {
        if (Status == PublishedStatus.Published || Status == PublishedStatus.Archived)
        {
            throw new CannotPublishAlreadyPublishedArticleException();
        }

        PublishedDate = dateTimeProvider.UtcNow();
        Status = PublishedStatus.Published;
    }
}

public enum PublishedStatus
{
    Draft = 0,
    Published = 1,
    Archived = 2
}
