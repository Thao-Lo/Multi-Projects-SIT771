using System;
using SplashKitSDK;

namespace Array
{
    public class Program
    {
        private static List<double> _value = new List<double>(); // Init a new List

        public enum UserOption
        {
            NewValue, Print, Sum, Quit
        }
        public static void Main()
        {
            UserOption option;
            // Promp user to select a option
            do
            {
                option = ReadUserOption(); // Ask for user input each time
                switch (option)
                {
                    case UserOption.NewValue:
                        AddValueToList();
                        break;
                    case UserOption.Sum:
                        Sum();
                        break;
                    case UserOption.Print:
                        Print();
                        break;
                    case UserOption.Quit:
                        //Exit the loop
                        break;
                }
            } while (option != UserOption.Quit);
        }
        public static void AddValueToList() // add user input value to List
        {
            double value = ReadDouble("Please add a number: ");
            _value.Add(value);
            Console.WriteLine();
        }
        public static void Print()  // Loop through the List and Print all numbers
        {
            Console.WriteLine("Print all the values: ");
            foreach (double v in _value)
            {
                Console.WriteLine($"Number: {v}");
            }
            Console.WriteLine();
        }
        public static void Sum() // Loop through the List and get sum of all numbers 
        {
            double sum = 0;
            foreach (double v in _value)
            {
                sum += v;
            }
            Console.WriteLine($"Sum of all number(s): {sum}");
            Console.WriteLine();
        }
        public static UserOption ReadUserOption()
        {

            Console.WriteLine("Enter 0 to add a value");
            Console.WriteLine("Enter 1 to print all values");
            Console.WriteLine("Enter 2 to print a sum all values");
            Console.WriteLine("Enter 3 to quit");
            int option = ReadInteger("Please select an option: "); // Only valid interger within range 0-3

            return (UserOption)option;
        }

        public static int ReadInteger(string prompt)
        {
            Console.Write(prompt);
            while (true) // Only accept Integer
            {
                try
                {
                    return Int32.Parse(Console.ReadLine()!);
                }
                catch
                {
                    Console.Write("Please enter a valid integer: ");
                }
            }
        }
        public static double ReadDouble(string prompt)
        {
            Console.Write(prompt);
            while (true) // Only accept Double
            {
                try
                {
                    return Double.Parse(Console.ReadLine()!);
                }
                catch
                {
                    Console.Write("Please enter a valid number: ");
                }
            }
        }

    }
}
