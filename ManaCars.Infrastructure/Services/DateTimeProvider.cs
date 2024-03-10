using ManaCars.Application.Common.Interfaces.Services;

namespace ManaCars.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}