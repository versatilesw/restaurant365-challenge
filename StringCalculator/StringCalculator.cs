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

            var numbers = input.Split(',').ToArray();

            if (numbers.Length > 2)
            {
                throw new ArgumentException("Input cannot contain more than 2 numbers.");
            }

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
