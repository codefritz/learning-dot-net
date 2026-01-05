
using System.Runtime.CompilerServices;

namespace LearningDotNet
{
    class PascalTriangle
    {
        public static void RunPascal(int deep)
        {
            deep = deep > 0 ? deep : 3;

            Console.WriteLine($"Create Pasales triangle with deep : {deep}");
            
            string binaryString = "1001011001";

            List<int> digits = binaryString.Select(c => c - '0').ToList();

            Console.WriteLine($"Input: {binaryString}");
            Console.WriteLine($"Outut: [{string.Join(" ", digits)}]");

        }
    }


}