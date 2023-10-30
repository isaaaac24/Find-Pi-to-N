// Imports
using System.IO;
using System.Text;

// Main program class
class Program
{
    //Delcaring constants
    const string filePath = "Resources/pi.txt";
    const int maxDigits = 1000;
    const int minDigits = 1;

    //Main program execution
    static void Main(string[] args)
    {
        int requiredDigits = GetDigitCount();
        string piDigits = ReadPiDigits(requiredDigits);
        Console.WriteLine($"3.{piDigits.ToString()}");
    }

    // Takes user input to dictate number of decimal values of pi to print
    static int GetDigitCount()
    {
        // Loops input request until acceptable value is produced
        while (true)
        {
            Console.WriteLine("Enter the number of digits to calculate pi to: ");
            // Validates whether input is integer
            if (int.TryParse(Console.ReadLine(), out int requiredDigits))
            {
                // Validates whether integer value is between specified min and max digits
                if (requiredDigits <= maxDigits && requiredDigits >= minDigits)
                {
                    return requiredDigits;
                }
                else
                {
                    Console.WriteLine($"Please input a number between {minDigits} and {maxDigits}");
                }
            }
            else
            {
                Console.WriteLine("Please input an integer");
            }
        }
    }

    // Reads pi.txt to the specified amount of digits
    static string ReadPiDigits(int requiredDigits)
    {
        int digitCount = 0;
        StringBuilder digits = new StringBuilder();

        // Attempts to read pi.txt
        try
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                int currentChar;
                // Reads each character from pi.txt until there are no more characters to read, or the amount of characters read has reached the amount required
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
        // Unable to find file
        catch (FileNotFoundException)
        {
            Console.WriteLine("The file could not be found.");
        }
        // I/O exception occurs
        catch (IOException)
        {
            Console.WriteLine("An I/O error occurred while reading the file");
        }
        // UNexpected exceptions
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }

        return digits.ToString();
    }
}