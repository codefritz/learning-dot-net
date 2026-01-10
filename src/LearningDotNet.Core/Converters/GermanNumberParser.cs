using System.Text.RegularExpressions;

namespace LearningDotNet.Core.Converters
{
    /// <summary>
    /// Parses German number words and converts them to numeric values
    /// </summary>
    public static class GermanNumberParser
    {
        private static readonly Dictionary<string, long> WordToNumber = new()
        {
            // Single digits
            ["null"] = 0,
            ["ein"] = 1,
            ["eins"] = 1,
            ["eine"] = 1,
            ["einer"] = 1,
            ["zwei"] = 2,
            ["drei"] = 3,
            ["vier"] = 4,
            ["fünf"] = 5,
            ["sechs"] = 6,
            ["sieben"] = 7,
            ["acht"] = 8,
            ["neun"] = 9,

            // Special cases (11-12)
            ["elf"] = 11,
            ["zwölf"] = 12,

            // Tens
            ["zehn"] = 10,
            ["zwanzig"] = 20,
            ["dreißig"] = 30,
            ["vierzig"] = 40,
            ["fünfzig"] = 50,
            ["sechszig"] = 60,
            ["siebzig"] = 70,
            ["achtzig"] = 80,
            ["neunzig"] = 90,

            // Place values
            ["hundert"] = 100,
            ["tausend"] = 1000,
            ["million"] = 1000000,
            ["millionen"] = 1000000,
            ["milliarde"] = 1000000000,
            ["milliarden"] = 1000000000
        };

        /// <summary>
        /// Parses a German number word and returns the numeric value
        /// </summary>
        /// <param name="germanWord">The German number word (e.g., "zehnmillionenfünfhunderttausenddreiundzwanzig" or "dreiundzwanzigkommavierfünfdrei")</param>
        /// <returns>The numeric value</returns>
        /// <exception cref="ArgumentException">Thrown when the input is not a valid German number word</exception>
        public static double ParseToNumber(string germanWord)
        {
            if (string.IsNullOrWhiteSpace(germanWord))
                throw new ArgumentException("Input cannot be null or empty", nameof(germanWord));

            germanWord = germanWord.ToLower().Trim();

            if (germanWord == "null")
                return 0;

            try
            {
                // Handle decimal numbers with "komma"
                if (germanWord.Contains("komma"))
                {
                    var parts = germanWord.Split(new[] { "komma" }, StringSplitOptions.None);
                    if (parts.Length != 2 || string.IsNullOrEmpty(parts[0]) || string.IsNullOrEmpty(parts[1]))
                        throw new FormatException("Invalid decimal format with 'komma'");

                    var integerPart = ParseGermanNumberWord(parts[0]);
                    var decimalPart = ParseDecimalPart(parts[1]);
                    return integerPart + decimalPart;
                }

                return ParseGermanNumberWord(germanWord);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Invalid German number word: {germanWord}", nameof(germanWord), ex);
            }
        }

        private static long ParseGermanNumberWord(string word)
        {
            long totalValue = 0;
            long currentValue = 0;

            // Handle milliarden (billions)
            if (word.Contains("milliarde"))
            {
                var parts = SplitByWord(word, "milliarde");
                currentValue = parts.Length > 0 && !string.IsNullOrEmpty(parts[0]) ? ParseSegment(parts[0]) : 1;
                totalValue += currentValue * 1000000000;
                word = parts.Length > 1 ? parts[1] : "";
                currentValue = 0;
            }

            // Handle millionen (millions)
            if (word.Contains("million"))
            {
                var parts = SplitByWord(word, "million");
                currentValue = parts.Length > 0 && !string.IsNullOrEmpty(parts[0]) ? ParseSegment(parts[0]) : 1;
                totalValue += currentValue * 1000000;
                word = parts.Length > 1 ? parts[1] : "";
                currentValue = 0;
            }

            // Handle tausend (thousands)
            if (word.Contains("tausend"))
            {
                var parts = SplitByWord(word, "tausend");
                currentValue = parts.Length > 0 && !string.IsNullOrEmpty(parts[0]) ? ParseSegment(parts[0]) : 1;
                totalValue += currentValue * 1000;
                word = parts.Length > 1 ? parts[1] : "";
                currentValue = 0;
            }

            // Handle remaining hundreds and below
            if (!string.IsNullOrEmpty(word))
            {
                totalValue += ParseSegment(word);
            }

            return totalValue;
        }

