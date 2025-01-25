namespace StringCalculator
{
    public class Calculator
    {
        public int Add(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return 0;
            }

            var delimiters = new List<string> { ",", "\n" };

            if (input.StartsWith("//"))
            {
                if (input[2] == '[')
                {
                    int endIndex = input.IndexOf("]\n");
                    if (endIndex > 3)
                    {
                        string customDelimiter = input.Substring(3, endIndex - 3);
                        delimiters.Add(customDelimiter);
                        input = input.Substring(endIndex + 2); // Skip past "]\n"
                    }
                }
                else if (input.Length > 3 && input[3] == '\n')
                {
                    delimiters.Add(input[2].ToString());
                    input = input.Substring(4);
                }
            }

            var numbers = input.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();

            var parsedNumbers = numbers.Select(ParseNumber).ToList();

            var negativeNumbers = parsedNumbers.Where(n => n < 0).ToList();
            if (negativeNumbers.Any())
            {
                throw new ArgumentException($"Negative numbers are not allowed: {string.Join(", ", negativeNumbers)}");
            }

            return parsedNumbers.Sum();
        }

        private int ParseNumber(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return 0;
            }

            return int.TryParse(value, out int result) && result <= 1000 ? result : 0;
        }
    }
}
