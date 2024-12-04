using System;

public class Program
{
    public static void Main(string[] args)
    {
        NumberSystems numberSystems = new();
        string[] options =
            { "Dziesiętny", "Binarny", "Ósemkowy", "Szesnastkowy", "Wyjście" };

        while (true)
        {
            int selectedIndex = DisplayMenu(options);

            if (selectedIndex == options.Length - 1) return;

            HandleConversion(selectedIndex, numberSystems);
        }
    }

    private static int DisplayMenu(string[] options)
    {
        int selectedIndex = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Wybierz system liczbowy do przekształcenia:");

            for (int i = 0; i < options.Length; i++)
            {
                if (i == selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }

                Console.WriteLine(options[i]);
                Console.ResetColor();
            }

            ConsoleKeyInfo keyInfo = Console.ReadKey();
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    selectedIndex = selectedIndex == 0
                        ? options.Length - 1
                        : selectedIndex - 1;
                    break;
                case ConsoleKey.DownArrow:
                    selectedIndex = selectedIndex == options.Length - 1
                        ? 0
                        : selectedIndex + 1;
                    break;
                case ConsoleKey.Enter:
                    return selectedIndex;
            }
        }
    }

    private static void HandleConversion(int selectedIndex,
                                         NumberSystems numberSystems
    )
    {
        Console.Clear();
        Console.Write("Podaj liczbę: ");
        string number = Console.ReadLine();

        switch (selectedIndex)
        {
            case 0:
                numberSystems.SetFromDecimal(number);
                break;
            case 1:
                numberSystems.SetFromBinary(number);
                break;
            case 2:
                numberSystems.SetFromOctal(number);
                break;
            case 3:
                numberSystems.SetFromHexadecimal(number);
                break;
        }

        Console.Clear();
        Console.WriteLine(numberSystems.ToString());
        Console.WriteLine("Naciśnij dowolny klawisz, aby kontynuować...");
        Console.ReadKey();
    }
}

public class NumberSystems
{
    public string DecimalNumber { get; set; } = "";
    public string BinaryNumber { get; set; } = "";
    public string OctalNumber { get; set; } = "";
    public string HexadecimalNumber { get; set; } = "";

    public void SetFromDecimal(string decimalNumber)
    {
        DecimalNumber = decimalNumber;
        int number = int.Parse(decimalNumber);
        BinaryNumber = ConvertToBinary(number);
        OctalNumber = ConvertToOctal(number);
        HexadecimalNumber = ConvertToHexadecimal(number);
    }

    public void SetFromBinary(string binaryNumber)
    {
        BinaryNumber = binaryNumber;
        int number = ConvertFromBinary(binaryNumber);
        DecimalNumber = number.ToString();
        BinaryNumber = binaryNumber;
        OctalNumber = ConvertToOctal(number);
        HexadecimalNumber = ConvertToHexadecimal(number);
    }

    public void SetFromOctal(string octalNumber)
    {
        OctalNumber = octalNumber;
        int number = ConvertFromOctal(octalNumber);
        DecimalNumber = number.ToString();
        BinaryNumber = ConvertToBinary(number);
        OctalNumber = octalNumber;
        HexadecimalNumber = ConvertToHexadecimal(number);
    }

    public void SetFromHexadecimal(string hexadecimalNumber)
    {
        HexadecimalNumber = hexadecimalNumber;
        int number = ConvertFromHexadecimal(hexadecimalNumber);
        DecimalNumber = number.ToString();
        BinaryNumber = ConvertToBinary(number);
        OctalNumber = ConvertToOctal(number);
        HexadecimalNumber = hexadecimalNumber;
    }

    private string ConvertToBinary(int number)
    {
        string result = "";
        while (number > 0)
        {
            result = number % 2 + result;
            number /= 2;
        }

        return result;
    }

    private string ConvertToOctal(int number)
    {
        string result = "";
        while (number > 0)
        {
            result = number % 8 + result;
            number /= 8;
        }

        return result;
    }

    private string ConvertToHexadecimal(int number)
    {
        string result = "";
        string hexDigits = "0123456789ABCDEF";
        while (number > 0)
        {
            result = hexDigits[number % 16] + result;
            number /= 16;
        }

        return result;
    }

    private int ConvertFromBinary(string binaryNumber)
    {
        int result = 0;
        foreach (char digit in binaryNumber)
            result = result * 2 + (digit - '0');
        return result;
    }

    private int ConvertFromOctal(string octalNumber)
    {
        int result = 0;
        foreach (char digit in octalNumber) result = result * 8 + (digit - '0');
        return result;
    }

    private int ConvertFromHexadecimal(string hexadecimalNumber)
    {
        int result = 0;
        foreach (char digit in hexadecimalNumber)
            result = result * 16 +
                (digit >= 'A' ? digit - 'A' + 10 : digit - '0');
        return result;
    }

    public override string ToString()
    {
        return
            $"Decimal: {DecimalNumber}, Binary: {BinaryNumber}, Octal: {OctalNumber}, Hexadecimal: {HexadecimalNumber}";
    }
}

// Zadanie wykonała: Nicola Kaleta, uczennica klasy 4D. 
