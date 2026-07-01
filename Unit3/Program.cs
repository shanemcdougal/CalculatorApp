//*********************************************************
//**** Assignment 3 — Arrays Only Version
//*********************************************************

using System;

namespace IT232_Unit_3_Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            //adding constants here for the array dimensions as it seemed wasteful to keep repeating the same numbers in multiple places
            const int ROWS = 4;
            const int COLS = 4;

            //*********************************************************
            //**** Section 1: Two-dimensional Array
            //*********************************************************

            string[,] salesRegions = new string[ROWS, COLS];

            // Populate regions
            salesRegions[0, 0] = "North";
            salesRegions[1, 0] = "South";
            salesRegions[2, 0] = "East";
            salesRegions[3, 0] = "West";

            // Populate personnel
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

            for (int row = 0; row < ROWS; row++)
            {
                for (int col = 0; col < COLS; col++)
                {
                    Console.WriteLine(salesRegions[row, col]);
                }
                Console.WriteLine();
            }

            //*********************************************************
            //**** Section 2: Arrays Instead of Lists
            //*********************************************************

            Console.WriteLine("Section 2: Arrays.\n");

            // Start with an empty array
            string[] salesTeam = new string[0];

            // Add names from North region (row 0, columns 1–3)
            for (int col = 1; col < COLS; col++)
            {
                salesTeam = AddToArray(salesTeam, salesRegions[0, col]);
            }

            Console.WriteLine($"There are {salesTeam.Length} names in the salesTeam array.\n");

            // Add names from South region (row 1)
            for (int col = 1; col < COLS; col++)
            {
                salesTeam = AddToArray(salesTeam, salesRegions[1, col]);
            }

            // Check if "Stef" is in the array
            if (Array.Exists(salesTeam, name => name == "Stef"))
            {
                Console.WriteLine("Stef is in the salesTeam array.");
            }
            else
            {
                Console.WriteLine("Stef is not in the salesTeam array.");
            }

            Console.WriteLine($"\nThere are {salesTeam.Length} names in the salesTeam array.\n");

            // Remove Janice and Ron
            salesTeam = RemoveFromArray(salesTeam, "Janice");
            salesTeam = RemoveFromArray(salesTeam, "Ron");

            Console.WriteLine($"There are {salesTeam.Length} names in the salesTeam array.\n");

            Console.WriteLine("Names currently in the salesTeam array:");
            foreach (string name in salesTeam)
            {
                Console.WriteLine(name);
            }

            Console.Read();
        }

        //*********************************************************
        //**** Helper Methods for Array Manipulation
        //*********************************************************

        // Adds an item to an array by creating a new resized array
        static string[] AddToArray(string[] array, string item)
        {
            string[] newArray = new string[array.Length + 1];
            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }
            newArray[newArray.Length - 1] = item;
            return newArray;
        }

        // Removes an item from an array by creating a new array without that item
        static string[] RemoveFromArray(string[] array, string item)
        {
            int count = 0;

            // Count how many items will remain
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != item)
                {
                    count++;
                }
            }

            string[] newArray = new string[count];
            int index = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != item)
                {
                    newArray[index++] = array[i];
                }
            }

            return newArray;
        }
    }
}
