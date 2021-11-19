using CommandLineCalender;
using CommandLineCalender.Commands;

var d = startingMessage();
var c = new CalenderInteraction(d.Year, d.Month, d.Day);
var option = 0;

IFeature[] features = {
    new ChangeYearFeature(),
    new ChangeMonthFeature(),
    new HelpDisplayFeature(),
    new ShowCalendarFeature(),
    new ShowCurrentFeature()
};

var hashMap = new Dictionary<string, IFeature>();

foreach (var f in features)
{
    hashMap.Add(f.CommandName, f);
}

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
