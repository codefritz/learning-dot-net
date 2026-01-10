using LearningDotNet.ConsoleApp.Demos;

namespace LearningDotNet.ConsoleApp.Menus
{
    /// <summary>
    /// Main menu system for the Learning .NET console application
    /// </summary>
    public static class MainMenu
    {
        /// <summary>
        /// Displays the main menu and handles user selection
        /// </summary>
        /// <param name="args">Command line arguments</param>
        public static void Run(string[] args)
        {
            Console.WriteLine("Learning .NET - Demo Programs Menu");
            Console.WriteLine("==================================");
            Console.WriteLine("1. Binary Multiplier");
            Console.WriteLine("2. German Number to Word Converter");
            Console.WriteLine("3. Pascal Triangle Generator");
            Console.WriteLine("4. Binary String Demo");
            Console.WriteLine("5. German Word to Number Parser");

            Console.Write("Choose a program (1-5): ");

            string choice = args.Length >= 1 ? args[0] : Console.ReadLine() ?? string.Empty;
            Console.WriteLine($"Starting with selection: {choice}\n");

            switch (choice.Trim())
            {
                case "1":
                    BinaryCalculatorDemo.Run();
                    break;
                case "2":
                    string? numberArg = args.Length >= 2 ? args[1] : null;
                    GermanNumberDemo.Run(numberArg);
                    break;
                case "3":
                    int depth = args.Length >= 2 && int.TryParse(args[1], out int d) ? d : 5;
                    PascalTriangleDemo.Run(depth);
                    break;
                case "4":
                    BinaryStringDemo.Run();
                    break;
                case "5":
                    string? germanWordArg = args.Length >= 2 ? args[1] : null;
                    GermanNumberParserDemo.Run(germanWordArg);
                    break;
                default:
                    Console.WriteLine("Invalid choice! Please select 1-5.");
                    break;
            }
        }
    }
}