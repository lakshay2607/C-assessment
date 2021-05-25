using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Assessment2_BL
{
    public class DirectoryStructure
    {
        //print all files name in the Directory object
        internal void GetFiles( DirectoryInfo directory, int space)
        {
            try
            {
                FileInfo[] files = directory.GetFiles();

                foreach (FileInfo fileIterator in files)
                {
                    PrintSpace(space);
                    Console.WriteLine("-" + fileIterator.Name);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //print all the nested directories
        internal void GetDirectories( string path, int space )
        {
            try
            {
                // created object of current directory
                DirectoryInfo currentDirectory = new DirectoryInfo(path);

                // to get all the files at current directory
                GetFiles(currentDirectory, space);

                //iterate through each Sub Directory
                DirectoryInfo[] nestedDirectories = currentDirectory.GetDirectories();
                foreach (DirectoryInfo iterator in nestedDirectories)
                {
                    PrintSpace(space);
                    Console.WriteLine("--" + iterator.Name);
                    GetDirectories(iterator.FullName, space + 1);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //to print the spaces for nested directories
        internal void PrintSpace(int spaceCount)
        {
            for (int i = 0; i < spaceCount; i++)
            {
                Console.Write("  ");
            }
        }

        public void DirectoryMethod()
        {
            GetAppInfo();
            Console.WriteLine("Please Enter Directory Path");
            string path = Console.ReadLine();

            GetDirectories(path, 0);
        }
        internal void GetAppInfo()
        {
            string appName = "Directory Tree Structure";
            string appVersion = "1.0.0";
            string author = "Lakshay Guglani";
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine($"{appName}: Version {appVersion} by {author}");
            Console.ResetColor();
        }
    }
}
