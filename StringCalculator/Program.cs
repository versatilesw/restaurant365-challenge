﻿using System;

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
                Console.WriteLine("\nStart entering numbers:");
                string input = string.Empty;
                string line;

                while (true)
                {
                    line = Console.ReadLine();

                    if (line?.ToLower() == "done")
                    {
                        break;
                    }

                    input += line + "\n";
                }

                try
                {
                    var result = calculator.Add(input.TrimEnd('\n'), out var parsedNumbers);
                    // Display the formula
                    string formula = string.Join("+", parsedNumbers.Select(n => n.ToString()));
                    Console.WriteLine($"{formula} = {result}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
