
using System.Text;

namespace LearningDotNet
{
    public class Zahlenwortkonvertierer
    {
        private static readonly Dictionary<string, string> singleDigitToWord = new()
        {
            ["1"] = "eins",
            ["2"] = "zwei",
            ["3"] = "drei",
            ["4"] = "vier",
            ["5"] = "fünf",
            ["6"] = "sechs",
            ["7"] = "sieben",
            ["8"] = "acht",
            ["9"] = "neun",
            ["0"] = "null",
        };

        private static readonly Dictionary<string, string> twoDigitToWord = new()
        {
            ["1"] = "zehn",
            ["2"] = "zwanzig",
            ["3"] = "dreißig",
            ["4"] = "vierzig",
            ["5"] = "fünfzig",
            ["6"] = "sechszig",
            ["7"] = "siebzig",
            ["8"] = "achtzig",
            ["9"] = "neunzig",
            ["0"] = "null",
        };

        private static readonly Dictionary<int, string> stelleWord = new()
        {
            [0] = "tausend",
            [1] = "millionen",
            [2] = "milliarden" 
        };

        private static readonly Dictionary<string, string> fixedWords = new()
        {
            ["11"] = "elf",
            ["12"] = "zwölf"
        };

        public static void RunZahlenwortkonvertierer(string arg)
        {
            Console.WriteLine("Zahlenwortkonvertierer 1.0");
            Console.WriteLine("===============================");
            
            var zahl = string.IsNullOrEmpty(arg) ? readFromCmd() : arg;
            Console.Write(zahl + " -> ");
            var result = "";
  
            var stelle = 0;
            while(zahl.Length > 3)
            {
                result = printThreeLengthNumber(zahl.Substring(zahl.Length - 3, 3)) + result;
                result = stelleWord[stelle] + "_" + result;
                stelle += 1;
                zahl = zahl.Substring(0, zahl.Length - 3);
            }

            result = printThreeLengthNumber(zahl) + result;

            Console.Write(result);
        }

        static string printThreeLengthNumber(string zahl)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (zahl.Length == 1)
            {
                stringBuilder.Append(singleDigitToWord[zahl[0].ToString()]);
            }
            if (zahl.Length == 2)
            {
                stringBuilder.Append(printTwoDigitToWord(zahl));
                
            }
            if (zahl.Length == 3)
            {
                stringBuilder.Append(singleDigitToWord[zahl[0].ToString()]);
                stringBuilder.Append("hundert");
                stringBuilder.Append(printTwoDigitToWord(zahl.Substring(1,2)));
            }
            return stringBuilder.ToString();
        }

        static string readFromCmd()
        {
            Console.Write("Bitte geben Sie ein Zahl mit zwei Stellen ein (e.g. 22): ");
            return Console.ReadLine()?.Trim();
        }

        static string printTwoDigitToWord(string zahl)
        {
            if (string.IsNullOrEmpty(zahl) || zahl.Length != 2)
            {
                Console.WriteLine("ERROR: Eingabe hat keine 2 Stellen.");
                return "%#$";
            }

            if (fixedWords.ContainsKey(zahl))
            {
                return fixedWords[zahl];
            }

            var first = zahl[0].ToString();
            var last = zahl[1].ToString();
            var perfix = "";
            if (last != "0") {
                perfix += singleDigitToWord[last];
                if (first != "1") { 
                    perfix += "und";
                }
            }
        
            return perfix += twoDigitToWord[first];
        }
    }
}
