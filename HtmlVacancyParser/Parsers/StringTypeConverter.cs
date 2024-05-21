using System.Globalization;
using System.Text.RegularExpressions;

namespace HHVacancyParser.Parsers
{
    public partial class StringTypeConverter
    {
        [GeneratedRegex("\\d+")]
        private static partial Regex IntNumRegex();

        [GeneratedRegex("-?[0-9]*\\.?[0-9]+")]
        private static partial Regex FloatNumRegex();

        public Dictionary<Type, Func<string, object>>
            TypeConverters;

        public StringTypeConverter()
        {
            TypeConverters = new() {
                { typeof(int), value =>  ParseInteger(value)},
                { typeof(float), value => ParseFloat(value)},
                { typeof(string), value => value },
                { typeof(bool), value => !string.IsNullOrEmpty(value) },
                { typeof(DateTime), value => DateTime.Parse(value)}
            };
        }

        /// <summary>
        /// Parses a string containing a number into an integer.
        /// </summary>
        /// <param name="numString">The string containing the number to parse.</param>
        /// <returns>The integer value of the number.</returns>
        public int ParseInteger(string numString)
        {
            if (string.IsNullOrEmpty(numString)) return 0;
            else return int.Parse(IntNumRegex().Match(numString).Value);
        }

        /// <summary>
        /// Parses a string containing a floating point number into a float.
        /// </summary>
        /// <param name="numString">The string containing the number to parse.</param>
        /// <returns>The float value of the number.</returns>
        public float ParseFloat(string numString)
        {
            if (string.IsNullOrEmpty(numString)) return 0;
            else return float.Parse(FloatNumRegex().Match(numString.Replace(",", "."))
              .Value, CultureInfo.InvariantCulture);
        }

        public object Convert(string input, Type outType)
        {
            bool hasConverter = TypeConverters.TryGetValue(outType, out var Converter);

            if (hasConverter)
                return Converter(input);

            else
                throw new InvalidOperationException($"Convertation from string to {outType} not supported!");
        }



    }
}
