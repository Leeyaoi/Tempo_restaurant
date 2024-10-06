
namespace Tempo_Shared.Providers;

public class DateTimeProvider : IDateTimeProvider
{
    private readonly DateTime _dateTime = DateTime.UtcNow;

    public DateTime GetDate() => _dateTime;
}
