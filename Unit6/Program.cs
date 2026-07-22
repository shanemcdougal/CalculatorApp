using System;
using System.Diagnostics;
using System.IO;

namespace IT232_McDougal_Unit6
{
    class Program
    {
        static void Main(string[] args)
        {
            //*********************************************************
            //****Assignment 6 Section 1
            //*********************************************************

            Console.WriteLine("Assignment 6 – Asserts and Try/Catch.");

            string value = string.Empty;   // intentionally empty
            int number = 0;                // intentionally zero

            Debug.Assert(!string.IsNullOrEmpty(value), "Parameter must not be empty or null.");
            Debug.Assert(number > 0, "Parameter must be greater than zero.");

            //*********************************************************
            //****Assignment 6 Section 2
            //*********************************************************

            try
            {
                string[] names = { "Ed", "Fred", "Ted", "Mel", "Stan" };

                // Intentionally incorrect loop condition to trigger exception
                for (int i = 0; i <= names.Length; i++)
                {
                    string someName = names[i];
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ArrayOutOfBounds error occurred");
                Console.WriteLine(ex.Message.ToString());
            }

            //*********************************************************
            //****Assignment 6 Section 3
            //*********************************************************

            try
            {
                using (StreamReader file = new StreamReader("NoFileNamedThis.txt"))
                {
                    string line;
                    while ((line = file.ReadLine()) != null)
                    {
                        // do nothing, just reading
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("FileDoesNotExist error occurred");
                Console.WriteLine(ex.Message.ToString());
            }

            //*********************************************************
            //****Assignment 6 Section 4
            //*********************************************************

            try
            {
                DivideByZero(42, 0); // intentionally triggers exception
            }
            catch (Exception ex)
            {
                Console.WriteLine("DivideByZero error occurred");
                Console.WriteLine(ex.Message.ToString());
            }

            Console.ReadLine();
        }

        public static int DivideByZero(int num1, int num2)
        {
            if (num2 == 0)
            {
                throw new Exception("Divide By Zero");
            }

            return num1 / num2;
        }
    }
}
