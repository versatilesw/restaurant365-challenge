using System;

namespace StringCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Calculator();

            Console.WriteLine("String Calculator");
            Console.WriteLine("Enter numbers separated by commas or newlines (e.g., 1,2 followed by Enter and then 3):");
            Console.WriteLine("Type 'done' on a new line to calculate the result.");

            while (true)
            {
                Console.WriteLine("\nStart entering numbers (type 'exit' to quit):");
                string input = string.Empty;
                string line;

                while (true)
                {
                    line = Console.ReadLine();

                    if (line?.ToLower() == "exit")
                    {
                        Console.WriteLine("Goodbye!");
                        return;
                    }

                    if (line?.ToLower() == "done")
                    {
                        break;
                    }

                    input += line + "\n";
                }

                try
                {
                    var result = calculator.Add(input.TrimEnd('\n'));
                    Console.WriteLine($"Result: {result}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
