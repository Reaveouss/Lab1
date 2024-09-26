using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Program
    {
        static Random randomGenerator = new Random();
        static void Main(string[] args)
        {
            MainMenu();
            Console.ReadKey();
        }
        static void Number(bool search)
        {
            List<double> listOfDoubles = new List<double>();

            PopulateListWithRandomDoubles(ref listOfDoubles, 10);
            PrintList(listOfDoubles);

            RequestSearch(listOfDoubles, search);
            PrintList(listOfDoubles);
            Console.ReadKey();
        }
        static void Letter(bool search)
        {
            List<double> listOfDoubles = new List<double>();

            PopulateListWithRandomLetters(ref listOfDoubles, 10);
            PrintList(listOfDoubles);

            RequestSearch(listOfDoubles, search);
            PrintList(listOfDoubles);
            Console.ReadKey();
        }
        private static void MainMenu()
        {
            while (true)
            {
                bool letters = true;
                Console.Clear();
                Console.WriteLine("Please choose what you would like to search from: ");
                Console.WriteLine("1. Random Numbers");
                Console.WriteLine("2. Random Words/Letters");
                Console.WriteLine("\n");
                Console.WriteLine("0. Exit aplication");
                Console.WriteLine("\n");
                string userInput1 = Console.ReadLine();
                if (int.TryParse(userInput1, out int result1))
                {
                    switch (result1)
                    {
                        case 0:
                            Environment.Exit(0);
                            break;
                        case 1:
                            letters = true;
                            break;
                        case 2:
                            letters = false;
                            break;
                    }
                }
                bool search;
                Console.Clear();
                Console.WriteLine("Please choose which form of searching you would like: ");
                Console.WriteLine("1. Linear");
                Console.WriteLine("2. Binary");
                Console.WriteLine("\n");
                Console.WriteLine("0. Exit aplication");
                Console.WriteLine("\n");

                string userInput2 = Console.ReadLine();
                if (int.TryParse(userInput2, out int result2))
                {
                    switch (result2)
                    {
                        case 0:
                            Environment.Exit(0);
                            break;
                        case 1:
                            search = true;
                            if (letters == true)
                            {
                                Letter(search);
                            }
                            else if (letters == false)
                            {
                                Number(search);
                            }
                            break;
                        case 2:
                            search = false;
                            if (letters == true)
                            {
                                Letter(search);
                            }
                            else if (letters == false)
                            {
                                Number(search);
                            }
                            break;
                    }
                }
            }
        }
        static void RequestSearch(List<double> list, bool search)
        {
            DateTime start;
            TimeSpan time;
            Double searchValue;
            Console.WriteLine("What value would you like to search for? ");
            if (Double.TryParse(Console.ReadLine(), out searchValue))
            {
                start = DateTime.Now;
                int index = 0;
                if (search == true)
                {
                    index = LinearSearch.Perform(searchValue, list);
                }
                else
                {
                    index = BinarySearch.Perform(searchValue, list);
                }
                if (index < 0)
                {
                    Console.WriteLine("NOT FOUND");
                }
                else
                {
                    Console.WriteLine("Found at: " + index);
                }
                time = DateTime.Now - start;
                Console.WriteLine(time + " = time elapsed");
            }
        }
        static void PopulateListWithRandomDoubles(ref List<double> list, int size)
        {
            for (int i = 0; i < size; i++)
            {
                double fiveDigitDouble = Double.Parse(randomGenerator.NextDouble().ToString("0.00000"));
                list.Add(fiveDigitDouble);
            }
            list.Sort();
        }
        static void PrintList(List<double> list)
        {
            Console.WriteLine("\n\nList Print: \n");
            for (int i = 0;i < list.Count;i++)
            {
                Console.WriteLine(" " + list[i].ToString());
            }
            Console.WriteLine("\nEND \n");
        }
    }
}
