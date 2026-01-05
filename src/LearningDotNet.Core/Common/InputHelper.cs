namespace LearningDotNet.Core.Common
{
    /// <summary>
    /// Provides helper methods for input validation and processing
    /// </summary>
    public static class InputHelper
    {
        /// <summary>
        /// Reads and validates binary input from the console
        /// </summary>
        /// <param name="prompt">The prompt to display to the user</param>
        /// <returns>A valid binary string</returns>
        public static string ReadBinaryInput(string prompt)
        {
            string input;
            while (true)
            {
                Console.Write(prompt);
                input = Console.ReadLine()?.Trim() ?? string.Empty;

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Please enter a binary number.");
                    continue;
                }

                if (Mathematics.BinaryArithmetic.IsValidBinary(input))
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("Invalid binary number. Please use only 0 and 1.");
                }
            }
        }

        /// <summary>
        /// Reads and validates numeric input from the console
        /// </summary>
        /// <param name="prompt">The prompt to display to the user</param>
        /// <returns>A valid number string</returns>
        public static string ReadNumberInput(string prompt)
        {
            string input;
            while (true)
            {
                Console.Write(prompt);
                input = Console.ReadLine()?.Trim() ?? string.Empty;

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Please enter a number.");
                    continue;
                }

                if (input.All(char.IsDigit))
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("Invalid number. Please enter digits only.");
                }
            }
        }
    }
}