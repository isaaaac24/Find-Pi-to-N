using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;

// Main program class
class Program
{
    const string filePath = "Resources/pi.txt";
    const int maxDigits = 1000;

    static void Main(string[] args)
    {
        int requiredDigits = GetDigitCount();
        string piDigits = ReadPiDigits(requiredDigits);
        Console.WriteLine("3." + piDigits.ToString());
    }

    static int GetDigitCount()
    {
        while (true)
        {
            Console.WriteLine("Enter the number of digits to calculate pi to: ");
            int requiredDigits = int.Parse(Console.ReadLine());
            if (requiredDigits <= maxDigits)
            {
                return requiredDigits;
            }  
            else
            {
                Console.WriteLine("Please input a number lower than 1000");
            }
        }
    }

    static string ReadPiDigits(int requiredDigits)
    {
        int digitCount = 0;
        string filePath = "Resources/pi.txt";
        StringBuilder digits = new StringBuilder();

        try
        {
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
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("pi.txt could not be found.");
        }
        catch (IOException)
        {
            Console.WriteLine("An I/O error occured while readint the file");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occured: {ex.Message}");
        }

        return digits.ToString();
    }
}