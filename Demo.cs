
using System.Runtime.CompilerServices;

namespace LearningDotNet
{
    class Demo
    {
        public static void Run(string[] args)
        {
            Console.WriteLine("Convert String with binary to list ...");
            
            string binaryString = "1001011001";

            List<int> digits = binaryString.Select(c => c - '0').ToList();

            Console.WriteLine($"Input: {binaryString}");
            Console.WriteLine($"Outut: [{string.Join(" ", digits)}]");

        }
    }


}