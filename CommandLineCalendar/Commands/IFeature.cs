namespace CommandLineCalender.Commands;

public interface IFeature
{
    string CommandName { get; }
    string Info { get; }
    Context Run(Context context);
}
