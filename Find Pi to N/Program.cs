using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;

// Main program class
class Program
{
    const string filePath = "Resources/pi.txt";
    static void Main(string[] args)
    {
        int requiredDigits = GetDigitCount();
        string piDigits = ReadPiDigits(requiredDigits);

        Console.WriteLine("3." + piDigits.ToString());
    }

    static int GetDigitCount()
    {
        Console.WriteLine("Enter the number of digits to calculate pi to: ");
        int requiredDigits = int.Parse(Console.ReadLine());
        return requiredDigits;
    }

    static string ReadPiDigits(int requiredDigits)
    {
        int digitCount = 0;
        string filePath = "Resources/pi.txt";
        StringBuilder digits = new StringBuilder();

        using (StreamReader reader = new StreamReader(filePath))
        {
            int currentChar;
            while ((currentChar = reader.Read()) != -1 && digitCount < requiredDigits)
            {
                if (Char.IsDigit((char)currentChar))
                {
                    digits.Append((char)currentChar);
                    digitCount++;
                }
            }

        }

        return digits.ToString();
    }
}