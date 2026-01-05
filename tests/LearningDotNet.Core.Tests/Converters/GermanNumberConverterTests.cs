using LearningDotNet.Core.Converters;

namespace LearningDotNet.Core.Tests.Converters
{
    public class GermanNumberConverterTests
    {
        [Theory]
        [InlineData("22", "zweiundzwanzig")]
        [InlineData("11", "elf")]
        [InlineData("12", "zwölf")]
        [InlineData("30", "dreißig")]
        [InlineData("01", "ein(s)")]
        [InlineData("99", "neunundneunzig")]
        [InlineData("45", "fünfundvierzig")]
        public void ConvertTwoDigitNumber_ValidTwoDigitNumbers_ReturnsCorrectGermanWord(string input, string expected)
        {
            // Act
            var result = GermanNumberConverter.ConvertTwoDigitNumber(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1")]
        [InlineData("123")]
        [InlineData("")]
        [InlineData(null)]
        public void ConvertTwoDigitNumber_InvalidLength_ReturnsErrorMarker(string input)
        {
            // Act
            var result = GermanNumberConverter.ConvertTwoDigitNumber(input);

            // Assert
            Assert.Equal("%#$", result);
        }

        [Theory]
        [InlineData("123")]
        [InlineData("1000")]
        [InlineData("5")]
        [InlineData("42")]
        public void ConvertToWords_ValidNumbers_DoesNotThrow(string input)
        {
            // Act & Assert
            var exception = Record.Exception(() => GermanNumberConverter.ConvertToWords(input));
            Assert.Null(exception);
        }

        [Theory]
        [InlineData("")]
        [InlineData("abc")]
        [InlineData("12a")]
        [InlineData(null)]
        public void ConvertToWords_InvalidInput_ThrowsArgumentException(string invalidInput)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => GermanNumberConverter.ConvertToWords(invalidInput));
        }

        [Theory]
        [InlineData("1", "ein(s)")]
        [InlineData("5", "fünf")]
        [InlineData("0", "null")]
        [InlineData("9", "neun")]
        public void ConvertToWords_SingleDigit_ReturnsCorrectGermanWord(string input, string expected)
        {
            // Act
            var result = GermanNumberConverter.ConvertToWords(input);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}