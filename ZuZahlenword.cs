

class Zahlenwortkonvertierer
{
    private static readonly Dictionary<string, string> numberToWord = new()
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
   
    public static void RunZahlenwortkonvertierer()
    {
        Console.WriteLine("Zahlenwortkonvertierer 1.0");
        Console.WriteLine("===============================");

        Console.Write("Bitte geben Sie ein Zahl ein: ");
        var zahl = Console.ReadLine();

        if (string.IsNullOrEmpty(zahl))
        {
            Console.WriteLine("Eingabe ist leer.");
            return;
            
        }

        for (int i = 0; i < zahl.Length; i++)
        {
            var current = zahl[i].ToString();
            Console.Write(numberToWord[current]);
        }
    }
}




