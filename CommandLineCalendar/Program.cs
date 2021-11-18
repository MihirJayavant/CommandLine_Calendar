﻿using CommandLineCalender;
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
        case "exit cal":
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
            displayHelp();
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

void displayHelp()
{
    Console.WriteLine("1.To change year enter:\t\t\t\tcg -yr\n" +
                      "2.To change month enter:\t\t\tcg -month\n" +
                      "3.To Show calendar of saved year enter:\t\tshow\n" +
                      "4.To Show calendar of saved year,month enter:\tshow -s\n" +
                      "5.To exit enter:\t\t\t\texit cal");
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

            Console.WriteLine("Enter month (1-12):");
            s = Console.ReadLine() ?? "";
            if (CheckIfNum(s))
            {

                int temp = int.Parse(Console.ReadLine() ?? "");
                if (temp > 0 && temp <= 12)
                {
                    c.month = temp;
                    Console.WriteLine("Successfully changed month to:" + c.month);
                }
                else
                {
                    Console.WriteLine("Invalid month");
                }
            }
            else
            {
                Console.WriteLine("Enter only digits");
            }
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
