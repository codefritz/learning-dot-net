
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

        public static void RunZahlenwortkonvertierer()
        {
            Console.WriteLine("Zahlenwortkonvertierer 1.0");
            Console.WriteLine("===============================");

            Console.Write("Bitte geben Sie ein Zahl mit zwei Stellen ein (e.g. 22): ");
            var zahl = Console.ReadLine();

            printTwoDigitToWord(zahl);
  
        }

        static void printTwoDigitToWord(string zahl)
        {
            if (string.IsNullOrEmpty(zahl) || zahl.Length != 2)
            {
                Console.WriteLine("Eingabe hat keine 2 Stellen.");
                return;

            }

            if (fixedWords.ContainsKey(zahl))
            {
                w(fixedWords[zahl]);
                return;
            }

            var first = zahl[0].ToString();
            var last = zahl[1].ToString();
            Console.Write(singleDigitToWord[last]);
            if (first != "1") { 
                Console.Write("und");
            }
            Console.Write(twoDigitToWord[first]);
        }

        static void w(object x){
            Console.Write(x);
        }
    }
}
