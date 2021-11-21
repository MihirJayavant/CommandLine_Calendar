using System;
using System.Linq;
using System.Reflection;
using CommandLineCalender.Commands;

namespace CommandLineCalender;

public class CalendarCmd
{
    public static void Run()
    {
        var assignableType = typeof(IFeature);
        var features = Assembly.GetExecutingAssembly()
                                .GetTypes()
                                .Where(t => assignableType.IsAssignableFrom(t) && t.IsClass)
                                .Select(f => Activator.CreateInstance(f) as IFeature)
                                .ToList();

        var hashMap = new Dictionary<string, IFeature>();

        foreach (var f in features)
        {
            if (f is not null)
            {
                hashMap.Add(f.CommandName, f);
            }
        }
        var d = startingMessage();
        var c = new CalenderInteraction(d.Year, d.Month, d.Day);
        var option = 0;
        do
        {
            var entered = Console.ReadLine() ?? "";
            entered = entered.Trim();
            var found = hashMap.TryGetValue(entered, out var feature);
            if (found is false)
            {
                if (entered == "exit")
                {
                    option = 1;
                }
                if (entered != "")
                {
                    Console.WriteLine("Invalid Command");
                }
            }
            else
            {
                c = feature!.Run(c);
            }

        } while (option == 0);

        static DateTime startingMessage()
        {
            var d = DateTime.Now;
            Console.WriteLine("Welcome to Command Line Calender\nToday's date:" + d + "\nFor help enter: help");
            return d;
        }

    }
}
