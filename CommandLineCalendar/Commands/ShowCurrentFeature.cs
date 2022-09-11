namespace CommandLineCalender.Commands;

public class ShowCurrentFeature : IFeature
{
    public string CommandName => "ls";

    public string Info => "Show Full Month \t\t: ls";

    public Context Run(Context context)
    {
        Show(context);
        return context;
    }

    private static void Show(Context c)
    {
        var daysMatrix = c.Manager.CalendarOfTheMonth();

        Console.WriteLine($"\t\t\t{c.Manager.MonthName} {c.Manager.Year}");
        Console.WriteLine(string.Join('\t', CalendarManager.DayNames));

        foreach (var line in daysMatrix)
        {
            Console.WriteLine(string.Join('\t', line));
        }
    }
}
