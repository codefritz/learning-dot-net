using LearningDotNet.Core.Converters;

namespace LearningDotNet.Core.Tests.Converters
{
    public class GermanNumberParserTests
    {
        [Theory]
        [InlineData("null", 0)]
        [InlineData("ein", 1)]
        [InlineData("eins", 1)]
        [InlineData("zwei", 2)]
        [InlineData("drei", 3)]
        [InlineData("vier", 4)]
        [InlineData("fünf", 5)]
        [InlineData("sechs", 6)]
        [InlineData("sieben", 7)]
        [InlineData("acht", 8)]
        [InlineData("neun", 9)]
        public void ParseToNumber_SingleDigits_ReturnsCorrectNumber(string input, double expected)
        {
            // Act
            var result = GermanNumberParser.ParseToNumber(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("zehn", 10)]
        [InlineData("elf", 11)]
        [InlineData("zwölf", 12)]
        [InlineData("zwanzig", 20)]
        [InlineData("dreißig", 30)]
        [InlineData("vierzig", 40)]
        [InlineData("fünfzig", 50)]
        [InlineData("sechszig", 60)]
        [InlineData("siebzig", 70)]
        [InlineData("achtzig", 80)]
        [InlineData("neunzig", 90)]
        public void ParseToNumber_Tens_ReturnsCorrectNumber(string input, double expected)
        {
            // Act
            var result = GermanNumberParser.ParseToNumber(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("einundzwanzig", 21)]
        [InlineData("zweiundzwanzig", 22)]
        [InlineData("dreiundzwanzig", 23)]
        [InlineData("fünfundvierzig", 45)]
        [InlineData("neunundneunzig", 99)]
        [InlineData("siebenundsiebzig", 77)]
        public void ParseToNumber_CompoundTens_ReturnsCorrectNumber(string input, double expected)
        {
            // Act
            var result = GermanNumberParser.ParseToNumber(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("hundert", 100)]
        [InlineData("einhundert", 100)]
        [InlineData("zweihundert", 200)]
        [InlineData("fünfhundert", 500)]
        [InlineData("neunhundert", 900)]
        public void ParseToNumber_Hundreds_ReturnsCorrectNumber(string input, double expected)
        {
            // Act
            var result = GermanNumberParser.ParseToNumber(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("einhundertelf", 111)]
        [InlineData("einhundertzwölf", 112)]
        [InlineData("zweihundertdreiundzwanzig", 223)]
        [InlineData("fünfhundertvierundfünfzig", 554)]
        [InlineData("neunhundertneunundneunzig", 999)]
        public void ParseToNumber_HundredsWithTensAndOnes_ReturnsCorrectNumber(string input, double expected)
        {
            // Act
            var result = GermanNumberParser.ParseToNumber(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("tausend", 1000)]
        [InlineData("eintausend", 1000)]
        [InlineData("zweitausend", 2000)]
        [InlineData("fünftausend", 5000)]
        [InlineData("zehntausend", 10000)]
        [InlineData("neunzigtausend", 90000)]
        public void ParseToNumber_Thousands_ReturnsCorrectNumber(string input, double expected)
        {
            // Act
            var result = GermanNumberParser.ParseToNumber(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("eintausendzweihundertdreiundzwanzig", 1223)]
        [InlineData("fünftausendsechshundertsiebenundachtzig", 5687)]
        [InlineData("neunundneunzigtausendneunhundertneunundneunzig", 99999)]
        public void ParseToNumber_ThousandsWithHundreds_ReturnsCorrectNumber(string input, double expected)
        {
            // Act
            var result = GermanNumberParser.ParseToNumber(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("einemillion", 1000000)]
        [InlineData("zweimillionen", 2000000)]
        [InlineData("zehnmillionen", 10000000)]
        [InlineData("hundertmillionen", 100000000)]
        public void ParseToNumber_Millions_ReturnsCorrectNumber(string input, double expected)
        {
            // Act
            var result = GermanNumberParser.ParseToNumber(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("zehnmillionenfünfhunderttausenddreiundzwanzig", 10500023)]
        [InlineData("einemillionfünfhunderttausend", 1500000)]
        [InlineData("zweimillionendreihundertvierzigtausendfünfhundertsechsundsiebzig", 2340576)]
        public void ParseToNumber_ComplexNumbers_ReturnsCorrectNumber(string input, double expected)
        {
            // Act
            var result = GermanNumberParser.ParseToNumber(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("einemilliarde", 1000000000)]
        [InlineData("zweimilliarden", 2000000000)]
        [InlineData("zehnmilliarden", 10000000000)]
        public void ParseToNumber_Billions_ReturnsCorrectNumber(string input, double expected)
        {
            // Act
            var result = GermanNumberParser.ParseToNumber(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        public void ParseToNumber_EmptyOrNull_ThrowsArgumentException(string input)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => GermanNumberParser.ParseToNumber(input));
        }

        [Theory]
        [InlineData("abc")]
        [InlineData("123")]
        [InlineData("einhundertabc")]
        [InlineData("invalid")]
        public void ParseToNumber_InvalidInput_ThrowsArgumentException(string input)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => GermanNumberParser.ParseToNumber(input));
        }

        [Theory]
        [InlineData("EINS", 1)]
        [InlineData("ZweiUndZwanzig", 22)]
        [InlineData("HUNDERT", 100)]
        public void ParseToNumber_CaseInsensitive_ReturnsCorrectNumber(string input, double expected)
        {
            // Act
            var result = GermanNumberParser.ParseToNumber(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("  eins  ", 1)]
        [InlineData("  hundert  ", 100)]
        public void ParseToNumber_WithWhitespace_ReturnsCorrectNumber(string input, double expected)
        {
            // Act
            var result = GermanNumberParser.ParseToNumber(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("nullkommanull", 0.0)]
        [InlineData("nullkommaeins", 0.1)]
        [InlineData("nullkommazwei", 0.2)]
        [InlineData("nullkommafünf", 0.5)]
        [InlineData("nullkommaneun", 0.9)]
        public void ParseToNumber_DecimalZeroWithDecimals_ReturnsCorrectNumber(string input, double expected)
        {
            // Act
            var result = GermanNumberParser.ParseToNumber(input);

            // Assert
            Assert.Equal(expected, result, precision: 10);
        }

        [Theory]
        [InlineData("einskommazwei", 1.2)]
        [InlineData("zweikommadrei", 2.3)]
        [InlineData("fünfkommafünf", 5.5)]
        [InlineData("neunkommaacht", 9.8)]
        public void ParseToNumber_SingleDigitDecimal_ReturnsCorrectNumber(string input, double expected)
        {
            // Act
            var result = GermanNumberParser.ParseToNumber(input);

            // Assert
            Assert.Equal(expected, result, precision: 10);
        }

        [Theory]
        [InlineData("dreiundzwanzigkommavierfünfdrei", 23.453)]
        [InlineData("einhundertzwölfkommaneunacht", 112.98)]
        [InlineData("dreikommaeinsvier", 3.14)]
        [InlineData("zweikommasiebeneins", 2.71)]
        public void ParseToNumber_ComplexDecimal_ReturnsCorrectNumber(string input, double expected)
        {
            // Act
            var result = GermanNumberParser.ParseToNumber(input);

            // Assert
            Assert.Equal(expected, result, precision: 10);
        }

        [Theory]
        [InlineData("eintausendkommazweifünf", 1000.25)]
        [InlineData("fünfzigtausendkommadreizwei", 50000.32)]
        [InlineData("einemillionkommanullnullzwei", 1000000.002)]
        public void ParseToNumber_LargeNumbersWithDecimals_ReturnsCorrectNumber(string input, double expected)
        {
            // Act
            var result = GermanNumberParser.ParseToNumber(input);

            // Assert
            Assert.Equal(expected, result, precision: 10);
        }

        [Theory]
        [InlineData("zehnkomma")]
        [InlineData("kommazehn")]
        [InlineData("zehnkommaeinskommaeins")]
        public void ParseToNumber_InvalidDecimalFormat_ThrowsArgumentException(string input)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => GermanNumberParser.ParseToNumber(input));
        }
    }
}
