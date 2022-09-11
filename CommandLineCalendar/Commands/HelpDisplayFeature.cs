namespace CommandLineCalender.Commands;

public class HelpDisplayFeature : IFeature
{
    public string CommandName => "help";
    public string Info => "For help enter \t\t: help";

    public Context Run(Context context)
    {
        var features = context.Features;
        for (var i = 0; i < features.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {features[i]!.Info}");
        }

        return context;
    }
}
