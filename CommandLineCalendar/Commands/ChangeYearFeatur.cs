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
        if (valid)
        {
            if (s.Length == 4)
            {
                if (year >= 0 && year <= 9999)
                {
                    var c = new CalenderInteraction(year, calenderInteraction.month, calenderInteraction.day);
                    Console.WriteLine("Successfully changed to year:" + year);
                    return c;
                }
                else
                {
                    Console.WriteLine("Invalid year");
                }
            }
            else
            {
                Console.WriteLine("Invalid year\tyear format should be YYYY");
            }
        }
        return calenderInteraction;
    }
}
