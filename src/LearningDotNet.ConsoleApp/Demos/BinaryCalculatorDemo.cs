using LearningDotNet.Core.Mathematics;
using LearningDotNet.Core.Common;

namespace LearningDotNet.ConsoleApp.Demos
{
    /// <summary>
    /// Demo for binary arithmetic operations
    /// </summary>
    public static class BinaryCalculatorDemo
    {
        /// <summary>
        /// Runs the binary calculator demo
        /// </summary>
        public static void Run()
        {
            Console.WriteLine("Binary Multiplication Calculator");
            Console.WriteLine("===============================");

            try
            {
                string binary1 = InputHelper.ReadBinaryInput("Enter the first binary number: ");
                string binary2 = InputHelper.ReadBinaryInput("Enter the second binary number: ");

                string result = BinaryArithmetic.Multiply(binary1, binary2);

                Console.WriteLine("\nResult:");
                Console.WriteLine($"{binary1} × {binary2} = {result}");

                // Convert to decimal for verification
                int decimal1 = Convert.ToInt32(binary1, 2);
                int decimal2 = Convert.ToInt32(binary2, 2);
                int decimalResult = Convert.ToInt32(result, 2);

                Console.WriteLine($"Verification: {decimal1} × {decimal2} = {decimalResult}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}