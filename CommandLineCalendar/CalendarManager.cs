using System.Globalization;
namespace CommandLineCalender;

public sealed class CalendarManager
{
    private DateTime Current { get; set; } = DateTime.Now;
    private GregorianCalendar CurrentCalendar { get; set; } = new GregorianCalendar();

    public static readonly string[] MonthNames = {
        "January", "February", "March", "April", "May", "June", "July", "August",
        "September", "October", "November", "December"
        };
    public static readonly string[] DayNames = { "Sun", "Mon", "Tue", "Wed", "Thurs", "Fri", "Sat" };

    public string Day => DayNames[(int)CurrentCalendar.GetDayOfWeek(Current)];
    public string Month => MonthNames[CurrentCalendar.GetMonth(Current)];
    public int Year => CurrentCalendar.GetYear(Current);
}