using CommandLineCalender;
using CommandLineCalender.Commands;

DateTime d = startingMessage();
string s;
int temp;

CalenderInteraction c = new CalenderInteraction(d.Year, d.Month, d.Day);

int option = 0;
string entered = "";
do
{
    entered = Console.ReadLine() ?? "";
    entered = entered.Trim();
    switch (entered)
    {
        case "exit":
            option = 1;
            break;

        case "cg -yr":
            c = Change(c, 1);
            break;

        case "cg -month":
            c = Change(c, 2);
            break;

        case "show":
            Console.WriteLine("Enter Month (1-12):");
            s = Console.ReadLine() ?? "";

            if (!CheckIfNum(s))
            {
                Console.WriteLine("Enter only digits");
                break;
            }

            temp = int.Parse(s);

            if (temp > 0 && temp <= 12)
            {
                Show(c, temp);
            }
            else
            {
                Console.WriteLine("Invalid Month");
            }
            break;

        case "show -s":
            Show(c, c.month);
            break;

        case "help":
            new HelpDisplayFeature().Run(c);
            break;

        case "":
            break;

        default:
            Console.WriteLine("Invalid command");
            break;
    }

} while (option == 0);

DateTime startingMessage()
{
    DateTime d = DateTime.Now;
    Console.WriteLine("Welcome to Command Line Calender\nToday's date:" + d + "\nFor help enter: help");
    return d;
}

CalenderInteraction Change(CalenderInteraction c, int option)
{
    string s;
    int year;

    switch (option)
    {
        case 1:
            c = new ChangeYearFeature().Run(c);
            break;

        case 2:
            c = new ChangeMonthFeature().Run(c);
            break;
    }

    return c;
}

void Show(CalenderInteraction c, int month)
{
    int temp = c.month;
    c.month = month;
    Console.WriteLine("\t\t\t" + CalenderInteraction.getSpecificMonth(month).ToUpper() + " " + c.getYear());
    Console.WriteLine("\t" + c.getAllDayInName() + "\n" +
                      CalenderInteraction.formatToCalendar(c.getCalendarOfMonth()));
    c.month = temp;
}

bool CheckIfNum(string s)
{
    bool b = false;
    for (int i = 0; i < s.Length; i++)
    {
        if (char.IsDigit(s[i]))
        {
            continue;
        }
        else
        {
            return b;
        }
    }
    return true;
}
