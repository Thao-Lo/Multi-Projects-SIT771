using System;
using SplashKitSDK;

namespace HelloUser
{
    public class Program
    {
        public static void Main()
        {
            string name;
            string inputText;
            int heightInCM;
            double weightInKG;
            double heightInMeters;
            double bmi;

            Console.WriteLine("Hello, this is BMI calculator");
             // -- NAME --
            // prompt user input their name
            Console.WriteLine("Enter your name: ");
            name = Console.ReadLine()!;

            // string interpolation
            Console.WriteLine($"Hello {name}!!!");

             // -- HEIGHT --
            // prompt user input their height
            Console.WriteLine("Enter your height in centimeters: ");
            inputText = Console.ReadLine()!;

            // convert string to int
            heightInCM = Convert.ToInt32(inputText);
            heightInMeters = heightInCM / 100.0; 

            Console.WriteLine($"Your height in meters: {heightInMeters}m");

            // -- WEIGHT --
            // prompt user input their weight
            Console.WriteLine("Enter your weight in Kg: ");
            inputText = Console.ReadLine()!;
            //convert string to double
            weightInKG = Convert.ToDouble(inputText);

            Console.WriteLine($"Your weight: {weightInKG}Kg"); 

             // -- BMI --
            bmi = weightInKG / (heightInMeters * heightInMeters);
            Console.WriteLine($"Your BMI: {bmi}");           
        }
    }
}
