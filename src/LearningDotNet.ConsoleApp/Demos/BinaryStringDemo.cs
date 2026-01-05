namespace LearningDotNet.ConsoleApp.Demos
{
    /// <summary>
    /// Demo for binary string manipulation
    /// </summary>
    public static class BinaryStringDemo
    {
        /// <summary>
        /// Runs the binary string demo
        /// </summary>
        public static void Run()
        {
            Console.WriteLine("Binary String Manipulation Demo");
            Console.WriteLine("===============================");

            string binaryString = "1001011001";

            Console.WriteLine("Converting binary string to digit list...\n");

            List<int> digits = binaryString.Select(c => c - '0').ToList();

            Console.WriteLine($"Input:  {binaryString}");
            Console.WriteLine($"Output: [{string.Join(", ", digits)}]");

            // Additional demonstrations
            Console.WriteLine($"\nAdditional Information:");
            Console.WriteLine($"Length: {binaryString.Length} bits");
            Console.WriteLine($"Decimal value: {Convert.ToInt32(binaryString, 2)}");
            Console.WriteLine($"Number of 1s: {digits.Count(d => d == 1)}");
            Console.WriteLine($"Number of 0s: {digits.Count(d => d == 0)}");
        }
    }
}