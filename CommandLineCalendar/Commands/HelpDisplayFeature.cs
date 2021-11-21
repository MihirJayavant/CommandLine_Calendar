using System.Reflection;

namespace CommandLineCalender.Commands;

public class HelpDisplayFeature : IFeature
{
    public string CommandName => "help";
    public string Info => "For help enter: help";

    public CalenderInteraction Run(CalenderInteraction calenderInteraction)
    {
        var assignableType = typeof(IFeature);
        var features = Assembly.GetExecutingAssembly()
                                .GetTypes()
                                .Where(t => assignableType.IsAssignableFrom(t) && t.IsClass)
                                .Select(f => (Activator.CreateInstance(f) as IFeature)!)
                                .ToArray();
        for (var i = 0; i < features.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {features[i]!.Info}");
        }

        return calenderInteraction;
    }
}
