 public class ArrayClass
    {
        public static void ArrayMain()
        {
            String prompt = "How many numbers you want to add? ";
            int numberOfValues = ReadInteger(prompt);

            // Create an array has "double" values with size that user input
            double[] values = new double[numberOfValues];

            // Loop through each index to get the correct input value (double)
            for (int i = 0; i < numberOfValues; i++)
            {
                values[i] = ReadDouble($"Enter the {i + 1}st value: ");
            }

            Console.WriteLine();
            Console.WriteLine("ALl the input numbers: ");
            // Print all the values in array
            for (int i = 0; i < numberOfValues; i++)
            {
                Console.WriteLine($"Number {i + 1}: {values[i]}");
            }

            // Loop through the array and calculate sum
            double sum = 0;
            foreach (double b in values)
            {
                sum += b;
            }
            Console.WriteLine($"Sum of all number(s): {sum}");

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
                    Console.WriteLine("Please enter a valid integer");
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
                    Console.WriteLine("Please enter a valid decimal number");
                }
            }
        }
    }