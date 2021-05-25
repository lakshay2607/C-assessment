using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace Assessment2_BL
{
   public class CurrencyConversions
    {
        string _connectionString = "data source=BHAVNAWKS574;database=practice;integrated security=SSPI";
        internal void CheckExistingCurrency()
        {
            try
            {
                using( SqlConnection connection = new SqlConnection( _connectionString ))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("select count(*) from conversion_rate", connection);
                    int count = int.Parse( command.ExecuteScalar().ToString() );
                    connection.Close();

                    if( count > 0)
                    {
                        Console.WriteLine("Do you want to create new currency list. please enter yes or no");
                        string answer = Console.ReadLine();

                        if ( answer.ToLower().Equals("yes") )
                        {
                            CreatConversionList( );
                        }
                    }
                    else
                    {
                        CreatConversionList();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        internal void CreatConversionList()
        {
            try
            {
                string currencyName;
                decimal conversionRate;

                DeleteExistingList(); 
                
                for (int i = 1; ; i++)
                {
                    //check if list has atleast 5 values
                    if (i > 5)
                    {
                        Console.WriteLine("Do you want to add more currencies? please enter yes or no");
                        if (Console.ReadLine().ToLower().Equals("no"))
                            break;
                    }

                    //getting currency name and rate
                    Console.WriteLine("Please Enter Currency {0} :", i);
                    currencyName = Console.ReadLine();
                    Console.WriteLine("Please Enter {0} Conversion rate :", currencyName);
                    conversionRate = decimal.Parse( Console.ReadLine() );

                    AddCurrency( currencyName , conversionRate);
                }
            }
            catch( Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        
        //to delete existing list
        internal void DeleteExistingList()
        {
            using ( SqlConnection connection = new SqlConnection( _connectionString) )
            {
                connection.Open();
                SqlCommand command = new SqlCommand("delete from conversion_rate", connection);
                command.ExecuteNonQuery();
            }
        }
        //to add currency in the list
        internal void AddCurrency( string currencyName , decimal conversionRate )
        {
            using ( SqlConnection connection = new SqlConnection( _connectionString) )
            {
                connection.Open();
                SqlCommand command = new SqlCommand("insert into conversion_rate values('" + currencyName + "', " + conversionRate + " )", connection);
                command.ExecuteNonQuery();
            }

        }

        internal void Convert( string currency , decimal amount)
        {
            try
            {
                decimal rate = GetRate( currency );
                decimal result = rate * amount;
                Console.WriteLine("Converted Amount is : {0}", result.ToString("0.00"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //to get the corresponding rate
        internal decimal GetRate( string currency )
        {
            decimal rate = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection("data source=BHAVNAWKS574;database=practice;integrated security=SSPI"))
                {
                    SqlCommand command = new SqlCommand("select rate from conversion_rate where currency_Name = '" + currency + "';", connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        rate = (reader.GetDecimal(0));
                    }
                    // check for invalid currency
                    if (!(reader.HasRows))
                    {
                        Console.WriteLine("Currency does not exist. please enter a valid currency");
                        reader.Close();
                        connection.Close();
                        GetRate(Console.ReadLine());
                    }
                    reader.Close();
                }
            }
            catch( Exception e)
            {
                Console.WriteLine(e.Message );
            }
            return rate;
        }

        public void CurrencyConvert()
        {
            try
            {
                CheckExistingCurrency();

                Console.WriteLine("Enter Currency to be converted to INR");
                string currency = Console.ReadLine();

                Console.WriteLine("Enter Amount to be converted");
                decimal amount = decimal.Parse(Console.ReadLine());

                Convert(currency, amount);
            }
            catch( Exception e)
            {
                Console.WriteLine( e.Message );
            }

        }
    }
}
