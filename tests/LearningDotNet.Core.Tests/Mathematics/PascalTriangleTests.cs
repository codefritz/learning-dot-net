using LearningDotNet.Core.Mathematics;

namespace LearningDotNet.Core.Tests.Mathematics
{
    public class PascalTriangleTests
    {
        [Fact]
        public void Generate_ValidDepth_ReturnsCorrectTriangle()
        {
            // Arrange
            int depth = 4;

            // Act
            int[][] result = PascalTriangle.Generate(depth);

            // Assert
            Assert.Equal(depth, result.Length);
            Assert.Equal(new[] { 1 }, result[0]);
            Assert.Equal(new[] { 1, 1 }, result[1]);
            Assert.Equal(new[] { 1, 2, 1 }, result[2]);
            Assert.Equal(new[] { 1, 3, 3, 1 }, result[3]);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-5)]
        public void Generate_InvalidDepth_ThrowsArgumentException(int invalidDepth)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => PascalTriangle.Generate(invalidDepth));
        }

        [Theory]
        [InlineData(0, new[] { 1 })]
        [InlineData(1, new[] { 1, 1 })]
        [InlineData(2, new[] { 1, 2, 1 })]
        [InlineData(3, new[] { 1, 3, 3, 1 })]
        [InlineData(4, new[] { 1, 4, 6, 4, 1 })]
        public void GetRow_ValidIndex_ReturnsCorrectRow(int rowIndex, int[] expected)
        {
            // Act
            int[] result = PascalTriangle.GetRow(rowIndex);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-5)]
        public void GetRow_NegativeIndex_ThrowsArgumentException(int negativeIndex)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => PascalTriangle.GetRow(negativeIndex));
        }

        [Fact]
        public void FormatTriangle_ValidTriangle_ReturnsFormattedString()
        {
            // Arrange
            int[][] triangle = { new[] { 1 }, new[] { 1, 1 }, new[] { 1, 2, 1 } };

            // Act
            string result = PascalTriangle.FormatTriangle(triangle);

            // Assert
            Assert.Contains("1", result);
            Assert.Contains("2", result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void FormatTriangle_EmptyTriangle_ReturnsEmptyString()
        {
            // Arrange
            int[][] emptyTriangle = Array.Empty<int[]>();

            // Act
            string result = PascalTriangle.FormatTriangle(emptyTriangle);

            // Assert
            Assert.Equal(string.Empty, result);
        }
    }
}