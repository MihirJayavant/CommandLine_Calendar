namespace CommandLineCalender.Commands;

public interface IFeature
{
    string CommandName { get; }
    string Info { get; }
    CalenderInteraction Run(CalenderInteraction calenderInteraction);
}
