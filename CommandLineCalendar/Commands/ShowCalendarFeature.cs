namespace CommandLineCalender.Commands;

public class ShowCalendarFeature : IFeature
{
    public string CommandName => "ls -m";

    public string Info => "To Show calendar of saved year enter         :  ls -m";

    public CalenderInteraction Run(CalenderInteraction calenderInteraction)
    {
        Console.WriteLine("Enter Month (1-12):");
        var s = Console.ReadLine() ?? "";
        var valid = int.TryParse(s, out var month);
        if (valid)
        {
            Console.WriteLine("Enter only digits");
            return calenderInteraction;
        }

        if (month > 0 && month <= 12)
        {
            Show(calenderInteraction, month);
        }
        else
        {
            Console.WriteLine("Invalid Month");
        }
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
