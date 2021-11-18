namespace CommandLineCalender.Commands;

public class ChangeMonthFeature : IFeature
{
    public string CommandName => "cg month";

    public string Info => @"For help enter                               :  help";

    public CalenderInteraction Run(CalenderInteraction calenderInteraction)
    {
        Console.WriteLine("Enter month (1-12):");
        var s = Console.ReadLine() ?? "";
        var valid = int.TryParse(s, out var month);
        if (valid && s.Length == 4 && month >= 1 && month <= 12)
        {
            if (month > 0 && month <= 12)
            {
                calenderInteraction.month = month;
                Console.WriteLine("Successfully changed month to:" + calenderInteraction.month);
            }
            else
            {
                Console.WriteLine("Invalid month");
            }
        }
        else
        {
            Console.WriteLine("Enter only digits");
        }

        return calenderInteraction;
    }
}
