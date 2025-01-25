using System;

namespace StringCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Calculator();

            Console.WriteLine("String Calculator");
            Console.WriteLine("Enter numbers separated by commas (e.g., 1,2,3):");

            while (true)
            {
                Console.Write("Input: ");
                var input = Console.ReadLine();

                if (input?.ToLower() == "exit")
                {
                    break;
                }

                try
                {
                    var result = calculator.Add(input);
                    Console.WriteLine($"Result: {result}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            Console.WriteLine("Goodbye!");
        }
    }
}