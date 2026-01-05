using LearningDotNet.ConsoleApp.Menus;

namespace LearningDotNet.ConsoleApp
{
    /// <summary>
    /// Main entry point for the Learning .NET console application
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Application entry point
        /// </summary>
        /// <param name="args">Command line arguments</param>
        static void Main(string[] args)
        {
            try
            {
                MainMenu.Run(args);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                Environment.Exit(1);
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
