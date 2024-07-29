namespace app.Domain.Exceptions;
public class CannotPublishAlreadyPublishedArticleException : Exception
{
    public CannotPublishAlreadyPublishedArticleException() : base("Article is already published")
    {
    }
}
