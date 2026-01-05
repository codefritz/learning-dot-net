using LearningDotNet.Core.Mathematics;

namespace LearningDotNet.Core.Tests.Mathematics
{
    public class BinaryArithmeticTests
    {
        [Theory]
        [InlineData("101", "11", "1111")] // 5 × 3 = 15
        [InlineData("110", "10", "1100")] // 6 × 2 = 12
        [InlineData("1", "1", "1")]       // 1 × 1 = 1
        [InlineData("0", "101", "0")]     // 0 × 5 = 0
        [InlineData("1010", "1", "1010")] // 10 × 1 = 10
        public void Multiply_ValidInputs_ReturnsCorrectResult(string binary1, string binary2, string expected)
        {
            // Act
            var result = BinaryArithmetic.Multiply(binary1, binary2);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1010", "111", "10001")] // 10 + 7 = 17
        [InlineData("1", "1", "10")]         // 1 + 1 = 2
        [InlineData("101", "11", "1000")]    // 5 + 3 = 8
        [InlineData("0", "1", "1")]          // 0 + 1 = 1
        public void Add_ValidInputs_ReturnsCorrectResult(string binary1, string binary2, string expected)
        {
            // Act
            var result = BinaryArithmetic.Add(binary1, binary2);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1010", true)]   // Valid binary
        [InlineData("0", true)]      // Single zero is valid
        [InlineData("1", true)]      // Single one is valid
        [InlineData("", false)]      // Empty string is invalid
        [InlineData("102", false)]   // Contains non-binary digit
        [InlineData("abc", false)]   // Contains letters
        [InlineData("10a1", false)]  // Mixed valid and invalid
        public void IsValidBinary_VariousInputs_ReturnsExpectedResult(string input, bool expected)
        {
            // Act
            var result = BinaryArithmetic.IsValidBinary(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("102")]
        [InlineData("abc")]
        [InlineData("")]
        public void Multiply_InvalidInput_ThrowsArgumentException(string invalidInput)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => BinaryArithmetic.Multiply(invalidInput, "101"));
            Assert.Throws<ArgumentException>(() => BinaryArithmetic.Multiply("101", invalidInput));
        }

        [Theory]
        [InlineData("102")]
        [InlineData("abc")]
        [InlineData("")]
        public void Add_InvalidInput_ThrowsArgumentException(string invalidInput)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => BinaryArithmetic.Add(invalidInput, "101"));
            Assert.Throws<ArgumentException>(() => BinaryArithmetic.Add("101", invalidInput));
        }
    }
}