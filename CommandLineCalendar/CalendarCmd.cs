using CommandLineCalender.Commands;

namespace CommandLineCalender;

public class CalendarCmd
{
    public static void Run()
    {
        var features = new IFeature[] {
            new ChangeMonthFeature(),
            new ChangeYearFeature(),
            new HelpDisplayFeature(),
            new ShowCalendarFeature(),
            new ShowCurrentFeature(),
            new ExitFeature()
        };

        var hashMap = new Dictionary<string, IFeature>();

        foreach (var f in features)
        {
            hashMap.Add(f.CommandName, f);
        }

        startingMessage();
        var context = new Context(new CalendarManager(), features.ToArray());
        do
        {
            var entered = Console.ReadLine() ?? "";
            entered = entered.Trim();
            hashMap.TryGetValue(entered, out var feature);
            if (feature is not null)
            {
                context = feature.Run(context);
            }
            else
            {
                Console.WriteLine("Invalid Command");
            }

        } while (context.Exit is false);

        static void startingMessage()
        {
            var d = DateTime.Now;
            Console.WriteLine("Welcome to Command Line Calender\nToday's date: " + d + "\nFor help enter: help");
        }

    }
}
