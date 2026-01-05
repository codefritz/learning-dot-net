using System.Text;

namespace LearningDotNet.Core.Mathematics
{
    /// <summary>
    /// Provides binary arithmetic operations including addition and multiplication
    /// </summary>
    public static class BinaryArithmetic
    {
        /// <summary>
        /// Validates if a string contains only binary digits (0 and 1)
        /// </summary>
        /// <param name="binary">The string to validate</param>
        /// <returns>True if the string is a valid binary number</returns>
        public static bool IsValidBinary(string binary)
        {
            if (string.IsNullOrEmpty(binary))
                return false;

            foreach (char c in binary)
            {
                if (c != '0' && c != '1')
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Multiplies two binary numbers represented as strings
        /// </summary>
        /// <param name="binary1">First binary number</param>
        /// <param name="binary2">Second binary number</param>
        /// <returns>The product as a binary string</returns>
        /// <exception cref="ArgumentException">Thrown when input contains invalid binary digits</exception>
        public static string Multiply(string binary1, string binary2)
        {
            if (!IsValidBinary(binary1) || !IsValidBinary(binary2))
                throw new ArgumentException("Input must contain only binary digits (0 and 1)");

            // Handle edge cases
            if (binary1 == "0" || binary2 == "0")
                return "0";

            // Initialize result as "0"
            string result = "0";

            // Multiply using the standard multiplication algorithm
            for (int i = binary2.Length - 1; i >= 0; i--)
            {
                if (binary2[i] == '1')
                {
                    // Shift binary1 left by (binary2.Length - 1 - i) positions
                    string shifted = binary1 + new string('0', binary2.Length - 1 - i);
                    result = Add(result, shifted);
                }
            }

            return result;
        }

        /// <summary>
        /// Adds two binary numbers represented as strings
        /// </summary>
        /// <param name="binary1">First binary number</param>
        /// <param name="binary2">Second binary number</param>
        /// <returns>The sum as a binary string</returns>
        /// <exception cref="ArgumentException">Thrown when input contains invalid binary digits</exception>
        public static string Add(string binary1, string binary2)
        {
            if (!IsValidBinary(binary1) || !IsValidBinary(binary2))
                throw new ArgumentException("Input must contain only binary digits (0 and 1)");

            StringBuilder result = new StringBuilder();
            int carry = 0;
            int i = binary1.Length - 1;
            int j = binary2.Length - 1;

            while (i >= 0 || j >= 0 || carry > 0)
            {
                int sum = carry;

                if (i >= 0)
                {
                    sum += CharToDigit(binary1[i]);
                    i--;
                }

                if (j >= 0)
                {
                    sum += CharToDigit(binary2[j]);
                    j--;
                }

                result.Insert(0, (sum % 2).ToString());
                carry = sum / 2;
            }

            return result.ToString();
        }

        /// <summary>
        /// Converts a character digit to its integer value
        /// </summary>
        /// <param name="c">The character to convert</param>
        /// <returns>The integer value of the character</returns>
        private static int CharToDigit(char c)
        {
            return c - '0';
        }
    }
}