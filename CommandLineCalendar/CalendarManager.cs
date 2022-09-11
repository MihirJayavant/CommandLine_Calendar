using System.Globalization;
namespace CommandLineCalender;

public sealed class CalendarManager
{
    private DateTime Current { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
    private GregorianCalendar CurrentCalendar { get; set; } = new GregorianCalendar();

    public static readonly string[] MonthNames = {
        "January", "February", "March", "April", "May", "June", "July", "August",
        "September", "October", "November", "December"
        };
    public static readonly string[] DayNames = { "Sun", "Mon", "Tue", "Wed", "Thurs", "Fri", "Sat" };

    public string DayName => DayNames[(int)CurrentCalendar.GetDayOfWeek(Current)];
    public string MonthName => MonthNames[CurrentCalendar.GetMonth(Current)];
    public int Year => CurrentCalendar.GetYear(Current);
    public int Month => CurrentCalendar.GetMonth(Current);

    public int[][] CalendarOfTheMonth()
    {
        var monthMatrix = new int[6][];
        var start = (int)CurrentCalendar.GetDayOfWeek(Current);
        var daysInMonth = CurrentCalendar.GetDaysInMonth(Current.Year, Current.Month);
        var count = 1;

        for (var i = 0; i < 6; i++)
        {
            monthMatrix[i] = new int[7];
            for (var j = 0; j < 7; j++)
            {
                if (i == 0 && i < start)
                {
                    monthMatrix[i][j] = 0;
                }
                else if (count < daysInMonth)
                {
                    monthMatrix[i][j] = count;
                    count++;
                }
                else
                {
                    monthMatrix[i][j] = 0;
                }
            }
        }
        return monthMatrix;
    }

    public void ChangeYear(int year) => CurrentCalendar.AddYears(Current, year - Current.Year);
    public void ChangeMonth(int month) => CurrentCalendar.AddYears(Current, month - Current.Month);
}