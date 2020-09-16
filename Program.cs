using System;
using System.Collections.Generic;
using System.Linq;

namespace SearchStringAlgo
{
    class Program
    {
        static void Main(string[] args)
        {
           try
            {
                Console.WriteLine("=============================");
                Console.WriteLine("Press ESC to stop");
                Console.WriteLine("Press ANY KEY to start");
                Console.WriteLine("=============================");

             
                while (Console.ReadKey(true).Key != ConsoleKey.Escape)
                        {

                        Console.Write("Enter a string: ");

                    string strToken = Console.ReadLine();

                    while (string.IsNullOrEmpty(strToken))
                    {
                        Console.WriteLine("Enter a valid string!");
                        Console.Write("Enter a string: ");
                        strToken = Console.ReadLine();
                    }


                    Console.Write("Enter a size: ");

                        int size = 0;

                        while (!int.TryParse(Console.ReadLine(), out size))
                        {
                            Console.WriteLine("Enter a valid number!");
                            Console.Write("Enter a size: ");
                        }

                        var tokensCollection = SearchString(strToken, size);

                    if (tokensCollection.Count == 0) Console.WriteLine("No results found.");

                        foreach (var item in tokensCollection)
                        {
                            Console.WriteLine($" {item.Key} occurs {item.Value} times");
                        }

                    Console.WriteLine("=============================");
                    Console.WriteLine("Press ESC to stop");
                    Console.WriteLine("Press ANY KEY to start");
                    Console.WriteLine("=============================");
                }
             

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }            
        }

        static Dictionary<string,int> SearchString(string token, int size)
        {
            var tokensDictionary = new Dictionary<string, int>();
            var tokensList = ConvertStringToList(token, size);

            foreach (var item in tokensList)
            {
                var count = tokensList.FindAll(x => x == item).Count();
                if (!tokensDictionary.ContainsKey(item) && (count > 1))
                    tokensDictionary.Add(item, count);
            }

            return tokensDictionary;
        }

        static List<string> ConvertStringToList(string value, int size)
        {
            var subTokensList = new List<string>();

            for (int i = 0; i <= value.Length - size; i++)
            {
                subTokensList.Add(value.Substring(i, size));
            }

            return subTokensList;
        }       

    }
}
