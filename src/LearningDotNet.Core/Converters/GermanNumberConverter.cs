using System.Text;

namespace LearningDotNet.Core.Converters
{
    /// <summary>
    /// Converts numbers to their German word representation
    /// </summary>
    public static class GermanNumberConverter
    {
        private static readonly Dictionary<string, string> SingleDigitToWord = new()
        {
            ["1"] = "ein(s)",
            ["2"] = "zwei",
            ["3"] = "drei",
            ["4"] = "vier",
            ["5"] = "fünf",
            ["6"] = "sechs",
            ["7"] = "sieben",
            ["8"] = "acht",
            ["9"] = "neun",
            ["0"] = "null",
        };

        private static readonly Dictionary<string, string> TensToWord = new()
        {
            ["1"] = "zehn",
            ["2"] = "zwanzig",
            ["3"] = "dreißig",
            ["4"] = "vierzig",
            ["5"] = "fünfzig",
            ["6"] = "sechszig",
            ["7"] = "siebzig",
            ["8"] = "achtzig",
            ["9"] = "neunzig",
            ["0"] = "null",
        };

        private static readonly Dictionary<int, string> PlaceValues = new()
        {
            [0] = "tausend",
            [1] = "million(en)",
            [2] = "milliarde(n)"
        };

        private static readonly Dictionary<string, string> SpecialCases = new()
        {
            ["11"] = "elf",
            ["12"] = "zwölf"
        };

        /// <summary>
        /// Converts a number string to its German word representation
        /// </summary>
        /// <param name="number">The number as a string</param>
        /// <returns>The German word representation</returns>
        /// <exception cref="ArgumentException">Thrown when the input is not a valid number</exception>
        public static string ConvertToWords(string number)
        {
            if (string.IsNullOrEmpty(number) || !IsValidNumber(number))
                throw new ArgumentException("Input must be a valid number string", nameof(number));

            var result = "";
            var placeValue = 0;

            while (number.Length > 3)
            {
                var chunk = number.Substring(number.Length - 3, 3);
                result = ConvertThreeDigitNumber(chunk) + result;

                if (PlaceValues.ContainsKey(placeValue))
                {
                    result = PlaceValues[placeValue] + "_" + result;
                }

                placeValue++;
                number = number.Substring(0, number.Length - 3);
            }

            result = ConvertThreeDigitNumber(number) + result;
            return result;
        }

        /// <summary>
        /// Converts a two-digit number to German words
        /// </summary>
        /// <param name="twoDigits">Two-digit number as string</param>
        /// <returns>German word representation</returns>
        public static string ConvertTwoDigitNumber(string twoDigits)
        {
            if (string.IsNullOrEmpty(twoDigits) || twoDigits.Length != 2)
            {
                return "%#$"; // Error marker - keeping original behavior
            }

            if (SpecialCases.ContainsKey(twoDigits))
            {
                return SpecialCases[twoDigits];
            }

            var tens = twoDigits[0].ToString();
            var ones = twoDigits[1].ToString();
            var prefix = "";

            if (ones != "0")
            {
                prefix += SingleDigitToWord[ones];
                if (tens != "1")
                {
                    prefix += "und";
                }
            }

            return prefix + TensToWord[tens];
        }

        private static string ConvertThreeDigitNumber(string number)
        {
            var result = new StringBuilder();

            if (number.Length == 1)
            {
                result.Append(SingleDigitToWord[number[0].ToString()]);
            }
            else if (number.Length == 2)
            {
                result.Append(ConvertTwoDigitNumber(number));
            }
            else if (number.Length == 3)
            {
                result.Append(SingleDigitToWord[number[0].ToString()]);
                result.Append("hundert");
                result.Append(ConvertTwoDigitNumber(number.Substring(1, 2)));
            }

            return result.ToString();
        }

        private static bool IsValidNumber(string number)
        {
            return number.All(char.IsDigit);
        }
    }
}