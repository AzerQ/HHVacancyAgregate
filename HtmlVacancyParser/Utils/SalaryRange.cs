using System.Text;

namespace HHVacancyParser.Utils
{
    public class SalaryRange
    {
        public int From { get; set; }
        public int To { get; set; }
        public bool IsWhite { get; set; }

        public SalaryRange()
        {

        }

        public void Deconstruct(out int from, out int to, out bool isWhite)
        {
            from = From;
            to = To;
            isWhite = IsWhite;
        }

        private static int SelectNumberFromString(string str, int startIndex)
        {
            StringBuilder numberAccumulator;
            numberAccumulator = new();
            while (startIndex < str.Length && char.IsNumber(str[startIndex]))
            {
                numberAccumulator.Append(str[startIndex++]);
            }
            string accumulatorValue = numberAccumulator.ToString();

            return !string.IsNullOrEmpty(accumulatorValue) ?
                int.Parse(numberAccumulator.ToString()) : 0;
        }

        public static SalaryRange FromSalaryString(string salary)
        {
            var salaryRange = new SalaryRange
            {
                IsWhite = salary.Contains("на руки", StringComparison.InvariantCultureIgnoreCase)
            };

            if (!string.IsNullOrWhiteSpace(salary))
            {
                string salaryClearString = new(salary.Trim()
                    .Where(c => char.IsLetter(c) || char.IsDigit(c)).ToArray());

                int indexOfFrom = salaryClearString.IndexOf("от");
                int indexOfTo = salaryClearString.IndexOf("до");
                int currentIndex = 0;

                if (indexOfFrom != -1)
                {
                    currentIndex = indexOfFrom + 2;

                    salaryRange.From = SelectNumberFromString(salaryClearString, currentIndex);
                }

                if (indexOfTo != -1)
                {
                    currentIndex = indexOfTo + 2;

                    salaryRange.To = SelectNumberFromString(salaryClearString, currentIndex);
                }
            }

            return salaryRange;
        }
    }
}
