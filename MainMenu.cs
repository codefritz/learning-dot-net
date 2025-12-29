class MainMenu
{
     static void Main(string[] args)
    {
        Console.WriteLine("Learning .NET - Demo Programs");
        Console.WriteLine("=============================");
        Console.WriteLine("1. Binary Multiplier");
        Console.WriteLine("2. Zahlenwortkonvertierer (German Number to Word)");
        Console.Write("Choose a program (1 or 2): ");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                BinaryMultiplier.RunBinaryMultiplier();
                break;
            case "2":
                Zahlenwortkonvertierer.RunZahlenwortkonvertierer();
                break;
            default:
                Console.WriteLine("Invalid choice!");
                break;
        }
    }

}