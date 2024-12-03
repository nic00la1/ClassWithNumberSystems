using System;

public class Program
{
    public static void Main(string[] args)
    {
        NumberSystems numberSystems = new NumberSystems();

        // Przykładowe użycie
        numberSystems.SetFromDecimal("1562");
        Console.WriteLine(numberSystems.ToString());

        numberSystems.SetFromBinary("11000011010");
        Console.WriteLine(numberSystems.ToString());

        numberSystems.SetFromOctal("3032");
        Console.WriteLine(numberSystems.ToString());

        numberSystems.SetFromHexadecimal("61A");
        Console.WriteLine(numberSystems.ToString());
    }
}

public class NumberSystems
{
    public string DecimalNumber { get; set; }
    public string BinaryNumber { get; set; }
    public string OctalNumber { get; set; }
    public string HexadecimalNumber { get; set; }

    public NumberSystems()
    {
        DecimalNumber = "";
        BinaryNumber = "";
        OctalNumber = "";
        HexadecimalNumber = "";
    }

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
        OctalNumber = ConvertToOctal(number);
        HexadecimalNumber = ConvertToHexadecimal(number);
    }

    public void SetFromOctal(string octalNumber)
    {
        OctalNumber = octalNumber;
        int number = ConvertFromOctal(octalNumber);
        DecimalNumber = number.ToString();
        BinaryNumber = ConvertToBinary(number);
        HexadecimalNumber = ConvertToHexadecimal(number);
    }

    public void SetFromHexadecimal(string hexadecimalNumber)
    {
        HexadecimalNumber = hexadecimalNumber;
        int number = ConvertFromHexadecimal(hexadecimalNumber);
        DecimalNumber = number.ToString();
        BinaryNumber = ConvertToBinary(number);
        OctalNumber = ConvertToOctal(number);
    }

    private string ConvertToBinary(int number)
    {
        string result = "";
        while (number > 0)
        {
            result = (number % 2) + result;
            number /= 2;
        }
        return result;
    }

    private string ConvertToOctal(int number)
    {
        string result = "";
        while (number > 0)
        {
            result = (number % 8) + result;
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
        {
            result = result * 2 + (digit - '0');
        }
        return result;
    }

    private int ConvertFromOctal(string octalNumber)
    {
        int result = 0;
        foreach (char digit in octalNumber)
        {
            result = result * 8 + (digit - '0');
        }
        return result;
    }

    private int ConvertFromHexadecimal(string hexadecimalNumber)
    {
        int result = 0;
        foreach (char digit in hexadecimalNumber)
        {
            result = result * 16 + (digit >= 'A' ? digit - 'A' + 10 : digit - '0');
        }
        return result;
    }

    public override string ToString()
    {
        return $"Decimal: {DecimalNumber}, Binary: {BinaryNumber}, Octal: {OctalNumber}, Hexadecimal: {HexadecimalNumber}";
    }
}
