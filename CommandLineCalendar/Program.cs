using CommandLineCalender;
using CommandLineCalender.Commands;

var d = startingMessage();

var c = new CalenderInteraction(d.Year, d.Month, d.Day);

var option = 0;

do
{
    var entered = Console.ReadLine() ?? "";
    entered = entered.Trim();
    switch (entered)
    {
        case "exit":
            option = 1;
            break;

        case "cg -yr":
            c = new ChangeYearFeature().Run(c);
            break;

        case "cg -month":
            c = new ChangeMonthFeature().Run(c);
            break;

        case "show":
            c = new ShowCalendarFeature().Run(c);
            break;

        case "show -s":
            c = new ShowCurrentFeature().Run(c);
            break;

        case "help":
            c = new HelpDisplayFeature().Run(c);
            break;

        case "":
            break;

        default:
            Console.WriteLine("Invalid command");
            break;
    }

} while (option == 0);

static DateTime startingMessage()
{
    var d = DateTime.Now;
    Console.WriteLine("Welcome to Command Line Calender\nToday's date:" + d + "\nFor help enter: help");
    return d;
}
