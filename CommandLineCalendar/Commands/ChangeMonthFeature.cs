namespace CommandLineCalender.Commands;

public class ChangeMonthFeature : IFeature
{
    public string CommandName => "cd -m";

    public string Info => "Change Month \t\t:  cd -m";

    public Context Run(Context context)
    {
        Console.WriteLine("Enter month (1-12):");
        var s = Console.ReadLine() ?? "";
        var valid = int.TryParse(s, out var month);
        if (valid && month >= 1 && month <= 12)
        {
            context.Manager.ChangeMonth(month);
            Console.WriteLine("Successfully changed month to:" + context.Manager.MonthName);
        }
        else
        {
            Console.WriteLine("Invalid Month");
        }

        return context;
    }
}
