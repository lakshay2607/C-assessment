using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment2_BL
{
   public class CapitalisedWord
    {
        internal string Caplitalise(string inputString)
        {
            try
            {
                bool isValid;
                string[] inputWords = inputString.Split(' ');
                string[] check = { "and", "or", "but", "nor", "yet", "so", "for", "a", "an", "the", "in", "to", "of", "at", "by", "up", "for", "off", "on" };

                // iterate each input word to change case of first letter
                for (int i = 0; i < inputWords.Length; i++)
                {
                    isValid = true;
                    //check each word for preposition, article , conjuction
                    for ( int j = 0; j < check.Length; j++ )
                    {
                        if( inputWords[i].Equals(check[j]) )
                        {
                            isValid = false;
                            break;
                        }
                    }
                    if ( isValid )
                    {
                        inputWords[i] = char.ToUpper(inputWords[i][0]) + inputWords[i].Substring(1);
                    }
                }
                return string.Join(" ", inputWords);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return "";
        }

        public void CapitalisedWords()
        {
            try
            {
                GetAppInfo();
                Console.WriteLine( "Enter the string" );
                string inputString = Console.ReadLine();
  
                string result = Caplitalise(inputString);
                Console.WriteLine((result));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        internal static void GetAppInfo()
        {
            string appName = "Captalised Words";
            string appVersion = "1.0.0";
            string author = "Lakshay Guglani";
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine($"{appName}: Version {appVersion} by {author}");
            Console.ResetColor();
        }
    }
}
