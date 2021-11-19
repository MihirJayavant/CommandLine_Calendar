namespace CommandLineCalender.Commands;

public class ShowCurrentFeature : IFeature
{
    public string CommandName => "ls";

    public string Info => "To Show calendar of saved year,month enter   :  ls";

    public CalenderInteraction Run(CalenderInteraction calenderInteraction)
    {
        Show(calenderInteraction, calenderInteraction.month);
        return calenderInteraction;
    }

    private static void Show(CalenderInteraction c, int month)
    {
        var temp = c.month;
        c.month = month;
        Console.WriteLine($"\t\t\t{CalenderInteraction.getSpecificMonth(month).ToUpper()} {c.getYear()}");
        Console.WriteLine($"\t{c.getAllDayInName()}\n{CalenderInteraction.formatToCalendar(c.getCalendarOfMonth())}");
        c.month = temp;
    }
}
