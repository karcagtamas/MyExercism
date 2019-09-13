using System;

public class PhoneNumber
{
    public static string Clean(string phoneNumber)
    {
        string number = phoneNumber;
        string toReplace = " -.()+";
        string validCharacters = "0123456789";
        foreach (char i in toReplace)
        {
            number = number.Replace(i.ToString(), "");
        }
        if (number.Length == 11 && number.StartsWith("1"))
        {
            number = number.Remove(0, 1);
        }
        foreach (var i in number)
        {
            if (!validCharacters.Contains(i))
            {
                throw new ArgumentException("Invalid character");
            }
        }
        if (number.Length != 10)
        {
            throw new ArgumentException("Invalid length");
        }
        if (number[0] == '0' || number[0] == '1')
        {
            throw new ArgumentException("Invalid area start number");
        }
        if (number[3] == '0' || number[3] == '1')
        {
            throw new ArgumentException("Invalid exchange start number");
        }
        return number;
    }
}