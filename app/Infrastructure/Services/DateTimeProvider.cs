using app.Services;

namespace app.Infrastructure.Services;
internal class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow()
    {
        return DateTimeOffset.UtcNow.DateTime;
    }
}
