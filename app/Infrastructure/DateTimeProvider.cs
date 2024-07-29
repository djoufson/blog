using app.Business;

namespace app.Infrastructure;
internal class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow()
    {
        return DateTimeOffset.UtcNow.DateTime;
    }
}
