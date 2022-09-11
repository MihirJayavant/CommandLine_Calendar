namespace CommandLineCalender.Commands;

public class ShowCalendarFeature : IFeature
{
    public string CommandName => "ls -m";

    public string Info => "Show Any Month \t\t:  ls -m";

    public Context Run(Context context)
    {
        Console.WriteLine("Enter Month (1-12):");
        var s = Console.ReadLine() ?? "";
        var valid = int.TryParse(s, out var month);
        if (valid && month > 0 && month <= 12)
        {
            Show(context, month);
        }
        else
        {
            Console.WriteLine("Invalid Month");
        }
        return context;
    }

    private static void Show(Context c, int month)
    {
        var temp = c.Manager.Month;
        c.Manager.ChangeMonth(month);
        var daysMatrix = c.Manager.CalendarOfTheMonth();

        Console.WriteLine($"\t\t\t{c.Manager.MonthName} {c.Manager.Year}");
        Console.WriteLine(string.Join('\t', CalendarManager.DayNames));

        foreach (var line in daysMatrix)
        {
            Console.WriteLine(string.Join('\t', line));
        }
        c.Manager.ChangeMonth(temp);
    }
}
