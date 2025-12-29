using System;
using System.Numerics;
using System.Text;

class BinaryMultiplier
{
    public static void RunBinaryMultiplier()
    {
        Console.WriteLine("Binary Multiplication Calculator");
        Console.WriteLine("===============================");

        string binary1 = BinaryNumberReader("Enter the first binary number: ");
        string binary2 = BinaryNumberReader("Enter the second binary number: ");

        string result = MultiplyBinary(binary1, binary2);

        Console.WriteLine("Result:");
        Console.WriteLine($"{binary1} × {binary2} = {result}");
    }

    static string BinaryNumberReader(string prompt)
    {
        string input;
        while (true)
        {
            Console.Write(prompt);
            input = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Please enter a binary number.");
                continue;
            }

            if (IsValidBinary(input))
            {
                return input;
            }
            else
            {
                Console.WriteLine("Invalid binary number. Please use only 0 and 1.");
            }
        }
    }

    static bool IsValidBinary(string binary)
    {
        foreach (char c in binary)
        {
            if (c != '0' && c != '1')
            {
                return false;
            }
        }
        return true;
    }

    static string MultiplyBinary(string binary1, string binary2)
    {
        // Handle edge cases
        if (binary1 == "0" || binary2 == "0")
            return "0";

        // Initialize result as "0"
        string result = "0";

        // Multiply using the standard multiplication algorithm
        for (int i = binary2.Length - 1; i >= 0; i--)
        {
            if (binary2[i] == '1')
            {
                // Shift binary1 left by (binary2.Length - 1 - i) positions
                string shifted = binary1 + new string('0', binary2.Length - 1 - i);
                result = AddBinary(result, shifted);
            }
        }

        return result;
    }

    static string AddBinary(string binary1, string binary2)
    {
        StringBuilder result = new StringBuilder();
        int carry = 0;
        int i = binary1.Length - 1;
        int j = binary2.Length - 1;

        while (i >= 0 || j >= 0 || carry > 0)
        {
            int sum = carry;

            if (i >= 0)
            {
                sum += digit(binary1[i]);
                i--;
            }

            if (j >= 0)
            {
                sum += digit(binary2[j]);
                j--;
            }

            result.Insert(0, (sum % 2).ToString());
            // Console.WriteLine("Tmp result: " + result.ToString()); // Debug output if needed
            carry = sum / 2;
        }

        return result.ToString();
    }

    static int digit(char it)
    {
        return it - '0';
    }

}