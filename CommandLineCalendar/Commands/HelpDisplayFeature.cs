namespace CommandLineCalender.Commands;

public class HelpDisplayFeature : IFeature
{
    public string CommandName => "help";

    public string Info => "For help enter: help";

    public CalenderInteraction Run(CalenderInteraction calenderInteraction)
    {
        Console.WriteLine(@"
1. To change year enter                         :  cg -yr
2. To change month enter                        :  cg -month
3. To Show calendar of saved year enter         :  show
4. To Show calendar of saved year,month enter   :  show -s
5. To exit enter                                :  exit
6. For help enter                               :  help
");

        return calenderInteraction;
    }
}
