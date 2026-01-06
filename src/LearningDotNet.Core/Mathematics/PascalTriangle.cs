namespace LearningDotNet.Core.Mathematics
{
    /// <summary>
    /// Generates and works with Pascal's Triangle
    /// </summary>
    public static class PascalTriangle
    {
        /// <summary>
        /// Generates Pascal's Triangle up to the specified depth
        /// </summary>
        /// <param name="depth">Number of rows to generate</param>
        /// <returns>Pascal's Triangle as a 2D array</returns>
        public static int[][] Generate(int depth)
        {
            if (depth <= 0)
                throw new ArgumentException("Depth must be greater than 0", nameof(depth));

            var triangle = new int[depth][];

            for (int rowIndex = 0; rowIndex < depth; rowIndex++)
            {
                triangle[rowIndex] = new int[rowIndex + 1];
                triangle[rowIndex][0] = 1; // First element is always 1
                triangle[rowIndex][rowIndex] = 1; // Last element is always 1

                // Fill middle elements
                for (int columnIndex = 1; columnIndex < rowIndex; columnIndex++)
                {
                    triangle[rowIndex][columnIndex] = triangle[rowIndex - 1][columnIndex - 1] + triangle[rowIndex - 1][columnIndex];
                }
            }

            return triangle;
        }

        /// <summary>
        /// Gets a specific row of Pascal's Triangle (0-indexed)
        /// </summary>
        /// <param name="rowIndex">The row index (0-based)</param>
        /// <returns>The specified row as an array</returns>
        public static int[] GetRow(int rowIndex)
        {
            if (rowIndex < 0)
                throw new ArgumentException("Row index must be non-negative", nameof(rowIndex));

            var row = new int[rowIndex + 1];
            row[0] = 1;

            for (int columnIndex = 1; columnIndex <= rowIndex; columnIndex++)
            {
                // Calculate each element using the formula: C(n,k) = C(n,k-1) * (n-k+1) / k
                row[columnIndex] = (int)((long)row[columnIndex - 1] * (rowIndex - columnIndex + 1) / columnIndex);
            }

            return row;
        }

        /// <summary>
        /// Formats Pascal's Triangle for display
        /// </summary>
        /// <param name="triangle">The triangle to format</param>
        /// <returns>A formatted string representation</returns>
        public static string FormatTriangle(int[][] triangle)
        {
            if (triangle == null || triangle.Length == 0)
                return string.Empty;

            var lines = new List<string>();
            int maxWidth = triangle[^1].Sum().ToString().Length;

            foreach (var row in triangle)
            {
                var formattedRow = string.Join(" ", row.Select(n => n.ToString().PadLeft(maxWidth)));
                lines.Add(formattedRow);
            }

            return string.Join(Environment.NewLine, lines);
        }
    }
}