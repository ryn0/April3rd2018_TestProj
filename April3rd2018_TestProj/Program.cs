using System;

namespace April3rd2018_TestProj
{
    public class Program
    {
        static void Main(string[] args)
        {
            var dataFetcher = new DataFetcher();

            while (true)
            {
                Console.WriteLine("Please type an integer to lookup in the list, then press enter.");

                Console.Write("Input: ");
                var userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int intResult))
                {
                    Console.Write("Output: ");
                    Console.WriteLine(dataFetcher.FetchResult(intResult));
                }
                else
                {
                    Console.Write("Input was not an integer");
                }

                Console.WriteLine("-------------------------------------------------------");
            }
        }
    }
}
