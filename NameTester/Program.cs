using System;
using System.Numerics;
using System.Runtime.InteropServices;
using SplashKitSDK;

namespace NameTester
{
    public enum MenuOption //declare enum values
    {
        TestName,
        GuessThatNumber,
        Quit
    }
    public class Program
    {
        public static void Main()
        {
            MenuOption userSelection = ReadUserOption(); //return user selection == enum value
            do
            {
                switch (userSelection)
                {
                    case MenuOption.TestName:
                        TestName(); //user enter their name
                        userSelection = ReadUserOption(); // show selection again
                        break;
                    case MenuOption.GuessThatNumber:
                        RunGuessThatNumber(); // user select a random number until == target number
                        userSelection = ReadUserOption();
                        break;
                    case MenuOption.Quit:
                        break;
                }
            } while (userSelection != MenuOption.Quit); //keep running until user select 3/Quit
            Console.WriteLine("Bye. ");
        }

        private static MenuOption ReadUserOption()
        {
            int option = -1; 
            do
            {
                Console.WriteLine("Select 1 option [1-3]:");
                Console.WriteLine("1 - Test Name");
                Console.WriteLine("2 - Guess A Number");
                Console.WriteLine("3 - Quit");
                try
                {
                    option = Convert.ToInt32(Console.ReadLine());
                }
                catch //invalid number: out of range
                {
                    option = -1; //init option again
                }
            } while (option < 1 || option > 3);


            return (MenuOption)(option - 1); //enmum value start from 0
        }
        public static void TestName()
        {
            string name = "";
            do
            {
                Console.Write("Please enter your name: ");
                name = Console.ReadLine();

            } while (name.Equals("")); //prompt user input their name, not leave it empty

            Console.WriteLine($"Hello + {name}");

            // if-else statement
            if (name == "Zavis" || name.ToLower() == "zavis")
            {
                Console.WriteLine("Welcome my creator!"); //print message
            }
            else if (name == "Sam" || name.ToLower() == "sam")
            {
                Console.WriteLine("Welcome my co-founder!"); //print message
            }
            else
            {
                Console.WriteLine($"Welcome {name} to the OOP world"); //print message
            }
        }
        private static int ReadGuess(int min, int max) // show the min - max range, return user input value
        {
            int guessNum = -1;
            do
            {
                Console.WriteLine($"Enter your guess between: {min} - {max} ");
                try
                {
                    guessNum = Convert.ToInt32(Console.ReadLine());

                }
                catch // invalid number: out of range
                {
                    guessNum = -1; //init guess again
                }

            } while (guessNum < min || guessNum > max);
            return guessNum;
        }
        private static void RunGuessThatNumber()
        {
            int target = new Random().Next(100) + 1; // (0 - 99) + 1
            int userGuessNum = -1; 

            int lowestGuess = 1;
            int highestGuest = 100;

            Console.WriteLine("Guess a number between 1 and 100. ");

            // run until user select correct value == target
            while (userGuessNum != target)
            {
                userGuessNum = ReadGuess(lowestGuess, highestGuest); // call method to get user input value

                if (userGuessNum < target)
                {
                    Console.WriteLine("Your number is lower than Target Number");
                    Console.WriteLine("Try Again!!");
                    lowestGuess = userGuessNum; //update min (guess, max)
                }
                else if (userGuessNum > target)
                {
                    Console.WriteLine("Your number is greater than Target Number");
                    Console.WriteLine("Try Again!!");
                    highestGuest = userGuessNum; //update max (min, guess)
                }
                else
                {
                    Console.WriteLine($"Your answer {userGuessNum} is correct!");
                }
            }

        }
    }
}
