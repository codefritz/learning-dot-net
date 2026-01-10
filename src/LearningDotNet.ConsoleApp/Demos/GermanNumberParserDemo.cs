using LearningDotNet.Core.Converters;

namespace LearningDotNet.ConsoleApp.Demos
{
    /// <summary>
    /// Demo for German word to number conversion
    /// </summary>
    public static class GermanNumberParserDemo
    {
        /// <param name="presetWord">Optional preset German number word to parse</param>
        public static void Run(string? presetWord = null)
        {
            Console.WriteLine("German Word to Number Parser");
            Console.WriteLine("============================");
            Console.WriteLine("Examples:");
            Console.WriteLine("  - dreiundzwanzig -> 23");
            Console.WriteLine("  - zehnmillionenfünfhunderttausenddreiundzwanzig -> 10500023");
            Console.WriteLine("  - einhundertzwölf -> 112");
            Console.WriteLine("  - dreiundzwanzigkommavierfünfdrei -> 23.453");
            Console.WriteLine();

            try
            {
                string germanWord;
                if (!string.IsNullOrEmpty(presetWord))
                {
                    germanWord = presetWord;
                }
                else
                {
                    Console.Write("Enter a German number word: ");
                    germanWord = Console.ReadLine() ?? string.Empty;
                }

                if (string.IsNullOrWhiteSpace(germanWord))
                {
                    Console.WriteLine("Error: Input cannot be empty");
                    return;
                }

                Console.Write($"{germanWord} -> ");
                double result = GermanNumberParser.ParseToNumber(germanWord);
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
