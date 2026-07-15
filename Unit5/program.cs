using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace IT232_Unit_5_Assignment
{//*********************************************************

//****Assignment 5 Section 1

//*********************************************************
    class Program
    {
        static void Main(string[] args)
        {
            // Section 1: Initial produce list
            List<string> produceList = new()
            {
                "bananas 0.59",
                "grapes 2.99",
                "apples 1.49",
                "pears 1.39",
                "lettuce 0.99",
                "onions 0.79",
                "potatoes 0.59",
                "peaches 1.59"
            };

            // Write initial list to file
            File.WriteAllLines("ProducePrice.txt", produceList);

            Console.WriteLine($"There are {FileLineCount("ProducePrice.txt")} products in the file.");

//*********************************************************

//****Assignment 5 Section 2

//*********************************************************
            var additionalItems = new[]
            {
                "peppers 0.99",
                "celery 1.29",
                "cabbage 0.79",
                "tomatoes 1.19"
            };

            File.AppendAllLines("ProducePrice.txt", additionalItems);

            Console.WriteLine($"There are {FileLineCount("ProducePrice.txt")} products in the file.");
            Console.WriteLine();

//*********************************************************

//****Assignment 5 Section 3

//*********************************************************
            var producePrices = File.ReadLines("ProducePrice.txt").ToList();

            for (int i = 0; i < producePrices.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {producePrices[i]}");
            }

            Console.WriteLine();
            Console.WriteLine($"There are {producePrices.Count} products in the producePrices list.");

            Console.ReadLine();
        }

        static int FileLineCount(string filename)
        {
            return File.ReadLines(filename).Count();
        }
    }
}
