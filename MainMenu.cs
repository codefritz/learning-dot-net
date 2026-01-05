using System;
using LearningDotNet;

namespace LearningDotNet
{
    class MainMenu
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Learning .NET - Demo Programs Menu");
            Console.WriteLine("==================================");
            Console.WriteLine("1. Binary Multiplier");
            Console.WriteLine("2. Zahlenwortkonvertierer (German Number to Word)");
            Console.WriteLine("3. Demo");

            Console.Write("Choose a program (1 or 2): ");

            string choice = args.Length >= 1 ? args[0] : Console.ReadLine();
            Console.WriteLine($"Starte mit Auswahl: ${choice}\n");

            switch (choice)
            {
                case "1":
                    BinaryMultiplier.RunBinaryMultiplier();
                    break;
                case "2":
                    Zahlenwortkonvertierer.RunZahlenwortkonvertierer(args.Length == 2 ? args[1] : null);
                    break;
                case "3":
                    Demo.Run(args);
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
    }
}