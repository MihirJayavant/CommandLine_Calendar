namespace CommandLineCalender.Commands;

public class ExitFeature : IFeature
{
    public string CommandName => "exit";
    public string Info => "To Exit \t\t\t: exit";

    public Context Run(Context context)
        => context with { Exit = true };
}
