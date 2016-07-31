using System;

namespace CommandLineCalender
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime d = startingMessage();
            string s;int temp;
            
            CalenderInteraction c = new CalenderInteraction(d.Year,d.Month,d.Day);
            int option = 0;
            string entered;
            do
            {
                entered = Console.ReadLine().Trim();
                switch(entered)
                {
                    case "exit cal":
                        option = 1;
                        break;

                    case "cg -yr":
                        c=Change(c, 1);
                        break;

                    case "cg -month":
                        c = Change(c, 2);
                        break;

                    case "show":
                        Console.WriteLine("Enter Month (1-12):");
                        s = Console.ReadLine();

                        if (!CheckIfNum(s))
                        {
                            Console.WriteLine("Enter only digits");
                            break;
                        }
           
                        temp = int.Parse(s);
                       
                        if(temp>0&&temp<=12)
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

                    case "": break;

                    default: Console.WriteLine("Invalid command");
                        break;
                }

            } while (option == 0);

        }
        private static DateTime  startingMessage()
        {
            DateTime d = DateTime.Now;
            Console.WriteLine("Welcome to Command Line Calender\nToday's date:"+d+"\nFor help enter:help");
            return d;
        }
        private static void displayHelp()
        {
            Console.WriteLine("1.To change year enter:\t\t\t\tcg -yr\n"+
                              "2.To change month enter:\t\t\tcg -month\n"+
                              "3.To Show calendar of saved year enter:\t\tshow\n" +
                              "4.To Show calendar of saved year,month enter:\tshow -s\n"+
                              "5.To exit enter:\t\t\t\texit cal");
        }

        private static CalenderInteraction Change(CalenderInteraction c, int option)
        {
            string s; int year;

            switch (option)
            {
                case 1:

                    Console.WriteLine("Enter year (0000-9999):");
                    s = Console.ReadLine();
                    if (CheckIfNum(s))
                    {
                        if (s.Length == 4)
                        {

                            year = int.Parse(s);

                            if (year >= 0 && year <= 9999)
                            {
                                c = new CalenderInteraction(year, c.month, c.day);
                                Console.WriteLine("Successfully changed to year:" + year);
                            }
                            else
                            {
                                Console.WriteLine("Invalid year");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid year\tyear format should be YYYY");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Enter only digits");
                    }
                        break;

                case 2:

                    Console.WriteLine("Enter month (1-12):");
                    s = Console.ReadLine();
                    if (CheckIfNum(s))
                    {

                        int temp = int.Parse(Console.ReadLine());
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

        private static void Show(CalenderInteraction c, int month)
        {
            int temp = c.month;
            c.month = month;
            Console.WriteLine("\t\t\t" + CalenderInteraction.getSpecificMonth(month).ToUpper() + " " + c.getYear());
            Console.WriteLine("\t" + c.getAllDayInName() + "\n" +
                              CalenderInteraction.formatToCalendar(c.getCalendarOfMonth()));
            c.month = temp;
        }

        public static bool CheckIfNum(string s)
        {
            bool b = false;
            for (int i = 0; i < s.Length; i++)
            {
                if(char.IsDigit(s[i]))
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
    }
}
