using System;
using System.Collections;
using System.Collections.Generic;

namespace IT232_Unit_4_Assignment
{
    class Program
    {
        struct structCar
        {
            public string make;
            public string model;
            public int modelYear;
        }

        static void Main(string[] args)
        {
            //*********************************************************
            //****Assignment 4 Section 1
            //*********************************************************

            structCar[] cars = new structCar[3]; // I took a different approach to this assignment. I created a struct and then created an array of that struct. I then populated the array with the data from the assignment.
            
            cars[0] = new structCar { make = "Ford",      model = "Mustang",  modelYear = 2010 };
            cars[1] = new structCar { make = "Chevrolet", model = "Silverado", modelYear = 2008 };
            cars[2] = new structCar { make = "Dodge",     model = "Charger",  modelYear = 2012 };

            Console.WriteLine("Section 1: Array of Structures");
            for (int i = 0; i < cars.Length; i++)
            {
                Console.WriteLine($"{cars[i].make} {cars[i].model} {cars[i].modelYear}");
            }

            //*********************************************************
            //****Assignment 4 Section 2
            //*********************************************************

            Console.WriteLine();
            Console.WriteLine("Section 2: Inventory Count");

            Dictionary<string, int> inventoryCount = new Dictionary<string, int>
            {
                { "Mustang", 9 },
                { "Silverado", 13 },
                { "Charger", 4 }
            };

            Console.WriteLine($"There are {inventoryCount["Mustang"]} Mustangs.");
            Console.WriteLine($"There are {inventoryCount["Silverado"]} Silverados.");
            Console.WriteLine($"There are {inventoryCount["Charger"]} Chargers.");

            //*********************************************************
            //****Assignment 4 Section 3
            //*********************************************************

            Console.WriteLine();
            Console.WriteLine("Section 3: Days of the Week");

            ArrayList daysOfWeek = new ArrayList
            {
                "Sunday", "Monday", "Tuesday", "Wednesday",
                "Thursday", "Friday", "Saturday"
            };

            foreach (var day in daysOfWeek)
                Console.WriteLine(day);

            Console.WriteLine();
            Console.WriteLine("Days of the week in reverse:");

            for (int i = daysOfWeek.Count - 1; i >= 0; i--)
                Console.WriteLine(daysOfWeek[i]);

            ArrayList workDays = new ArrayList();
            workDays.AddRange(daysOfWeek);
            workDays.Remove("Saturday");
            workDays.Remove("Sunday");

            Console.WriteLine();
            Console.WriteLine("Work days:");
            foreach (var day in workDays)
                Console.WriteLine(day);

            //*********************************************************
            //****Assignment 4 Section 4
            //*********************************************************

            Console.WriteLine();
            Console.WriteLine("Section 4: Stack");

            Stack<int> myStack = new Stack<int>();
            myStack.Push(10);
            myStack.Push(24);
            myStack.Push(31);
            myStack.Push(45);
            myStack.Push(19);
            myStack.Push(76);

            Console.WriteLine($"There are {myStack.Count} items on the stack.");

            myStack.Pop();
            myStack.Pop();
            myStack.Pop();

            Console.WriteLine($"There are {myStack.Count} items on the stack.");
            Console.WriteLine($"The next item to be popped from the stack is {myStack.Peek()}.");

            //*********************************************************
            //****Assignment 4 Section 5
            //*********************************************************

            Console.WriteLine();
            Console.WriteLine("Section 5: Queue");

            Queue<int> q = new Queue<int>();
            q.Enqueue(10);
            q.Enqueue(24);
            q.Enqueue(31);
            q.Enqueue(45);
            q.Enqueue(19);
            q.Enqueue(76);

            Console.WriteLine($"There are {q.Count} items in the queue.");

            q.Dequeue();
            q.Dequeue();
            q.Dequeue();

            Console.WriteLine($"There are {q.Count} items in the queue.");
            Console.WriteLine($"The next item to be dequeued from the queue is {q.Peek()}.");

            Console.ReadLine();
        }
    }
}
