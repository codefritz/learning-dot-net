
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

        private static readonly Dictionary<string, string> fixedWords = new ()
        {
            ["11"] = "elf",
            ["12"] = "zwölf"
        };

        public static void RunZahlenwortkonvertierer(string arg)
        {
            Console.WriteLine("Zahlenwortkonvertierer 1.0");
            Console.WriteLine("===============================");
            
            var zahl = string.IsNullOrEmpty(arg) ? readFromCmd() : arg;

            W(zahl + " -> ");

            var arr = Enumerable.Range(0, zahl.Length / 3).Select (x => zahl.Substring(x * 3, 3)).ToArray();

            foreach (var item in arr)
            {
                printThreeLengthNumber(item);
            }
        }

        static void printThreeLengthNumber(string zahl)
        {
            if (zahl.Length == 1)
            {
                W(singleDigitToWord[zahl[0].ToString()]);
            }
            if (zahl.Length == 2)
            {
                printTwoDigitToWord(zahl);
                
            }
            if (zahl.Length == 3)
            {
                W(singleDigitToWord[zahl[0].ToString()]);
                W("hundert");
                printTwoDigitToWord(zahl.Substring(1,2));
            }
        }

        static string readFromCmd()
        {
            Console.Write("Bitte geben Sie ein Zahl mit zwei Stellen ein (e.g. 22): ");
            return Console.ReadLine()?.Trim();
        }

        static void printTwoDigitToWord(string zahl)
        {
            if (string.IsNullOrEmpty(zahl) || zahl.Length != 2)
            {
                Console.WriteLine("ERROR: Eingabe hat keine 2 Stellen.");
                return;

            }

            if (fixedWords.ContainsKey(zahl))
            {
                W(fixedWords[zahl]);
                return;
            }

            var first = zahl[0].ToString();
            var last = zahl[1].ToString();
            if (last != "0") {
                W(singleDigitToWord[last]);
                if (first != "1") { 
                    W("und");
                }
            }
        
            W(twoDigitToWord[first]);
        }

        static void W(object x){
            Console.Write(x);
        }
    }
}
