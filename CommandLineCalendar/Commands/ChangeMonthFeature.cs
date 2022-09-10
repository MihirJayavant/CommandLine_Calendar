namespace CommandLineCalender.Commands;

public class ChangeMonthFeature : IFeature
{
    public string CommandName => "cd -y";

    public string Info => "Change Month \t\t\t:  cd -m";

    public CalenderInteraction Run(CalenderInteraction calenderInteraction)
    {
        Console.WriteLine("Enter month (1-12):");
        var s = Console.ReadLine() ?? "";
        var valid = int.TryParse(s, out var month);
        if (valid && month >= 1 && month <= 12)
        {
            calenderInteraction.month = month;
            Console.WriteLine("Successfully changed month to:" + calenderInteraction.month);
        }
        else
        {
            Console.WriteLine("Invalid Month");
        }

        return calenderInteraction;
    }
}
