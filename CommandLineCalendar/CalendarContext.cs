using System.Globalization;

namespace CommandLineCalender;

public record CalendarContext
{
    public DateOnly Current { init; get; }
    public GregorianCalendar Calendar { init; get; }
}
