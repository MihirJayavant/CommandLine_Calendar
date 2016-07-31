using System;

namespace CommandLineCalender
{
    public class CalenderInteraction
    {
        private System.DateTime date;
        private int startingDayOfYear;
        public int month { set; get; }
        public int day { get; }

        private static string[] months= { "january", "february", "march", "april", "may", "june", "july", "august",
            "september", "october", "november", "december" };

        private int[] daysInMonths = {31,28,31,30,31,30,31,31,30,31,30,31};

        private static string[] dayNames = { "Sun", "Mon", "Tue", "Wed", "Thurs", "Fri", "Sat" };

        public CalenderInteraction(int year,int month,int day)
        {
            if(year<=0||year>9999)
            {
                year = 1;
            }
            date = new DateTime(year,1,1);

            if(((int) date.DayOfWeek)==7)
            {
                startingDayOfYear = 6;
            }
            else
            {
                startingDayOfYear = (int)date.DayOfWeek;
            }

            if ((year % 100 != 0 && year % 4 == 0)|| (year % 100 == 0 && year % 400 == 0))
            {
                daysInMonths[1] = 29;
            }
            this.month = month;
            
        }

        public string get()
        {
            return date.ToString()+ startingDayOfYear;
        }

        public int getYear()
        {
            return date.Year;
        }

        public string getAllDayInName()
        {
            string s = "";
            for (int i = 0; i < 7; i++)
            {
                s = s + dayNames[i] + "\t";
            }
            return s;
        }

        private int startingDayOfMonth()
        {
            int a = startingDayOfYear;
            for (int i = 0; i < month-1; i++)
            {
                a += daysInMonths[i];
            }
            return a % 7;
        }

        public string[] getCalendarOfMonth()
        {
            string[] s = new string[38];
            int start = startingDayOfMonth();
            for (int i = 0; i < start; i++)
            {
                    s[i] = "\t";               
            }
            for (int i = start,j = 1; j <= daysInMonths[month-1]; i++,j++)
            {

                s[i] = j + "\t";
            }
            return s;
        }

        static public string formatToCalendar(string[] s)
        {
            string s2 = "\t";
            for (int i = 0; i < s.Length; i++)
            {
                if (i != 0 && i % 7 == 0)
                    s2 = s2 + "\n\t" + s[i];
                else
                    s2 = s2 + s[i];
            }
            return s2;
        }

        static public string getSpecificMonth(int month)
        {
            return months[month - 1];
        }
    }
}