        private static long ParseSegment(string segment)
        {
            if (string.IsNullOrEmpty(segment))
                return 0;

            long value = 0;

            // Handle hundreds
            if (segment.Contains("hundert"))
            {
                var parts = segment.Split(new[] { "hundert" }, StringSplitOptions.None);
                var hundredsDigit = ParseTensAndOnes(parts[0]);
                if (hundredsDigit == 0) hundredsDigit = 1; // "hundert" without prefix means 100
                value += hundredsDigit * 100;

                if (parts.Length > 1 && !string.IsNullOrEmpty(parts[1]))
                {
                    value += ParseTensAndOnes(parts[1]);
                }
            }
            else
            {
                value = ParseTensAndOnes(segment);
            }

            return value;
        }

        private static long ParseTensAndOnes(string segment)
        {
            if (string.IsNullOrEmpty(segment))
                return 0;

            // Direct match
            if (WordToNumber.ContainsKey(segment))
                return WordToNumber[segment];

            // Handle "und" pattern (e.g., "dreiundzwanzig" = 23)
            if (segment.Contains("und"))
            {
                var parts = segment.Split(new[] { "und" }, StringSplitOptions.None);
                if (parts.Length == 2)
                {
                    var ones = WordToNumber.ContainsKey(parts[0]) ? WordToNumber[parts[0]] : 0;
                    var tens = WordToNumber.ContainsKey(parts[1]) ? WordToNumber[parts[1]] : 0;
                    return ones + tens;
                }
            }

            // Try to find the longest matching word
            foreach (var kvp in WordToNumber.OrderByDescending(x => x.Key.Length))
            {
                if (segment.StartsWith(kvp.Key))
                {
                    var remaining = segment.Substring(kvp.Key.Length);
                    return kvp.Value + ParseTensAndOnes(remaining);
                }
            }

            throw new FormatException($"Unable to parse segment: {segment}");
        }

        private static string[] SplitByWord(string text, string separator)
        {
            // Split by separator, but also handle plural forms
            var pattern = separator + "(en)?";
            var parts = Regex.Split(text, pattern);
            return parts.Where(p => !string.IsNullOrEmpty(p) && p != "en" && p != "n").ToArray();
        }

        private static double ParseDecimalPart(string decimalWord)
        {
            if (string.IsNullOrEmpty(decimalWord))
                return 0;

            // Parse each digit word individually
            // e.g., "vierfünfdrei" -> 4, 5, 3 -> 0.453
            var decimalDigits = new List<int>();
            var currentWord = decimalWord;

            while (!string.IsNullOrEmpty(currentWord))
            {
                bool foundDigit = false;

                // Try to match single digit words
                foreach (var kvp in WordToNumber.Where(x => x.Value >= 0 && x.Value <= 9).OrderByDescending(x => x.Key.Length))
                {
                    if (currentWord.StartsWith(kvp.Key))
                    {
                        decimalDigits.Add((int)kvp.Value);
                        currentWord = currentWord.Substring(kvp.Key.Length);
                        foundDigit = true;
                        break;
                    }
                }

                if (!foundDigit)
                {
                    throw new FormatException($"Unable to parse decimal part: {decimalWord}");
                }
            }

            // Convert digits to decimal value
            double decimalValue = 0;
            double divisor = 10;
            foreach (var digit in decimalDigits)
            {
                decimalValue += digit / divisor;
                divisor *= 10;
            }

            return decimalValue;
        }
    }
}
