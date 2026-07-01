//*********************************************************
//**** Assignment 3 Section 1
//*********************************************************

using System;
using System.Collections.Generic;

namespace IT232_Unit_3_Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            // Constants for array dimensions; it seem a little sloppy to keep repeating the same constants, but I will keep them for clarity in each section
            const int ROWS = 4;
            const int COLS = 4;

            // **** Assignment 3 Section 1

            // Create a two-dimensional string array of 4x4 elements named salesRegions
            string[,] salesRegions = new string[ROWS, COLS];

            // Populate the array with names of sales regions (column 0)
            salesRegions[0, 0] = "North";
            salesRegions[1, 0] = "South";
            salesRegions[2, 0] = "East";
            salesRegions[3, 0] = "West";

            // Populate personnel names
            salesRegions[0, 1] = "Bob";
            salesRegions[0, 2] = "Stef";
            salesRegions[0, 3] = "Ron";

            salesRegions[1, 1] = "Sue";
            salesRegions[1, 2] = "Janice";
            salesRegions[1, 3] = "Will";

            salesRegions[2, 1] = "Nathan";
            salesRegions[2, 2] = "Henry";
            salesRegions[2, 3] = "Kimmy";

            salesRegions[3, 1] = "Wanda";
            salesRegions[3, 2] = "Charles";
            salesRegions[3, 3] = "Pete";

            Console.WriteLine("Section 1: Two-dimensional Array.\n");

            // Display the contents of the array by sales region
            for (int row = 0; row < ROWS; row++)
            {
                for (int col = 0; col < COLS; col++)
                {
                    Console.WriteLine(salesRegions[row, col]);
                }

                Console.WriteLine();
            }

            //*********************************************************
            //**** Assignment 3 Section 2
            //*********************************************************

            // Create a List<string> called salesTeam; Lists are a little more flexible than arrays for the output of text, where I can pass in array arguments and then remove them later if needed.  I will use the List<string> to store the names of the sales team members from the salesRegions array.
    
            List<string> salesTeam = new List<string>();

            // Add names from the North region (row 0, columns 1–3)
            for (int col = 1; col < COLS; col++)
            {
                salesTeam.Add(salesRegions[0, col]);
            }

            Console.WriteLine("Section 2: ArrayList.\n");

            // Display current number of elements
            Console.WriteLine($"There are {salesTeam.Count} names in the salesTeam list.\n");

            // Add names from the South region (row 1)
            for (int col = 1; col < COLS; col++)
            {
                salesTeam.Add(salesRegions[1, col]);
            }

            // Check if "Stef" is in the list
            if (salesTeam.Contains("Stef"))
            {
                Console.WriteLine("Stef is in the salesTeam list.");
            }
            else
            {
                Console.WriteLine("Stef is not in the salesTeam list.");
            }

            Console.WriteLine($"\nThere are {salesTeam.Count} names in the salesTeam list.\n");

            // Remove Janice and Ron
            salesTeam.Remove("Janice");
            salesTeam.Remove("Ron");

            Console.WriteLine($"There are {salesTeam.Count} names in the salesTeam list.\n");

            // Display remaining names
            Console.WriteLine("Names currently in the salesTeam list:");

            foreach (string name in salesTeam)
            {
                Console.WriteLine(name);
            }

            Console.Read();
        }
    }
}
