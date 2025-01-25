﻿namespace StringCalculator
{
    public class Calculator
    {
        public int Add(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return 0;
            }
            var delimiters = new[] { ',', '\n' };
            var numbers = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).ToArray();

            return numbers.Select(ParseNumber).Sum();
        }

        private int ParseNumber(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return 0;
            }

            return int.TryParse(value, out int result) ? result : 0;
        }
    }
}
