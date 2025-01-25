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
            var delimiters = new[] { ',', '\n' };
            var numbers = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).ToArray();

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
