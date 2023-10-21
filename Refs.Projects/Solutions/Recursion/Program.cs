
DecimalToBinary();

static void DecimalToBinary()
{
    string binary = FindBinary(11, "");
    Console.WriteLine(binary.PadLeft(32, '0'));
}

static string FindBinary(int number, string result)
{
    if (number == 0) return result;

    result = number % 2 + result;
    return FindBinary(number / 2, result);
}
