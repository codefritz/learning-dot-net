using LearningDotNet.Core.Mathematics;

namespace LearningDotNet.ConsoleApp.Demos
{
    /// <summary>
    /// Demo for Pascal Triangle generation
    /// </summary>
    public static class PascalTriangleDemo
    {
        /// <summary>
        /// Runs the Pascal Triangle demo
        /// </summary>
        /// <param name="depth">Number of rows to generate</param>
        public static void Run(int depth = 5)
        {
            Console.WriteLine("Pascal Triangle Generator");
            Console.WriteLine("========================");

            try
            {
                depth = depth > 0 ? depth : 5;
                Console.WriteLine($"Generating Pascal's Triangle with depth: {depth}\n");

                int[][] triangle = PascalTriangle.Generate(depth);
                string formattedTriangle = PascalTriangle.FormatTriangle(triangle);

                Console.WriteLine(formattedTriangle);

                // Show a specific row
                Console.WriteLine($"\nRow {depth - 1}: [{string.Join(", ", PascalTriangle.GetRow(depth - 1))}]");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}