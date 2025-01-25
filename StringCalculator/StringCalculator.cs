namespace StringCalculator
{
    public class Calculator
    {
        public int Add(string input, out List<int> parsedNumbers)
        {
            parsedNumbers = new List<int>();

            if (string.IsNullOrWhiteSpace(input))
            {
                return 0;
            }

            var delimiters = new List<string> { ",", "\n" };

            if (input.StartsWith("//"))
            {
                if (input[2] == '[')
                {
                    int endIndex = input.IndexOf("\n");
                    if (endIndex > 3)
                    {
                        string delimiterSection = input.Substring(2, endIndex - 2);
                        var matches = System.Text.RegularExpressions.Regex.Matches(delimiterSection, "\\[(.*?)\\]");

                        foreach (System.Text.RegularExpressions.Match match in matches)
                        {
                            delimiters.Add(match.Groups[1].Value);
                        }

                        input = input.Substring(endIndex + 1);
                    }
                }
                else if (input.Length > 3 && input[3] == '\n')
                {
                    delimiters.Add(input[2].ToString());
                    input = input.Substring(4);
                }
            }

            var numbers = input.Split(delimiters.ToArray(), StringSplitOptions.None).ToArray();

            parsedNumbers = numbers.Select(ParseNumber).ToList();

            var negativeNumbers = parsedNumbers.Where(n => n < 0).ToList();
            if (negativeNumbers.Any())
            {
                throw new ArgumentException($"Negative numbers are not allowed: {string.Join(", ", negativeNumbers)}");
            }

            return parsedNumbers.Sum();
        }

        // Overloaded version without the out parameters
        public int Add(string input)
        {
            return Add(input, out _); // Calls the original method but ignores out parameters
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
