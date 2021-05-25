using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Assessment2_BL
{  
    public class CalculateDays
    {
        DateTime _dateResult;

        // validate the date format
        internal void IsValidFormat( string userInput)
        {
            try
            {
                bool isValid = false;
                while (!isValid)
                {
                    isValid = DateTime.TryParseExact (userInput, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _dateResult);
                    if (!isValid)
                    {
                        Console.WriteLine("Please Enter Valid Date format");
                        userInput = Console.ReadLine();
                    }
                }
            }
            catch( Exception e)
            {
                throw new Exception();
            }
            
        }

        // get from date from user
        internal DateTime ValidateFromDate( string userInput)
        {
            try
            {
                bool isValid = false;
                while (!isValid)
                {
                    IsValidFormat(userInput);

                    isValid = _dateResult < DateTime.Today;
                    if (!isValid)
                    {
                        Console.WriteLine("From Date should be less than today's date ");
                        userInput = Console.ReadLine();
                    }
                }
            }
            catch(Exception e)
            {
                throw new Exception();
            }
            return _dateResult;
        }

        // get to date from user
        internal DateTime ValidateToDate( string userInput , DateTime fromDate)
        {
            try
            {
                bool isValid = false;
                while (!isValid)
                {
                    IsValidFormat(userInput);

                    isValid = _dateResult >= fromDate;
                    if (!isValid)
                    {
                        Console.WriteLine("To Date should be greater than From date ");
                        userInput = Console.ReadLine();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception();
            }

            return _dateResult;
        }
      
        // to calculate the difference between dates
        public void Difference(DateTime toDate, DateTime fromDate)
        {
            try
            {
                int years = toDate.Year - fromDate.Year;
                int months = toDate.Month - fromDate.Month;
                int days = toDate.Day - fromDate.Day;

                if (months < 0)
                {
                    months = 11 - (fromDate.Month - toDate.Month);
                    days = (30 - fromDate.Day) + toDate.Day;
                    years = years - 1;
                }

                if (days > 29)
                {
                    days = days - 30;
                    months = months + 1;
                }

                Console.WriteLine("{0} years, {1} months, {2} days", years, months, days);
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }

        public void DaysDifference()
        {
            try
            {
                GetAppInfo();
                Console.WriteLine("Date Format should be dd/mm/yyyy\nEnter From Date:");

                DateTime fromDate = ValidateFromDate(Console.ReadLine());

                Console.WriteLine( "Enter To Date" );
                DateTime toDate = ValidateToDate(Console.ReadLine() , fromDate);

                Difference(toDate, fromDate);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        internal static void GetAppInfo()
        {
            string appName = "Days Difference";
            string appVersion = "1.0.0";
            string author = "Lakshay Guglani";
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine($"{appName}: Version {appVersion} by {author}");
            Console.ResetColor();
        }
    }
}
