using System;
using System.IO;

namespace IN255_McDougal_Unit7
{
    class Program
    {
        static string logFileName;

        static void Main(string[] args)
        {
            Console.WriteLine("Assignment 7 – Logging Exceptions to a File.");
            Console.WriteLine("Testing Try/Catch for Divide by Zero, File Does Not Exist, Array Out of Bounds, and Array is Null scenarios.");
            Console.WriteLine("All console error messages are printed from error log file.");
            Console.WriteLine("");

            // Create logfile and redirect stderr
            logFileName = "log.txt";
            TextWriter errStream = new StreamWriter(logFileName);
            Console.SetError(errStream);

            // 1. TEST: DivideByZero
            try
            {
                DivideByZero();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }

            // 2. TEST: FileDoesNotExist
            try
            {
                FileDoesNotExist();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }

            // 3. TEST: ArrayOutOfBounds
            try
            {
                ArrayOutOfBounds();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }

            // 4. TEST: ArrayIsNull
            try
            {
                ArrayIsNull();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }

            // Flush and close the redirected error stream
            errStream.Flush();
            Console.Error.Close();

            // Display log file contents
            DisplayLogFile(logFileName);

            Console.ReadLine();
        }

        // Reads the log file and prints it to the console
        public static void DisplayLogFile(string logFileName)
        {
            using (FileStream fs = new FileStream(logFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (StreamReader sr = new StreamReader(fs))
            {
                while (!sr.EndOfStream)
                {
                    Console.WriteLine(sr.ReadLine());
                }
            }
        }

        // 1. Throw: Divide by zero
        public static void DivideByZero()
        {
            int num1 = 15;
            int num2 = 0;
            int result = num1 / num2;   // throws exception
        }

        // 2. Throw: File does not exist
        public static void FileDoesNotExist()
        {
            using (StreamReader reader = new StreamReader("NoFileNamedThis.txt"))
            {
                while (reader.ReadLine() != null) { }
            }
        }

        // 3. Throw: Array out of bounds
        public static void ArrayOutOfBounds()
        {
            string[] names = { "Ed", "Fred", "Ted", "Mel", "Stan" };

            // names.Length = 5, valid indexes 0–4
            // Looping <= causes index 5 access → exception
            for (int i = 0; i <= names.Length; i++)
            {
                string name = names[i];
            }
        }

        // 4. Throw: Array is null
        public static void ArrayIsNull()
        {
            string[] names = { "Ed", "Fred", "Ted", "Mel", "Stan" };
            names = null;
            string name = names[2];   // throws null reference exception
        }
    }
}
