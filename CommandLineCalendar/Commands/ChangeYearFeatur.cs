namespace CommandLineCalender.Commands;

public class ChangeYearFeature : IFeature
{
    public string CommandName => "cg year";

    public string Info => "To change year enter:\t\t\t\tcg year";

    public CalenderInteraction Run(CalenderInteraction calenderInteraction)
    {
        Console.WriteLine("Enter year (0000-9999):");
        var s = Console.ReadLine() ?? "";
        var valid = int.TryParse(s, out var year);
        if (valid && s.Length == 4 && year >= 0 && year <= 9999)
        {
            Console.WriteLine("Successfully changed to year:" + year);
            return new CalenderInteraction(year, calenderInteraction.month, calenderInteraction.day);
        }
        else
        {
            Console.WriteLine("Invalid year, it should be YYYY.\neg. 2021");
        }

        return calenderInteraction;
    }
}
