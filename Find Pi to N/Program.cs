using System.IO;
using System.Text;

// Main program class
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the number of digits to calculate pi to: ");
        int requiredDigits = int.Parse(Console.ReadLine());

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

        Console.WriteLine("3." + digits.ToString());
    }
}