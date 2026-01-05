using LearningDotNet.Core.Converters;
using LearningDotNet.Core.Common;

namespace LearningDotNet.ConsoleApp.Demos
{
    /// <summary>
    /// Demo for German number to word conversion
    /// </summary>
    public static class GermanNumberDemo
    {
        /// <summary>
        /// Runs the German number converter demo
        /// </summary>
        /// <param name="presetNumber">Optional preset number to convert</param>
        public static void Run(string? presetNumber = null)
        {
            Console.WriteLine("German Number to Word Converter");
            Console.WriteLine("==============================");

            try
            {
                string number = string.IsNullOrEmpty(presetNumber)
                    ? InputHelper.ReadNumberInput("Enter a number: ")
                    : presetNumber;

                Console.Write($"{number} -> ");
                string result = GermanNumberConverter.ConvertToWords(number);
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}