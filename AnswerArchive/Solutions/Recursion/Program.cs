
var binary = new DecimalToBinary();



public class DecimalToBinary
{
    public DecimalToBinary()
    {
        string binary = FindBinary(232, "");
    }

    public string FindBinary(int number, string result)
    {
        if(number == 0) return result;

        result = number % 2 + result;
        return FindBinary(number % 2, result);
    }
}
