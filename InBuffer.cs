using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment2_BL
{
    public class InBuffer
    {
        // to create new buffer
        internal void CreateBuffer(int length)
        {
            try
            {
                Queue<string> queue = new Queue<string>();

                // loop breaks when user enters ? to print values
                while (true)
                {
                    string userInput = Console.ReadLine();
                    if ( userInput.Equals("?") )
                    {
                        PrintValues(queue);
                        break;
                    }
                    else
                    {
                        if (queue.Count == length)
                        {
                            OverwriteBuffer( queue, userInput );
                        }
                        else
                        {
                            queue.Enqueue( userInput );
                        }
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        // to print the values in buffer
        internal void PrintValues( Queue<string> queue )
        {
            try
            {
                if (queue.Count == 0)
                {
                    Console.WriteLine("Buffer is empty");
                }
                else
                {
                    foreach (string iterator in queue)
                    {
                        Console.WriteLine(iterator);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        // to overwrite the oldest values in the buffer
        internal void OverwriteBuffer( Queue<string> queue, string userInput )
        {
            try
            {

                Console.WriteLine("Buffer is full. Do you want to overwrite oldest Element . please enter yes to continue or press ? to show Elements");
                string input = Console.ReadLine();
                if ( input.ToLower().Equals("yes"))
                {
                    queue.Dequeue();
                    queue.Enqueue( userInput );
                }
                if( input.Equals("?") )
                {
                    PrintValues(queue);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void InBufferMethod()
        {
            try
            {
                GetAppInfo();
                Console.WriteLine("Please Enter Length of Buffer");
                int length = Int32.Parse(Console.ReadLine());

                Console.WriteLine("Please Enter Elements");
                CreateBuffer(length);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        internal void GetAppInfo()
        {
            string appName = "In Memory Buffer";
            string appVersion = "1.0.0";
            string author = "Lakshay Guglani";
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine($"{appName}: Version {appVersion} by {author}");
            Console.ResetColor();
        }
    }
}
